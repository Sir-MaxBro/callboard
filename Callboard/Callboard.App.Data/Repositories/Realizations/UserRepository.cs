using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class UserRepository : IRepository<User>
    {
        private IDataContext<User> _context;
        public UserRepository(IDataContext<User> context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IResult<User> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<IReadOnlyCollection<User>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<User> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<User> Save(User obj)
        {
            return _context.Save(obj);
        } 
    }
}