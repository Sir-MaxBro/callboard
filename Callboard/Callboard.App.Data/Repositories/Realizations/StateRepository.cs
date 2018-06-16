using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class StateRepository : IRepository<State>
    {
        private IDataContext<State> _context;
        public StateRepository(IDataContext<State> context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<State> GetAll()
        {
            return _context.GetAll();
        }

        public State GetById(int id)
        {
            return _context.GetById(id);
        }

        public void Save(State obj)
        {
            _context.Save(obj);
        }
    }
}