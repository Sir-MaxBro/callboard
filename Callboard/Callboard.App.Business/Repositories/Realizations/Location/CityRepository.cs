using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class CityRepository : ICityRepository
    {
        private Data::ICityRepository _repository;
        public CityRepository()
        {
            _repository = DataContainer.GetInstance<Data::ICityRepository>();
        }

        public IReadOnlyCollection<City> Items
        {
            get => _repository.Items;
        }

        public IReadOnlyCollection<City> GetCitiesByAreaId(int areaId)
        {
            return _repository.GetCitiesByAreaId(areaId);
        }
    }
}
