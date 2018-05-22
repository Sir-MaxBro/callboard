using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class CityRepository : EntityRepository, ICityRepository
    {
        private const string TABLE_NAME = "City";
        public CityRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<City> Items => throw new NotImplementedException();

        public City GetCity(int cityId)
        {
            City city = base.GetEntity<City>("getById", MapCity, cityId);
            return city;
        }

        private City MapCity(DbDataReader reader)
        {
            return new City
            {
                CityId = Mapper.MapProperty<int>(reader, "CityId", base.GetName),
                AreaId = Mapper.MapProperty<int>(reader, "AreaId", base.GetName),
                Name = Mapper.MapProperty<string>(reader, "Name", base.GetName)
            };
        }
    }
}
