using Callboard.App.Data.Entities;
using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using Callboard.App.General.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    public class AdRepository : IAdRepository
    {
        private string _connectionString;
        private const string TABLE_NAME = "Ad";
        private Table _table;
        public AdRepository()
        {
            var configuration = new DataConfiguration();
            _connectionString = configuration.ConnectionString;
            _table = configuration.GetTable(TABLE_NAME);
        }

        public IReadOnlyCollection<Ad> Items => GetAds();

        private IReadOnlyCollection<Ad> GetAds()
        {
            IReadOnlyCollection<Ad> ads = null;
            using (var context = new DataContext(_connectionString))
            {
                Func<DbDataReader, Ad> mapAd = MapAd;
                var procedure = _table.Procedures.FirstOfDefault(item => item.Type == "selectAll");
                if (procedure != null)
                {
                    ads = context.ExecuteProcedure(procedure.ProcedureName, null, mapAd);
                }
            }
            return ads;
        }

        private Ad MapAd(DbDataReader dataReader)
        {
            var columns = _table.Columns;
            Func<string, string> getName = propertyName =>
            {
                string name = columns.FirstOfDefault(item => item.MapPropertyName.ToLower() == propertyName)?.Name;
                return name;
            };

            return new Ad
            {
                AdId = Mapper.MapProperty<int>(dataReader, "AdId", getName),
                Name = Mapper.MapProperty<string>(dataReader, "Name", getName),
                Price = Mapper.MapProperty<decimal>(dataReader, "Price", getName),
                CityId = Mapper.MapProperty<int>(dataReader, "CityId", getName),
                CreationDate = Mapper.MapProperty<DateTime>(dataReader, "CreationDate", getName),
                Kind = Mapper.MapProperty<string>(dataReader, "Kind", getName),
                State = Mapper.MapProperty<string>(dataReader, "State", getName)
            };
        }

        public IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId)
        {
            IReadOnlyCollection<Ad> ads = null;
            using (var context = new DataContext(_connectionString))
            {
                Func<DbDataReader, Ad> mapAd = MapAd;
                var procedure = _table.Procedures.FirstOfDefault(item => item.Type == "selectByCategoryId");
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