using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Callboard.App.General.Helpers;
using Callboard.App.General.Loggers;

namespace Callboard.App.Data.DbInfractructure
{
    internal class SqlDbContext : IDbContext
    {
        private ILoggerWrapper _logger = LoggerWrapper.GetInstance();
        private SqlConnection _connection;
        public SqlDbContext(string connectionString)
        {
            Checker.CheckForNull(connectionString, $"Connection string is empty.");
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
                string errorMessage = $"Cannot open a connection without specifying a data source or server.\nConnection string: { _connection.ConnectionString }";
                throw new InvalidOperationException(errorMessage, ex);
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
