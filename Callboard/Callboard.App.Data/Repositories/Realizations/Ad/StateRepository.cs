using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class StateRepository : IStateRepository
    {
        private IStateContext _context;
        public StateRepository(IStateContext context)
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