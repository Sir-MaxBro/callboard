using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class CountryDbContext : EntityDbContext<Country>, IDataContext<Country>
    {
        public CountryDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
            : base(context, logger, checker) { }

        public void Delete(int id)
        {
            string procedureName = "sp_delete_country_by_id";
            var values = new Dictionary<string, object>
            {
                { "CountryId", id }
            };
            base.Execute(procedureName, values);
        }

        public IReadOnlyCollection<Country> GetAll()
        {
            string procedureName = "sp_select_country";
            var mapper = new Mapper<DataSet, Country> { MapCollection = MapCountryCollection };
            var countries = base.GetAll(procedureName, mapper);
            return countries;
        }

        public Country GetById(int id)
        {
            string procedureName = "sp_get_country_by_id";
            var values = new Dictionary<string, object>
            {
                { "CountryId", id }
            };
            var mapper = new Mapper<DataSet, Country> { MapItem = MapCountry };
            var country = base.Get(procedureName, mapper, values);
            return country;
        }

        public void Save(Country obj)
        {
            string procedureName = "sp_save_country";
            var mapper = new Mapper<DataSet, Country> { MapValues = MapCountryValues };
            base.Save(obj, procedureName, mapper);
        }

        private IDictionary<string, object> MapCountryValues(Country country)
        {
            return new Dictionary<string, object>
            {
                { "CountryId", country.CountryId },
                { "Name", country.Name }
            };
        }

        private Country MapCountry(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapCountry).FirstOrDefault();
        }

        private IReadOnlyCollection<Country> MapCountryCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapCountry).ToList();
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