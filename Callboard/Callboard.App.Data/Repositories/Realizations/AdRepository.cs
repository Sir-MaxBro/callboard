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
            IReadOnlyCollection<Ad> ads = null;
            using (var context = new DataContext(_connectionString))
            {
                Func<DbDataReader, Ad> mapAd = MapAd;
                var procedure = base.GetProcedure("selectAll");
                if (procedure != null)
                {
                    ads = context.ExecuteProcedure(procedure.ProcedureName, null, mapAd);
                }
            }
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
            IReadOnlyCollection<Ad> ads = null;
            using (var context = new DataContext(_connectionString))
            {
                Func<DbDataReader, Ad> mapAd = MapAd;
                var procedure = base.GetProcedure("selectByCategoryId");
                if (procedure != null)
                {
                    IDictionary<string, object> values = new Dictionary<string, object>
                    {
                        { procedure.Params[0], categoryId }
                    };

                    ads = context.ExecuteProcedure(procedure.ProcedureName, values, mapAd);
                }
            }
            return ads;
        }
    }
}