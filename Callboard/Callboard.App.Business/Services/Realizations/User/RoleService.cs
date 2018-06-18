using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new NullReferenceException(nameof(roleRepository));
        }

        public IResult<Role> Delete(int id)
        {
            this.CheckId(id);
            return _roleRepository.Delete(id);
        }

        public IResult<Role> DeleteUserRole(int userId, int roleId)
        {
            this.CheckId(userId);
            this.CheckId(roleId);
            return _roleRepository.DeleteUserRole(userId, roleId);
        }

        public IResult<IReadOnlyCollection<Role>> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public IResult<Role> GetById(int id)
        {
            this.CheckId(id);
            return _roleRepository.GetById(id);
        }

        public IResult<IReadOnlyCollection<Role>> GetRolesForUser(int userId)
        {
            this.CheckId(userId);
            return _roleRepository.GetRolesForUser(userId);
        }

        public IResult<Role> Save(Role obj)
        {
            obj = obj ?? throw new NullReferenceException(nameof(obj));
            return _roleRepository.Save(obj);
        }

        public IResult<Role> SetRoleForUser(int userId, int roleId)
        {
            this.CheckId(userId);
            this.CheckId(roleId);
            return _roleRepository.SetRoleForUser(userId, roleId);
        }

        private void CheckId(int id)
        {
            if (id < 1)
            {
                throw new InvalidIdException(nameof(id));
            }
        }
    }
}