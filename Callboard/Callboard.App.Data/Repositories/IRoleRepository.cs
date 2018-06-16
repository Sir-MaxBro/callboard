﻿using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        IReadOnlyCollection<Role> GetRolesForUser(int userId);

        void SetRoleForUser(int userId, int roleId);

        void DeleteUserRole(int userId, int roleId);
    }
}