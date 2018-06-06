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

        public void Delete(int id)
        {
            _checker.CheckId(id);
            _countryRepository.Delete(id);
        }

        public IReadOnlyCollection<Country> GetAll()
        {
            return _countryRepository.GetAll();
        }

        public Country GetById(int id)
        {
            _checker.CheckId(id);
            return _countryRepository.GetById(id);
        }

        public void Save(Country obj)
        {
            _checker.CheckForNull(obj);
            _countryRepository.Save(obj);
        }
    }
}