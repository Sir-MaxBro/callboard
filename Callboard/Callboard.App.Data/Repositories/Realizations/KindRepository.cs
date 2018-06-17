using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
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

        public IResult<Kind> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<IReadOnlyCollection<Kind>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<Kind> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<Kind> Save(Kind obj)
        {
            return _context.Save(obj);
        }
    }
}