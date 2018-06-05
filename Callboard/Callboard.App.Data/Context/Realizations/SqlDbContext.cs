﻿using Callboard.App.Data.Context.Main;
using Callboard.App.Data.Exceptions;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Callboard.App.Data.Context.Realizations
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
            using (var procedure = this.CreateProcedure(procedureName, values))
            using (var adapter = new SqlDataAdapter(procedure))
            {
                try
                {
                    connection.Open();
                    procedure.Connection = connection;
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
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
            return dataSet;
        }

        public void ExecuteNonQuery(string procedureName, IDictionary<string, object> values = null)
        {
            using (var connection = this.CreateConnection())
            using (var procedure = this.CreateProcedure(procedureName, values))
            {
                try
                {
                    connection.Open();
                    procedure.Connection = connection;
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
