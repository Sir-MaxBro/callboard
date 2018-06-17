using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class RoleDbContext : EntityDbContext<Role>, IRoleContext
    {
        public RoleDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
            : base(context, logger, checker) { }

        public IResult<Role> Delete(int id)
        {
            var procedureName = "sp_delete_role_by_id";
            var values = new Dictionary<string, object>
            {
                { "RoleId", id }
            };
            return base.Execute(procedureName, values);
        }

        public IResult<IReadOnlyCollection<Role>> GetAll()
        {
            var procedureName = "sp_select_role";
            var mapper = new Mapper<DataSet, Role> { MapCollection = this.MapRoleCollection };
            return base.GetAll(procedureName, mapper);
        }

        public IResult<Role> GetById(int id)
        {
            var procedureName = "sp_get_role_by_id";
            var values = new Dictionary<string, object>
            {
                { "RoleId", id }
            };
            var mapper = new Mapper<DataSet, Role> { MapItem = this.MapRole };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<IReadOnlyCollection<Role>> GetRolesForUser(int userId)
        {
            var procedureName = "sp_select_role_by_userid";
            var values = new Dictionary<string, object>
            {
                { "UserId", userId }
            };
            var mapper = new Mapper<DataSet, Role> { MapCollection = this.MapRoleCollection };
            return base.GetAll(procedureName, mapper, values);
        }

        public IResult<Role> Save(Role obj)
        {
            var procedureName = "sp_save_role";
            var mapper = new Mapper<DataSet, Role> { MapValues = this.MapRoleValues };
            return base.Save(obj, procedureName, mapper);
        }

        public IResult<Role> SetRoleForUser(int userId, int roleId)
        {
            var procedureName = "sp_set_role_for_user";
            var values = new Dictionary<string, object>
            {
                { "UserId", userId },
                { "RoleId", roleId }
            };
            return base.Execute(procedureName, values);
        }

        public IResult<Role> DeleteUserRole(int userId, int roleId)
        {
            var procedureName = "sp_delete_user_role";
            var values = new Dictionary<string, object>
            {
                { "UserId", userId },
                { "RoleId", roleId }
            };
            return base.Execute(procedureName, values);
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