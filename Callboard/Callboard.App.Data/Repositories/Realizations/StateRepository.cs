using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
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

        public IResult<State> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<IReadOnlyCollection<State>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<State> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<State> Save(State obj)
        {
            return _context.Save(obj);
        }
    }
}