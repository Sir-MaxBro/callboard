using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class MembershipDbContext : EntityDbContext<User>, IMembershipContext
    {
        public MembershipDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
            : base(context, logger, checker) { }

        public User GetUserByLogin(string login)
        {
            var procedureName = "sp_get_user_by_login";
            var values = new Dictionary<string, object>
            {
                { "Login", login }
            };
            var mapper = new Mapper<DataSet, User>
            {
                MapItem = MapUser
            };
            var user = base.Get(procedureName, mapper, values);
            return user;
        }

        public bool ValidateUser(string login, string password)
        {
            var procedureName = "sp_get_user_by_login_password";
            var values = new Dictionary<string, object>
            {
                { "Login", login },
                { "Password", password }
            };
            var mapper = new Mapper<DataSet, User> { MapItem = MapUserMin };
            var user = base.Get(procedureName, mapper, values);
            return user != null ? true : false;
        }

        public User CreateUser(string login, string password)
        {
            var procedureName = "sp_create_membership";
            var values = new Dictionary<string, object>
            {
                { "Login", login },
                { "Password", password }
            };
            var mapper = new Mapper<DataSet, User> { MapItem = MapUser };
            var user = base.Get(procedureName, mapper, values);
            return user;
        }

        private User MapUserMin(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(user =>
            {
                return MapUser(user, null, null);
            }).FirstOrDefault();
        }

        private User MapUser(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(user =>
            {
                return MapUser(user, dataSet.Tables[1], dataSet.Tables[2]);
            }).FirstOrDefault();
        }

        private User MapUser(DataRow row, DataTable mails, DataTable phones)
        {
            int userId = row.Field<int>("UserId");
            return new User
            {
                UserId = userId,
                Name = row.Field<string>("Name"),
                PhotoData = row.Field<byte[]>("PhotoData"),
                PhotoExtension = row.Field<string>("PhotoExtension"),
                Mails = this.MapMailCollection(mails, userId),
                Phones = this.MapPhoneCollection(phones, userId)
            };
        }

        private IReadOnlyCollection<Phone> MapPhoneCollection(DataTable phones, int userId)
        {
            return phones?.AsEnumerable()
                        .Where(phone => phone.Field<int>("UserId") == userId)
                        .Select(phone =>
                        {
                            return new Phone
                            {
                                PhoneId = phone.Field<int>("PhoneId"),
                                Number = phone.Field<string>("Number")
                            };
                        }).ToList();
        }

        private IReadOnlyCollection<Mail> MapMailCollection(DataTable mails, int userId)
        {
            return mails?.AsEnumerable()
                        .Where(mail => mail.Field<int>("UserId") == userId)
                        .Select(mail =>
                        {
                            return new Mail
                            {
                                MailId = mail.Field<int>("MailId"),
                                Email = mail.Field<string>("Email")
                            };
                        }).ToList();
        }
    }
}