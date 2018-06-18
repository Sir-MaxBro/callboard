using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class AreaService : IAreaService
    {
        private Data::IAreaService _areaRepository;
        public AreaService(Data::IAreaService areaRepository)
        {
            _areaRepository = areaRepository ?? throw new NullReferenceException(nameof(areaRepository));
        }

        public IResult<Area> Delete(int id)
        {
            this.CheckId(id);
            return _areaRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<Area>> GetAll()
        {
            return _areaRepository.GetAll();
        }

        public IResult<IReadOnlyCollection<Area>> GetAreasByCountryId(int countryId)
        {
            this.CheckId(countryId);
            return _areaRepository.GetAreasByCountryId(countryId);
        }

        public IResult<Area> GetById(int id)
        {
            this.CheckId(id);
            return _areaRepository.GetById(id);
        }

        public IResult<Area> Save(int countryId, Area obj)
        {
            this.CheckId(countryId);
            obj = obj ?? throw new NullReferenceException(nameof(obj));
            return _areaRepository.Save(countryId, obj);
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