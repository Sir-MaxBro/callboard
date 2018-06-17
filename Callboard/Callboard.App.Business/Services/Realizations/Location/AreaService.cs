using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class AreaService : IAreaService
    {
        private Data::IAreaService _areaRepository;
        private IChecker _checker;
        public AreaService(Data::IAreaService areaRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(areaRepository);
            _areaRepository = areaRepository;
        }

        public IResult<Area> Delete(int id)
        {
            _checker.CheckId(id);
            return _areaRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<Area>> GetAll()
        {
            return _areaRepository.GetAll();
        }

        public IResult<IReadOnlyCollection<Area>> GetAreasByCountryId(int countryId)
        {
            _checker.CheckId(countryId);
            return _areaRepository.GetAreasByCountryId(countryId);
        }

        public IResult<Area> GetById(int id)
        {
            _checker.CheckId(id);
            return _areaRepository.GetById(id);
        }

        public IResult<Area> Save(int countryId, Area obj)
        {
            _checker.CheckForNull(obj);
            return _areaRepository.Save(countryId, obj);
        }
    }
}