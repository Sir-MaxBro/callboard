using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext.Main
{
    public interface IRoleContext : IDataContext<Role>
    {
        IReadOnlyCollection<Role> GetRolesForUser(int userId);

        void SetRoleForUser(int userId, int roleId);
    }
}