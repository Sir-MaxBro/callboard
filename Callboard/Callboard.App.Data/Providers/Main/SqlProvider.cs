using Callboard.App.Data.DataProviders.Main;
using Callboard.App.Data.Helpers;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
using System.Collections.Generic;
using System.Data;

namespace Callboard.App.Data.Providers.Main
{
    internal abstract class SqlProvider<T>
    {
        private ISqlDataProvider<T> _sqlProvider;
        protected ILoggerWrapper _logger;
        protected IChecker _checker;
        public SqlProvider(ISqlDataProvider<T> sqlProvider, ILoggerWrapper logger, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));

            _checker.CheckForNull(sqlProvider);
            _sqlProvider = sqlProvider;

            _checker.CheckForNull(logger);
            _logger = logger;
            this.InitializeConnection();
        }

        private void InitializeConnection()
        {
            var config = new ConfigHelper(_logger, _checker);
            _sqlProvider.ConnectionString = config.ConnectionString;
        }

        protected IReadOnlyCollection<T> GetAll(string procedureName, Mapper<DataSet, T> mapper, IDictionary<string, object> values = null)
        {
            this.SetProcedureName(procedureName);
            this.SetValues(values);
            this.SetMapper(mapper);
            return _sqlProvider.GetAll();
        }

        protected T Get(string procedureName, Mapper<DataSet, T> mapper, IDictionary<string, object> values = null)
        {
            this.SetProcedureName(procedureName);
            this.SetValues(values);
            this.SetMapper(mapper);
            return _sqlProvider.Get();
        }

        protected void Save(T obj, string procedureName, Mapper<DataSet, T> mapper)
        {
            this.SetProcedureName(procedureName);
            this.SetMapper(mapper);
            _sqlProvider.Save(obj);
        }

        protected void Delete(string procedureName, IDictionary<string, object> values = null)
        {
            this.SetProcedureName(procedureName);
            this.SetValues(values);
            _sqlProvider.Delete();
        }

        private void SetProcedureName(string procedureName)
        {
            _sqlProvider.ProcedureName = procedureName;
        }

        private void SetMapper(Mapper<DataSet, T> mapper)
        {
            _sqlProvider.Mapper = mapper;
        }

        private void SetValues(IDictionary<string, object> values)
        {
            _sqlProvider.Values = values;
        }
    }
}
