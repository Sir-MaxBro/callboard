using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.DbContext.Main;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
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
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Role> GetRolesForUser(int userId)
        {
            var procedureName = "sp_select_role_by_userid";
            var values = new Dictionary<string, object>
            {
                { "UserId", userId }
            };
            var mapper = new Mapper<DataSet, Role>
            {
                MapCollection = MapRoleCollection
            };
            var roles = base.GetAll(procedureName, mapper, values);
            return roles;
        }

        public void Save(Role obj)
        {
            throw new NotImplementedException();
        }

        private IReadOnlyCollection<Role> MapRoleCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable()
                .Select(this.MapRole)
                .ToList();
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