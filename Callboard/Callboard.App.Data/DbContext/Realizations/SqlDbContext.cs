using Callboard.App.Data.Exceptions;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Callboard.App.Data.DbContext.Realizations
{
    internal class SqlDbContext : IDbContext
    {
        private ILoggerWrapper _logger;
        private IChecker _checker;
        private string _connectionString;
        public SqlDbContext(ILoggerWrapper logger, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(logger);
            _logger = logger;
        }

        public string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }

        public DataSet ExecuteProcedure(string procedureName, IDictionary<string, object> values = null)
        {
            DataSet dataSet = null;
            using (var connection = this.CreateConnection())
            {
                using (var procedure = this.CreateProcedure(procedureName, values))
                {
                    using (var adapter = new SqlDataAdapter(procedure))
                    {
                        procedure.Connection = connection;
                        try
                        {
                            connection.Open();
                            dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            connection.Close();
                        }
                        catch (InvalidOperationException ex)
                        {
                            string errorMessage = $"{ ex.Message }\nConnection string: { connection.ConnectionString }";
                            _logger.ErrorFormat(errorMessage);
                            dataSet = null;
                        }
                        catch (SqlException ex) when (ex.State == 1) // user login already exists
                        {
                            _logger.InfoFormat(ex.Message);
                            throw new LoginAlreadyExistsException(ex.Message, ex);
                        }
                        catch (SqlException ex) when (ex.State == 2) // login is invalid
                        {
                            _logger.InfoFormat(ex.Message);
                            throw new InvalidLoginException(ex.Message, ex);
                        }
                        catch (SqlException ex) when (ex.State == 3) // password is invalid
                        {
                            _logger.InfoFormat(ex.Message);
                            throw new InvalidPasswordException(ex.Message, ex);
                        }
                        catch (SqlException ex)
                        {
                            string errorMessage = $"{ ex.Message }\nConnection string: { connection.ConnectionString }";
                            _logger.ErrorFormat(errorMessage);
                            dataSet = null;
                        }
                    }
                }
            }
            return dataSet;
        }

        public void ExecuteNonQuery(string procedureName, IDictionary<string, object> values = null)
        {
            using (var connection = this.CreateConnection())
            {
                using (var procedure = this.CreateProcedure(procedureName, values))
                {
                    procedure.Connection = connection;
                    try
                    {
                        connection.Open();
                        procedure.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (InvalidOperationException ex)
                    {
                        string errorMessage = $"{ ex.Message }\nConnection string: { connection.ConnectionString }";
                        _logger.ErrorFormat(errorMessage);
                    }
                    catch (SqlException ex)
                    {
                        string errorMessage = $"{ ex.Message }\nConnection string: { connection.ConnectionString }";
                        _logger.ErrorFormat(errorMessage);
                    }
                }
            }
        }

        private SqlCommand CreateProcedure(string procedureName, IDictionary<string, object> values = null)
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = procedureName,
                CommandType = CommandType.StoredProcedure
            };

            if (values != null)
            {
                foreach (var item in values)
                {
                    var parameter = this.CreateParameter(item.Key, item.Value);
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        private SqlParameter CreateParameter(string name, object value)
        {
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = $"@{ name }",
                Value = value
            };

            if (value is IEnumerable<SqlDataRecord>)
            {
                parameter.SqlDbType = SqlDbType.Structured;
            }

            return parameter;
        }

        private SqlConnection CreateConnection()
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                return new SqlConnection(_connectionString);
            }
            else
            {
                throw new EmptyConnectionStringException();
            }
        }
    }
}