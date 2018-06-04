using Callboard.App.Business.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Realization
{
    internal class CountryProvider : ICountryProvider
    {
        private IChecker _checker;
        private ICountryRepository _countryRepository;
        public CountryProvider(ICountryRepository countryRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(countryRepository);
            _countryRepository = countryRepository;
        }

        public IReadOnlyCollection<Country> GetCountries()
        {
            return _countryRepository.GetAll();
        }
    }
}