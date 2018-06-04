﻿using Callboard.App.Data.DataProviders.Main;
using Callboard.App.Data.Mappers;
using Callboard.App.Data.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.Repositories.Realizations.Sql
{
    internal class RoleSqlRepository : SqlProvider<Role>, IRoleRepository
    {
        public RoleSqlRepository(ISqlDataProvider<Role> sqlProvider, ILoggerWrapper logger, IChecker checker)
            : base(sqlProvider, logger, checker) { }

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
