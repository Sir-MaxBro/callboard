using Callboard.App.Data.DataProviders.Main;
using Callboard.App.Data.Mappers;
using Callboard.App.Data.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.Repositories.Realizations.Sql
{
    internal class CountrySqlRepository : SqlProvider<Country>, ICountryRepository
    {
        public CountrySqlRepository(ISqlDataProvider<Country> sqlProvider, ILoggerWrapper logger, IChecker checker)
            : base(sqlProvider, logger, checker) { }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Country> GetAll()
        {
            var procedureName = "sp_select_country";
            var mapper = new Mapper<DataSet, Country> { MapCollection = MapCountryCollection };
            var countries = base.GetAll(procedureName, mapper);
            return countries;
        }

        public Country GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Country obj)
        {
            throw new NotImplementedException();
        }

        private IReadOnlyCollection<Country> MapCountryCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable()
                .Select(this.MapCountry)
                .ToList();
        }

        private Country MapCountry(DataRow row)
        {
            return new Country
            {
                CountryId = row.Field<int>("CountryId"),
                Name = row.Field<string>("Name")
            };
        }
    }
}
