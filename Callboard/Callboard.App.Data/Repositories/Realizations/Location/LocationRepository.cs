using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class LocationRepository : EntityRepository, ILocationRepository
    {
        private const string TABLE_NAME = "Location";
        public LocationRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<Location> Items => throw new NotImplementedException();

        public Location GetLocationByCityId(int cityId)
        {
            Location location = base.GetEntity<Location>("getLocationByCityId", MapLocation, cityId);
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
