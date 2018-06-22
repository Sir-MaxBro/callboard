﻿using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext
{
    public interface IRoleContext : IDataContext<Role>
    {
        IResult<IReadOnlyCollection<Role>> GetRolesForUser(int userId);

        IResult<Role> SetRoleForUser(int userId, int roleId);

        IResult<Role> DeleteUserRole(int userId, int roleId);
    }
}