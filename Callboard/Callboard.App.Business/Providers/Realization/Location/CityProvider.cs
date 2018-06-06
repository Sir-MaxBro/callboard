using Callboard.App.Business.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Realization
{
    internal class CityProvider : ICityProvider
    {
        private IChecker _checker;
        private ICityRepository _cityRepository;
        public CityProvider(ICityRepository cityRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(cityRepository);
            _cityRepository = cityRepository;
        }

        public void Delete(int id)
        {
            _checker.CheckId(id);
            _cityRepository.Delete(id);
        }

        public IReadOnlyCollection<City> GetAll()
        {
            return _cityRepository.GetAll();
        }

        public City GetById(int id)
        {
            _checker.CheckId(id);
            return _cityRepository.GetById(id);
        }

        public IReadOnlyCollection<City> GetCitiesByAreaId(int areaId)
        {
            _checker.CheckId(areaId);
            return _cityRepository.GetCitiesByAreaId(areaId);
        }

        public void Save(City obj)
        {
            _checker.CheckForNull(obj);
            _cityRepository.Save(obj);
        }
    }
}