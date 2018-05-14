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

namespace Callboard.App.Data.Abstract
{
    public abstract class SqlDbContext<T>
        where T : new()
    {
        private DbConnection _dbConnection = new SqlConnection();
        public SqlDbContext(string connectionString)
        {
            _dbConnection.ConnectionString = connectionString;
        }

        public void Open()
        {
            try
            {
                _dbConnection.Open();
            }
            catch (SqlException ex)
            {

            }
        }

        public void Close()
        {
            _dbConnection?.Close();
        }

        public IReadOnlyCollection<T> Select()
        {
            IReadOnlyCollection<T> mappingCollection = null;
            var tableNames = typeof(T).GetCustomAttributes(false)
                .OfType<TableAttribute>()
                .Select(attr => attr.TableName)
                .ToList();

            string spName = $"sp_select_{ tableNames[0].ToLower() }";
            DbCommand command = new SqlCommand(spName);
            command.Connection = _dbConnection;
            command.CommandType = CommandType.StoredProcedure;

            using (var reader = command.ExecuteReader())
            {
                mappingCollection = Mapper.MapCollection<T>(reader).ToList();
            }

            return mappingCollection;
        }
    }
}
