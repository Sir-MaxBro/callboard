using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class AdDetailsRepository : EntityRepository, IAdDetailsRepository
    {
        private const string TABLE_NAME = "AdDetails";
        public AdDetailsRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<AdDetails> Items => throw new NotImplementedException();

        public AdDetails GetAdDetails(int adId)
        {
            AdDetails adDetails = base.GetEntity<AdDetails>("getById", MapAdDetails, adId);
            return adDetails;
        }

        private AdDetails MapAdDetails(DbDataReader dataReader)
        {
            return new AdDetails
            {
                AdId = Mapper.MapProperty<int>(dataReader, "AdId", base.GetName),
                Name = Mapper.MapProperty<string>(dataReader, "Name", base.GetName),
                Price = Mapper.MapProperty<decimal>(dataReader, "Price", base.GetName),
                CityId = Mapper.MapProperty<int>(dataReader, "CityId", base.GetName),
                CreationDate = Mapper.MapProperty<DateTime>(dataReader, "CreationDate", base.GetName),
                Kind = Mapper.MapProperty<string>(dataReader, "Kind", base.GetName),
                State = Mapper.MapProperty<string>(dataReader, "State", base.GetName),
                AddressLine = Mapper.MapProperty<string>(dataReader, "AddressLine", base.GetName),
                Description = Mapper.MapProperty<string>(dataReader, "Description", base.GetName),
                UserId = Mapper.MapProperty<int>(dataReader, "UserId", base.GetName)
            };
        }
    }
}
