using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Callboard.App.Data.DbInfractructure
{
    internal class SqlDbContext : IDbContext
    {
        private SqlConnection _connection;
        public SqlDbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public void Open()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public DbDataReader ExecuteProcedure(string procedureName, IDictionary<string, object> values = null)
        {
            SqlCommand command = new SqlCommand(procedureName, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (values != null)
            {
                foreach (var item in values)
                {
                    command.Parameters.AddWithValue($"@{ item.Key }", item.Value);
                }
            }

            DbDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            return reader;
        }
    }
}
