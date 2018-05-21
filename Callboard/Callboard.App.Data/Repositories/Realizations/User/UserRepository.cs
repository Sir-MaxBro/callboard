using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class UserRepository : EntityRepository, IUserRepository
    {
        private const string TABLE_NAME = "User";
        public UserRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<User> Items => throw new NotImplementedException();

        public User GetUserById(int userId)
        {
            User user = base.GetEntity<User>("getById", MapUser, userId);
            return user;
        }

        private User MapUser(DbDataReader reader)
        {
            return new User
            {
                UserId = Mapper.MapProperty<int>(reader, "UserId", base.GetName),
                Name = Mapper.MapProperty<string>(reader, "Name", base.GetName),
                PhotoData = Mapper.MapProperty<byte[]>(reader, "PhotoData", base.GetName),
                PhotoMimeType = Mapper.MapProperty<string>(reader, "PhotoMimeType", base.GetName)
            };
        }
    }
}
