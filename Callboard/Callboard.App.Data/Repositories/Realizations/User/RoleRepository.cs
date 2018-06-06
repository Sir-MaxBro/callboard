using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class RoleRepository : IRoleRepository
    {
        private IRoleContext _context; 
        public RoleRepository(IRoleContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            return _context.GetAll();
        }

        public Role GetById(int id)
        {
            return _context.GetById(id);
        }

        public IReadOnlyCollection<Role> GetRolesForUser(int userId)
        {
            return _context.GetRolesForUser(userId);
        }

        public void Save(Role obj)
        {
            _context.Save(obj);
        }

        public void SetRoleForUser(int userId, int roleId)
        {
            _context.SetRoleForUser(userId, roleId);
        }
    }
}