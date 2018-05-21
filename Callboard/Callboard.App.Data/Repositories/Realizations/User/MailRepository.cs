using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class MailRepository : EntityRepository, IMailRepository
    {
        private const string TABLE_NAME = "Mail";
        public MailRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<Mail> Items => throw new NotImplementedException();

        public IReadOnlyCollection<Mail> GetMailsByUserId(int userId)
        {
            IReadOnlyCollection<Mail> mails = base.GetEntities<Mail>("selectByUserId", MapMail, userId);
            return mails;
        }

        private Mail MapMail(DbDataReader reader)
        {
            return new Mail
            {
                MailId = Mapper.MapProperty<int>(reader, "MailId", base.GetName),
                UserId = Mapper.MapProperty<int>(reader, "UserId", base.GetName),
                Email = Mapper.MapProperty<string>(reader, "Email", base.GetName)
            };
        }
    }
}
