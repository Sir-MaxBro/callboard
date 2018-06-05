using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.DbContext.Main;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class CountryDbContext : EntityDbContext<Country>, ICountryContext
    {
        public CountryDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker) 
            : base(context, logger, checker) { }

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