using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Results;
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

        public IResult<City> Delete(int id)
        {
            _checker.CheckId(id);
            return _cityRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<City>> GetAll()
        {
            return _cityRepository.GetAll();
        }

        public IResult<City> GetById(int id)
        {
            _checker.CheckId(id);
            return _cityRepository.GetById(id);
        }

        public IResult<IReadOnlyCollection<City>> GetCitiesByAreaId(int areaId)
        {
            _checker.CheckId(areaId);
            return _cityRepository.GetCitiesByAreaId(areaId);
        }

        public IResult<City> Save(int areaId, City obj)
        {
            _checker.CheckForNull(obj);
            return _cityRepository.Save(areaId, obj);
        }
    }
}