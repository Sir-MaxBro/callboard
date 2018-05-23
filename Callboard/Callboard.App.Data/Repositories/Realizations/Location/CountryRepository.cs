using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using System.Data.Common;

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
            IReadOnlyCollection<Country> countries = base.GetEntities<Country>("selectAll", MapCountry);
            return countries;
        }

        private Country MapCountry(DbDataReader reader)
        {
            return new Country
            {
                CountryId = Mapper.MapProperty<int>(reader, "CountryId", base.GetName),
                Name = Mapper.MapProperty<string>(reader, "Name", base.GetName)
            };
        }
    }
}
