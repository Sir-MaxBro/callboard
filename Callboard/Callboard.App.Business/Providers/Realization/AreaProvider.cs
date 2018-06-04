using Callboard.App.Business.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Realization
{
    internal class AreaProvider : IAreaProvider
    {
        private IAreaRepository _areaRepository;
        private IChecker _checker;
        public AreaProvider(IAreaRepository areaRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(areaRepository);
            _areaRepository = areaRepository;
        }

        public IReadOnlyCollection<Area> GetAreasByCountryId(int countryId)
        {
            _checker.CheckId(countryId);
            return _areaRepository.GetAreasByCountryId(countryId);
        }
    }
}
