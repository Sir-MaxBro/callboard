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

        private City MapCity(DbDataReader reader)
        {
            return new City
            {
                CityId = Mapper.MapProperty<int>(reader, "CityId", base.GetName),
                AreaId = Mapper.MapProperty<int>(reader, "AreaId", base.GetName),
                Name = Mapper.MapProperty<string>(reader, "Name", base.GetName)
            };
        }

        public IReadOnlyCollection<City> GetCitiesByAreaId(int areaId)
        {
            IReadOnlyCollection<City> cities = base.GetEntities<City>("selectByAreaId", MapCity, areaId);
            return cities;
        }
    }
}
