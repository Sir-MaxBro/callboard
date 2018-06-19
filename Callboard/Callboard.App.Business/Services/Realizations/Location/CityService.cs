using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class CityService : ICityService
    {
        private Data::ICityService _cityRepository;
        public CityService(Data::ICityService cityRepository)
        {
            _cityRepository = cityRepository ?? throw new NullReferenceException(nameof(cityRepository));
        }

        public IResult<City> Delete(int id)
        {
            this.CheckId(id);
            return _cityRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<City>> GetAll()
        {
            return _cityRepository.GetAll();
        }

        public IResult<City> GetById(int id)
        {
            this.CheckId(id);
            return _cityRepository.GetById(id);
        }

        public IResult<IReadOnlyCollection<City>> GetCitiesByAreaId(int areaId)
        {
            this.CheckId(areaId);
            return _cityRepository.GetCitiesByAreaId(areaId);
        }

        public IResult<City> Save(int areaId, City obj)
        {
            obj = obj ?? throw new NullReferenceException(nameof(obj));
            return _cityRepository.Save(areaId, obj);
        }

        private void CheckId(int id)
        {
            if (id < 1)
            {
                throw new InvalidIdException(nameof(id));
            }
        }
    }
}