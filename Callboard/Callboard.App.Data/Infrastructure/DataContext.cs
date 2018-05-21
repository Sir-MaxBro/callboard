using Callboard.App.Data.DbInfractructure;
using Callboard.App.General.Loggers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Callboard.App.Data.Infrastructure
{
    internal class DataContext : IDisposable
    {
        private IDbContext _context;
        private ILoggerWrapper _logger = LoggerWrapper.GetInstance();
        public DataContext(string connectionString)
        {
            _context = new SqlDbContext(connectionString);
        }

        public void Open()
        {
            _context.Open();
        }

        public void Close()
        {
            this.Dispose();
        }

        public IReadOnlyCollection<TResult> ExecuteProcedure<TResult>(string procedureName, IDictionary<string, object> values, Func<DbDataReader, TResult> mapping)
        {
            IReadOnlyCollection<TResult> mappingCollection = null;
            DbDataReader reader = null;
            try
            {
                this.Open();
                reader = _context.ExecuteProcedure(procedureName, values);
                if (!reader.IsClosed)
                {
                    mappingCollection = Mapper.MapCollection(reader, mapping);
                }
                this.Dispose();
            }
            catch (InvalidCastException ex)
            {
                _logger.ErrorFormat(ex.Message);
            }
            catch (SqlException ex)
            {
                _logger.ErrorFormat(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.ErrorFormat(ex.Message);
            }
            finally
            {
                reader?.Close();
            }
            return mappingCollection;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
