using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class MembershipDbContext : EntityDbContext<MembershipUser>, IMembershipContext
    {
        public MembershipDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
            : base(context, logger, checker) { }

        public IResult<MembershipUser> GetUserByLogin(string login)
        {
            var procedureName = "sp_get_membership_user_by_login";
            var values = new Dictionary<string, object>
            {
                { "Login", login }
            };
            var mapper = new Mapper<DataSet, MembershipUser> { MapItem = MapMembershipUser };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<MembershipUser> ValidateUser(string login, string password)
        {
            var procedureName = "sp_get_membership_user_by_login_password";
            var values = new Dictionary<string, object>
            {
                { "Login", login },
                { "Password", password }
            };
            var mapper = new Mapper<DataSet, MembershipUser> { MapItem = MapMembershipUser };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<MembershipUser> CreateUser(string login, string password)
        {
            var procedureName = "sp_create_membership";
            var values = new Dictionary<string, object>
            {
                { "Login", login },
                { "Password", password }
            };
            var mapper = new Mapper<DataSet, MembershipUser> { MapItem = MapMembershipUser };
            return base.Get(procedureName, mapper, values);
        }

        private MembershipUser MapMembershipUser(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(user =>
            {
                return this.MapMembershipUser(user, dataSet.Tables[1]);
            }).FirstOrDefault();
        }

        private MembershipUser MapMembershipUser(DataRow row, DataTable roles)
        {
            return new MembershipUser
            {
                UserId = row.Field<int>("UserId"),
                Name = row.Field<string>("Name"),
                Roles = this.MapRoleCollection(roles)
            };
        }

        private IReadOnlyCollection<Role> MapRoleCollection(DataTable dataTable)
        {
            return dataTable.AsEnumerable().Select(this.MapRole).ToList();
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