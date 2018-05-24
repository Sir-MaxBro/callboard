using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface IRoleRepository : IEntityRepository<Role>
    {
        IReadOnlyCollection<Role> GetRolesByUserId(int userId);
    }
}
