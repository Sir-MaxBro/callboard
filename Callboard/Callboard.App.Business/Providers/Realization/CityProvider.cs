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

        public IReadOnlyCollection<City> GetCitiesByAreaId(int areaId)
        {
            _checker.CheckId(areaId);
            return _cityRepository.GetCitiesByAreaId(areaId);
        }
    }
}
