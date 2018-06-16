using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class CityService : ICityService
    {
        private IChecker _checker;
        private Data::ICityService _cityRepository;
        public CityService(Data::ICityService cityRepository, IChecker checker)
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

        public void Save(int areaId, City obj)
        {
            _checker.CheckForNull(obj);
            _cityRepository.Save(areaId, obj);
        }
    }
}