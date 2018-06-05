﻿using Callboard.App.Data.DataContext.Main;
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
    internal class UserDbContext : EntityDbContext<User>, IUserContext
    {
        public UserDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
            : base(context, logger, checker) { }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<User> GetAll()
        {
            var procedureName = "sp_select_user";
            var mapper = new Mapper<DataSet, User> { MapCollection = MapUserCollection };
            var users = base.GetAll(procedureName, mapper);
            return users;
        }

        public User GetById(int id)
        {
            var procedureName = "sp_get_user_by_userid";
            var values = new Dictionary<string, object>
            {
                { "UserId", id }
            };
            var mapper = new Mapper<DataSet, User> { MapItem = MapUser };
            var user = base.Get(procedureName, mapper, values);
            return user;
        }

        public void Save(User obj)
        {
            throw new NotImplementedException();
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