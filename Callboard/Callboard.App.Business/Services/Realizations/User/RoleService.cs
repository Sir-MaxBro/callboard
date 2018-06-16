using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
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

        public void Delete(int id)
        {
            _checker.CheckId(id);
            _roleRepository.Delete(id);
        }

        public void DeleteUserRole(int userId, int roleId)
        {
            _checker.CheckId(userId);
            _checker.CheckId(roleId);
            _roleRepository.DeleteUserRole(userId, roleId);
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Role GetById(int id)
        {
            _checker.CheckId(id);
            return _roleRepository.GetById(id);
        }

        public IReadOnlyCollection<Role> GetRolesForUser(int userId)
        {
            _checker.CheckId(userId);
            return _roleRepository.GetRolesForUser(userId);
        }

        public void Save(Role obj)
        {
            _checker.CheckForNull(obj);
            _roleRepository.Save(obj);
        }

        public void SetRoleForUser(int userId, int roleId)
        {
            _checker.CheckId(userId);
            _checker.CheckId(roleId);
            _roleRepository.SetRoleForUser(userId, roleId);
        }
    }
}