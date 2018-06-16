using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class KindRepository : IRepository<Kind>
    {
        private IDataContext<Kind> _context;
        public KindRepository(IDataContext<Kind> context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<Kind> GetAll()
        {
            return _context.GetAll();
        }

        public Kind GetById(int id)
        {
            return _context.GetById(id);
        }

        public void Save(Kind obj)
        {
            _context.Save(obj);
        }
    }
}