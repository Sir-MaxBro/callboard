using Callboard.App.Data.DbContext;
using Callboard.App.Data.Helpers;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
using System.Collections.Generic;
using System.Data;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal abstract class EntityDbContext<T>
    {
        private IChecker _checker;
        protected IDbContext _context;
        protected ILoggerWrapper _logger;
        public EntityDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(context);
            _checker.CheckForNull(logger);
            _context = context;
            _logger = logger;
            this.InitializeConnection();
        }

        private void InitializeConnection()
        {
            var config = new ConfigHelper(_logger, _checker);
            _context.ConnectionString = config.ConnectionString;
        }

        protected IReadOnlyCollection<T> GetAll(string procedureName, Mapper<DataSet, T> mapper, IDictionary<string, object> values = null)
        {
            IReadOnlyCollection<T> entities = null;
            using (var dataSet = _context.ExecuteProcedure(procedureName, values))
            {
                if (this.CheckDataSet(dataSet))
                {
                    entities = mapper?.MapCollection(dataSet);
                }
            }
            return entities;
        }

        protected T Get(string procedureName, Mapper<DataSet, T> mapper, IDictionary<string, object> values = null)
        {
            T obj = default(T);
            using (var dataSet = _context.ExecuteProcedure(procedureName, values))
            {
                if (this.CheckDataSet(dataSet) && mapper != null)
                {
                    obj = mapper.MapItem(dataSet);
                }
            }
            return obj;
        }

        protected void Save(T obj, string procedureName, Mapper<DataSet, T> mapper)
        {
            var values = mapper?.MapValues(obj);
            _context.ExecuteNonQuery(procedureName, values);
        }

        protected void Execute(string procedureName, IDictionary<string, object> values = null)
        {
            _context.ExecuteNonQuery(procedureName, values);
        }

        private bool CheckDataSet(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count != 0)
            {
                return true;
            }
            return false;
        }
    }
}