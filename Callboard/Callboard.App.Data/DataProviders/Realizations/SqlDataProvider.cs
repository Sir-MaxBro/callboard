using Callboard.App.Data.Context.Main;
using Callboard.App.Data.DataProviders.Main;
using Callboard.App.Data.Exceptions;
using Callboard.App.Data.Mappers;
using System.Collections.Generic;
using System.Data;

namespace Callboard.App.Data.DataProviders.Realizations
{
    internal class SqlDataProvider<T> : ISqlDataProvider<T>
    {
        private ISqlDbContext _context;
        public SqlDataProvider(ISqlDbContext context)
        {
            _context = context;
        }

        public string ProcedureName { get; set; }

        public IDictionary<string, object> Values { get; set; }

        public Mapper<DataSet, T> Mapper { get; set; }

        public string ConnectionString { get; set; }

        public void ClearValues()
        {
            this.Values = null;
        }

        public void Delete()
        {
            this.InitializeConnectionString();
            _context.ExecuteNonQuery(this.ProcedureName, this.Values);
        }

        public T Get()
        {
            this.InitializeConnectionString();
            T obj = default(T);
            using (var dataSet = _context.ExecuteProcedure(this.ProcedureName, this.Values))
            {
                if (dataSet != null && this.Mapper != null)
                {
                    obj = this.Mapper.MapItem(dataSet);
                }
            }
            return obj;
        }

        public IReadOnlyCollection<T> GetAll()
        {
            this.InitializeConnectionString();
            IReadOnlyCollection<T> entities = null;
            using (var dataSet = _context.ExecuteProcedure(this.ProcedureName, this.Values))
            {
                if (dataSet != null)
                {
                    entities = this.Mapper?.MapCollection(dataSet);
                }
            }
            return entities;
        }

        public void Save(T obj)
        {
            this.InitializeConnectionString();
            var values = this.Mapper?.MapValues(obj);
            _context.ExecuteNonQuery(this.ProcedureName, values);
        }

        private void InitializeConnectionString()
        {
            if (!string.IsNullOrEmpty(this.ConnectionString))
            {
                _context.ConnectionString = this.ConnectionString;
            }
            else
            {
                throw new EmptyConnectionStringException();
            }
        }
    }
}
