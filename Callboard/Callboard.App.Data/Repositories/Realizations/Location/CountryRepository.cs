using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    internal class CountryRepository : EntityRepository, ICountryRepository
    {
        private const string TABLE_NAME = "Country";
        public CountryRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<Country> Items => GetCountries();

        private IReadOnlyCollection<Country> GetCountries()
        {
            throw new NotImplementedException();
        }
    }
}
