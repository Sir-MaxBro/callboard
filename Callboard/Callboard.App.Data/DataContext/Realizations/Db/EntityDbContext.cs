using Callboard.App.Data.DbContext;
using Callboard.App.Data.Exceptions;
using Callboard.App.Data.Helpers;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using Callboard.App.General.Results.Realizations;
using System;
using System.Collections.Generic;
using System.Data;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal abstract class EntityDbContext<T>
        where T : class
    {
        protected IDbContext _context;
        protected ILoggerWrapper _logger;
        public EntityDbContext(IDbContext context, ILoggerWrapper logger)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
            this.InitializeConnection();
        }

        private void InitializeConnection()
        {
            var config = new ConfigHelper(_logger);
            _context.ConnectionString = config.ConnectionString;
        }

        protected IResult<IReadOnlyCollection<T>> GetAll(string procedureName, Mapper<DataSet, T> mapper, IDictionary<string, object> values = null)
        {
            IReadOnlyCollection<T> entities = null;
            IResult<IReadOnlyCollection<T>> result = new NoneResult<IReadOnlyCollection<T>>();

            try
            {
                using (var dataSet = _context.ExecuteProcedure(procedureName, values))
                {
                    if (this.CheckDataSet(dataSet))
                    {
                        entities = mapper?.MapCollection(dataSet);
                    }
                }
            }
            catch (UserException ex)
            {
                result = new FailureResult<IReadOnlyCollection<T>>(ex, ex.Message);
            }

            if (entities != null)
            {
                result = new SuccessResult<IReadOnlyCollection<T>>(entities);
            }

            return result;
        }

        protected IResult<T> Get(string procedureName, Mapper<DataSet, T> mapper, IDictionary<string, object> values = null)
        {
            T obj = default(T);
            IResult<T> result = new NoneResult<T>();
            try
            {
                using (var dataSet = _context.ExecuteProcedure(procedureName, values))
                {
                    if (this.CheckDataSet(dataSet) && mapper != null)
                    {
                        obj = mapper.MapItem(dataSet);
                    }
                }
            }
            catch (UserException ex)
            {
                result = new FailureResult<T>(ex, ex.Message);
            }

            if (obj != null)
            {
                result = new SuccessResult<T>(obj);
            }

            return result;
        }

        protected IResult<T> Save(T obj, string procedureName, Mapper<DataSet, T> mapper)
        {
            var values = mapper?.MapValues(obj);
            try
            {
                _context.ExecuteNonQuery(procedureName, values);
            }
            catch (UserException ex)
            {
                return new FailureResult<T>(ex, ex.Message);
            }

            return new NoneResult<T>();
        }

        protected IResult<T> Execute(string procedureName, IDictionary<string, object> values = null)
        {
            try
            {
                _context.ExecuteNonQuery(procedureName, values);
            }
            catch (UserException ex)
            {
                return new FailureResult<T>(ex, ex.Message);
            }

            return new NoneResult<T>();
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