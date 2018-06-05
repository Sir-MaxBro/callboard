using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.DbContext.Main;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class RoleDbContext : EntityDbContext<Role>, IRoleContext
    {
        public RoleDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
            : base(context, logger, checker) { }

        public void Delete(int id)
        {
            var procedureName = "sp_delete_role_by_id";
            var values = new Dictionary<string, object>
            {
                { "RoleId", id }
            };
            base.Delete(procedureName, values);
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            var procedureName = "sp_select_role";
            var mapper = new Mapper<DataSet, Role> { MapCollection = this.MapRoleCollection };
            var roles = base.GetAll(procedureName, mapper);
            return roles;
        }

        public Role GetById(int id)
        {
            var procedureName = "sp_get_role_by_id";
            var values = new Dictionary<string, object>
            {
                { "RoleId", id }
            };
            var mapper = new Mapper<DataSet, Role> { MapItem = this.MapRole };
            var role = base.Get(procedureName, mapper, values);
            return role;
        }

        public IReadOnlyCollection<Role> GetRolesForUser(int userId)
        {
            var procedureName = "sp_select_role_by_userid";
            var values = new Dictionary<string, object>
            {
                { "UserId", userId }
            };
            var mapper = new Mapper<DataSet, Role> { MapCollection = this.MapRoleCollection };
            var roles = base.GetAll(procedureName, mapper, values);
            return roles;
        }

        public void Save(Role obj)
        {
            var procedureName = "sp_save_role";
            var mapper = new Mapper<DataSet, Role> { MapValues = this.MapRoleValues };
            base.Save(obj, procedureName, mapper);
        }

        private IDictionary<string, object> MapRoleValues(Role role)
        {
            return new Dictionary<string, object>
            {
                { "RoleId", role.RoleId },
                { "Name", role.Name }
            };
        }

        private Role MapRole(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapRole).FirstOrDefault();
        }

        private IReadOnlyCollection<Role> MapRoleCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapRole).ToList();
        }

        private Role MapRole(DataRow row)
        {
            return new Role
            {
                RoleId = row.Field<int>("RoleId"),
                Name = row.Field<string>("Name")
            };
        }
    }
}