using Callboard.App.Data.DbInfractructure;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Infrastructure
{
    internal class DataContext : IDisposable
    {
        private IDbContext _context;
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
            var reader = _context.ExecuteProcedure(procedureName, values);

            IReadOnlyCollection<TResult> mappingCollection = null;
            if (!reader.IsClosed)
            {
                mappingCollection = Mapper.MapCollection(reader, mapping);
                reader.Close();
            }
            return mappingCollection;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
