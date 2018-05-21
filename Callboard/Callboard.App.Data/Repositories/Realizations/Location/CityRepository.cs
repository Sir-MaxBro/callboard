using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class CityRepository : EntityRepository, ICityRepository
    {
        private const string TABLE_NAME = "City";
        public CityRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<City> Items => throw new NotImplementedException();

        public Location GetLocationByCityId(int cityId)
        {
            Location location = base.GetEntity<Location>("getLocationById", MapLocation, cityId);
            return location;
        }

        private Location MapLocation(DbDataReader reader)
        {
            return new Location
            {
                Area = Mapper.MapProperty<string>(reader, "Area", base.GetName),
                City = Mapper.MapProperty<string>(reader, "City", base.GetName),
                Country = Mapper.MapProperty<string>(reader, "Country", base.GetName)
            };
        }
    }
}
