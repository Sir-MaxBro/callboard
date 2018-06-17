using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IChecker _checker;
        public RoleService(IRoleRepository roleRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(roleRepository);
            _roleRepository = roleRepository;
        }

        public IResult<Role> Delete(int id)
        {
            _checker.CheckId(id);
            return _roleRepository.Delete(id);
        }

        public IResult<Role> DeleteUserRole(int userId, int roleId)
        {
            _checker.CheckId(userId);
            _checker.CheckId(roleId);
            return _roleRepository.DeleteUserRole(userId, roleId);
        }

        public IResult<IReadOnlyCollection<Role>> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public IResult<Role> GetById(int id)
        {
            _checker.CheckId(id);
            return _roleRepository.GetById(id);
        }

        public IResult<IReadOnlyCollection<Role>> GetRolesForUser(int userId)
        {
            _checker.CheckId(userId);
            return _roleRepository.GetRolesForUser(userId);
        }

        public IResult<Role> Save(Role obj)
        {
            _checker.CheckForNull(obj);
            return _roleRepository.Save(obj);
        }

        public IResult<Role> SetRoleForUser(int userId, int roleId)
        {
            _checker.CheckId(userId);
            _checker.CheckId(roleId);
            return _roleRepository.SetRoleForUser(userId, roleId);
        }
    }
}