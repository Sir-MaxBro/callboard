using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class AreaRepository : IAreaRepository
    {
        private Data::IAreaRepository _repository;
        public AreaRepository()
        {
            _repository = DataContainer.GetInstance<Data::IAreaRepository>();
        }

        public IReadOnlyCollection<Area> GetAreasByCountryId(int countryId)
        {
            return _repository.GetAreasByCountryId(countryId);
        }
    }
}
