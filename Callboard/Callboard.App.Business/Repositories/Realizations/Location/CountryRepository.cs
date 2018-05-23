using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class CountryRepository : ICountryRepository
    {
        private Data::ICountryRepository _repository;
        public CountryRepository()
        {
            _repository = DataContainer.GetInstance<Data::ICountryRepository>();
        }

        public IReadOnlyCollection<Country> GetCountries()
        {
            return _repository.GetCountries();
        }
    }
}
