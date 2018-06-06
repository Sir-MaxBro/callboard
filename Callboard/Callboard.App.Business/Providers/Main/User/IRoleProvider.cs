using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface IRoleProvider : IEntityProvider<Role>
    {
        IReadOnlyCollection<Role> GetRolesForUser(int userId);

        void SetRoleForUser(int userId, int roleId);
    }
}