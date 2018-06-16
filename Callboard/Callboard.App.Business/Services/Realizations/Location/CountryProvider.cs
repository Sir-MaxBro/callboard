using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class CountryProvider : IEntityService<Country>
    {
        private IChecker _checker;
        private IRepository<Country> _countryRepository;
        public CountryProvider(IRepository<Country> countryRepository, IChecker checker)
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