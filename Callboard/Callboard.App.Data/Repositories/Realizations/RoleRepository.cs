using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
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

        public IResult<Role> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<Role> DeleteUserRole(int userId, int roleId)
        {
            return _context.DeleteUserRole(userId, roleId);
        }

        public IResult<IReadOnlyCollection<Role>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<Role> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<IReadOnlyCollection<Role>> GetRolesForUser(int userId)
        {
            return _context.GetRolesForUser(userId);
        }

        public IResult<Role> Save(Role obj)
        {
            return _context.Save(obj);
        }

        public IResult<Role> SetRoleForUser(int userId, int roleId)
        {
            return _context.SetRoleForUser(userId, roleId);
        }
    }
}