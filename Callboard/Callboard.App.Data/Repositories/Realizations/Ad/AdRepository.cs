using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class AdRepository : EntityRepository, IAdRepository
    {
        private const string TABLE_NAME = "Ad";
        public AdRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<Ad> Items => GetAds();

        private IReadOnlyCollection<Ad> GetAds()
        {
            IReadOnlyCollection<Ad> ads = base.GetEntities<Ad>("selectAll", MapAd);
            return ads;
        }

        private Ad MapAd(DbDataReader dataReader)
        {
            return new Ad
            {
                AdId = Mapper.MapProperty<int>(dataReader, "AdId", base.GetName),
                Name = Mapper.MapProperty<string>(dataReader, "Name", base.GetName),
                Price = Mapper.MapProperty<decimal>(dataReader, "Price", base.GetName),
                CityId = Mapper.MapProperty<int>(dataReader, "CityId", base.GetName),
                CreationDate = Mapper.MapProperty<DateTime>(dataReader, "CreationDate", base.GetName),
                Kind = Mapper.MapProperty<string>(dataReader, "Kind", base.GetName),
                State = Mapper.MapProperty<string>(dataReader, "State", base.GetName)
            };
        }

        public IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId)
        {
            IReadOnlyCollection<Ad> ads = base.GetEntities<Ad>("selectByCategoryId", MapAd, categoryId);
            return ads;
        }
    }
}