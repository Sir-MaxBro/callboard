using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class UserDbContext : EntityDbContext<User>, IDataContext<User>
    {
        public UserDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
            : base(context, logger, checker) { }

        public void Delete(int id)
        {
            string procedureName = "sp_delete_user_by_id";
            var values = new Dictionary<string, object>
            {
                { "UserId", id }
            };
            base.Execute(procedureName, values);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            string procedureName = "sp_select_user";
            var mapper = new Mapper<DataSet, User> { MapCollection = this.MapUserCollection };
            var users = base.GetAll(procedureName, mapper);
            return users;
        }

        public User GetById(int id)
        {
            string procedureName = "sp_get_user_by_userid";
            var values = new Dictionary<string, object>
            {
                { "UserId", id }
            };
            var mapper = new Mapper<DataSet, User> { MapItem = this.MapUser };
            var user = base.Get(procedureName, mapper, values);
            return user;
        }

        public void Save(User obj)
        {
            string procedureName = "sp_save_user";
            var mapper = new Mapper<DataSet, User> { MapValues = this.MapUserValues };
            base.Save(obj, procedureName, mapper);
        }

        private IDictionary<string, object> MapUserValues(User user)
        {
            return new Dictionary<string, object>
            {
                { "UserId", user.UserId },
                { "Name", user.Name },
                { "PhotoData", user.PhotoData },
                { "PhotoExtension", user.PhotoExtension },
                { "Phones", this.GetPhoneRecords(user.Phones) },
                { "Mails", this.GetMailRecords(user.Mails) }
            };
        }

        private IReadOnlyCollection<SqlDataRecord> GetMailRecords(IReadOnlyCollection<Mail> mails)
        {
            if (mails == null || mails?.Count < 1)
            {
                return null;
            }
            var records = new List<SqlDataRecord>();
            var metadata = new SqlMetaData[]
            {
                new SqlMetaData("MailId", SqlDbType.Int),
                new SqlMetaData("Email", SqlDbType.NVarChar, -1)
            };
            foreach (var item in mails)
            {
                SqlDataRecord record = new SqlDataRecord(metadata);
                record.SetValue(0, item.MailId);
                record.SetValue(1, item.Email);
                records.Add(record);
            }
            return records;
        }

        private IReadOnlyCollection<SqlDataRecord> GetPhoneRecords(IReadOnlyCollection<Phone> phones)
        {
            if (phones == null || phones?.Count < 1)
            {
                return null;
            }
            var records = new List<SqlDataRecord>();
            var metadata = new SqlMetaData[]
            {
                new SqlMetaData("PhoneId", SqlDbType.Int),
                new SqlMetaData("Number", SqlDbType.NVarChar, 50)
            };
            foreach (var item in phones)
            {
                SqlDataRecord record = new SqlDataRecord(metadata);
                record.SetValue(0, item.PhoneId);
                record.SetValue(1, item.Number);
                records.Add(record);
            }
            return records;
        }

        private User MapUser(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(user =>
            {
                return MapUser(user, dataSet.Tables[1], dataSet.Tables[2]);
            }).FirstOrDefault();
        }

        private IReadOnlyCollection<User> MapUserCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(user =>
            {
                return MapUser(user, dataSet.Tables[1], dataSet.Tables[2]);
            }).ToList();
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
            return phones.AsEnumerable()
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
            return mails.AsEnumerable()
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