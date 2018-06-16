using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Services
{
    public interface IRoleService : IEntityService<Role>
    {
        IReadOnlyCollection<Role> GetRolesForUser(int userId);

        void SetRoleForUser(int userId, int roleId);

        void DeleteUserRole(int userId, int roleId);
    }
}