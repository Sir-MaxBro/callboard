using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
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

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _context.GetAll();
        }

        public User GetById(int id)
        {
            return _context.GetById(id);
        }

        public void Save(User obj)
        {
            _context.Save(obj);
        } 
    }
}