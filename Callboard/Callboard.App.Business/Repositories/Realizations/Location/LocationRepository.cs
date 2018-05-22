using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class LocationRepository : ILocationRepository
    {
        private Data::ILocationRepository _repository;
        public LocationRepository()
        {
            _repository = DataContainer.GetInstance<Data::ILocationRepository>();
        }

        public IReadOnlyCollection<Location> Items => throw new NotImplementedException();

        public Location GetLocationByCityId(int cityId)
        {
            return _repository.GetLocationByCityId(cityId);
        }
    }
}
