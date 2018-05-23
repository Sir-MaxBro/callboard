using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class PhoneRepository : EntityRepository, IPhoneRepository
    {
        private const string TABLE_NAME = "Phone";
        public PhoneRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<Phone> GetPhonesByUserId(int userId)
        {
            IReadOnlyCollection<Phone> phones = base.GetEntities<Phone>("selectByUserId", MapPhone, userId);
            return phones;
        }

        private Phone MapPhone(DbDataReader reader)
        {
            return new Phone
            {
                UserId = Mapper.MapProperty<int>(reader, "UserId", base.GetName),
                PhoneId = Mapper.MapProperty<int>(reader, "PhoneId", base.GetName),
                Number = Mapper.MapProperty<string>(reader, "Number", base.GetName)
            };
        }
    }
}
