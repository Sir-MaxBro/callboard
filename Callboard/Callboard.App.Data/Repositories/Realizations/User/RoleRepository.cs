using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class RoleRepository : EntityRepository, IRoleRepository
    {
        private const string TABLE_NAME = "Role";
        public RoleRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<Role> GetRolesByUserId(int userId)
        {
            IReadOnlyCollection<Role> roles = base.GetEntities<Role>("selectByUserId", MapRole, userId);
            return roles;
        }

        private Role MapRole(DbDataReader reader)
        {
            return new Role
            {
                RoleId = Mapper.MapProperty<int>(reader, "RoleId", base.GetName),
                Name = Mapper.MapProperty<string>(reader, "Name", base.GetName)
            };
        }
    }
}
