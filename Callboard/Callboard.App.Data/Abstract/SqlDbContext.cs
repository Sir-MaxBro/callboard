using System;
using System.Collections.Generic;
using Callboard.App.General.Attributes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Callboard.App.Data.Infrastructure;
using System.Reflection;
using Callboard.App.Data.Entities;
using System.Configuration;
using Callboard.App.General.Loggers;

namespace Callboard.App.Data.Abstract
{
    public class SqlDbContext<T> : IDisposable
        where T : new()
    {
        private SqlConnection _dbConnection = new SqlConnection();
        private ILoggerWrapper _logger = LoggerWrapper.GetInstance();
        private IReadOnlyCollection<T> _mappingCollection;
        public SqlDbContext(/*string connectionString*/)
        {
            _mappingCollection = new List<T>();
            var settings = ConfigurationManager.ConnectionStrings["callboardDB"];
            _dbConnection.ConnectionString = settings.ConnectionString;
        }

        public void Open()
        {
            try
            {
                _dbConnection.Open();
            }
            catch (SqlException ex)
            {
                _logger.ErrorFormat(ex.Message);
            }
        }

        public void Close()
        {
            _dbConnection?.Close();
        }

        public void Dispose()
        {
            this.Close();
        }

        public IReadOnlyCollection<T> Items
        {
            get => _mappingCollection;
        }

        public SqlDbContext<T> Select()
        {
            var tableNames = typeof(T).GetCustomAttributes(false)
                .OfType<TableAttribute>()
                .Select(attr => attr.TableName)
                .ToList();

            string spName = $"sp_select_{ tableNames[0].ToLower() }";

            DbCommand command = new SqlCommand(spName)
            {
                Connection = _dbConnection,
                CommandType = CommandType.StoredProcedure
            };

            DbDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                _mappingCollection = Mapper.MapCollection<T>(reader).ToList();
            }
            finally
            {
                reader?.Close();
            }
            return this;
        }

        public SqlDbContext<T> Join(params string[] tableNames)
        {
            foreach (var item in _mappingCollection)
            {
                for (int i = 0; i < tableNames.Length; i++)
                {
                    var elements = GetDependentFields(typeof(T), item);
                    var value = elements.FirstOrDefault(prop => prop.TableName == tableNames[i]);
                    var mapElement = Get(value.TableName, value.FKey, value.Value, value.ValueType);
                    value.Property.SetValue(item, mapElement);
                }
            }
            return this;
        }

        public SqlDbContext<T> FiltrBy(string columnName, object fKey)
        {
            var tableNames = typeof(T).GetCustomAttributes(false)
               .OfType<TableAttribute>()
               .Select(attr => attr.TableName)
               .ToList();

            string spName = $"sp_filter_{ tableNames[0].ToLower() }_by_{ columnName.ToLower() }";
            SqlCommand command = new SqlCommand(spName)
            {
                Connection = _dbConnection,
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue($"@{ columnName }", fKey);

            DbDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                _mappingCollection = Mapper.MapCollection<T>(reader).ToList();
            }
            finally
            {
                reader?.Close();
            }
            return this;
        }

        public SqlDbContext<T> Include(string tableName)
        {
            var tableNames = typeof(T).GetCustomAttributes(false)
              .OfType<TableAttribute>()
              .Select(attr => attr.TableName)
              .ToList();

            var fKeyProperty = typeof(T).GetProperties()
                .Where(prop => prop.GetCustomAttribute<IncludeAttribute>()?.TableName == tableName)
                .FirstOrDefault();

            var fKey = fKeyProperty?.GetCustomAttribute<IncludeAttribute>().FKey;

            string spName = $"sp_include_{ tableNames[0].ToLower() }_on_{ tableName.ToLower() }_by_{ fKey.ToLower() }";

            SqlCommand command = new SqlCommand(spName)
            {
                Connection = _dbConnection,
                CommandType = CommandType.StoredProcedure
            };

            foreach (var item in _mappingCollection)
            {
                //var innerObj = typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { });
                var property = item.GetType().GetProperties()
                    .Where(prop => prop.GetCustomAttribute<ColumnAttribute>().ColumnName == fKey.ToString())
                    .FirstOrDefault();

                var propValue = property?.GetValue(item);

                command.Parameters.Clear();

                command.Parameters.AddWithValue($"@{ fKey }", propValue);

                DbDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader();
                    //_mappingCollection = Mapper.MapCollection<T>(reader).ToList();
                    fKeyProperty.SetValue(item, Mapper.MapCollection<T>(reader).ToList());
                }
                finally
                {
                    reader?.Close();
                }
            }
            return this;
        }

        private object Get(string tableName, string fKey, object entity, Type entityType)
        {
            string spName = $"sp_get_{ tableName.ToLower() }_by_{ fKey.ToLower() }";
            object mapElement = null;
            SqlCommand command = new SqlCommand(spName)
            {
                Connection = _dbConnection,
                CommandType = CommandType.StoredProcedure
            };

            var items = GetDependentFields(entityType, entity);

            var value = entity?.GetType()
                .GetProperties()
                .Where(prop => prop.GetCustomAttribute<ColumnAttribute>().ColumnName == fKey)
                .FirstOrDefault()
                .GetValue(entity);

            command.Parameters.AddWithValue($"@{ fKey }", value);

            DbDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                MethodInfo method = typeof(Mapper).GetMethod("MapElement");
                MethodInfo generic = method.MakeGenericMethod(entityType);
                mapElement = generic.Invoke(null, new object[] { reader });
            }
            finally
            {
                reader?.Close();
            }

            //foreach (var item in items)
            //{
            //    var ttt = Get(item.TableName, item.FKey, item.Value, item.ValueType);
            //    item.Property.SetValue(item, ttt);
            //}

            return mapElement;
        }

        private IReadOnlyCollection<MapperItem> GetDependentFields(Type type, object value)
        {
            return type.GetProperties()
                    .Select(prop =>
                    {
                        var obj = prop.GetCustomAttributes(typeof(ForeignKeyAttribute), false).OfType<ForeignKeyAttribute>().FirstOrDefault();
                        if (obj != null)
                        {
                            // create new instance of dependence type
                            return new MapperItem
                            {
                                TableName = obj.TableName,
                                FKey = obj.FKey,
                                Value = prop.GetValue(value),
                                ValueType = prop.PropertyType,
                                Property = prop
                            };
                        }
                        return null;
                    })
                    .Where(prop => prop != null)
                    .ToList();
        }
    }
}
