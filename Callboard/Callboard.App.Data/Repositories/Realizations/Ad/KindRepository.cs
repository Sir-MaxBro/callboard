using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class KindRepository : IKindRepository
    {
        private IKindContext _context;
        public KindRepository(IKindContext context)
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