using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class CountryDbContext : EntityDbContext<Country>, IDataContext<Country>
    {
        public CountryDbContext(IDbContext context, ILoggerWrapper logger)
            : base(context, logger) { }

        public IResult<Country> Delete(int id)
        {
            string procedureName = "sp_delete_country_by_id";
            var values = new Dictionary<string, object>
            {
                { "CountryId", id }
            };
            return base.Execute(procedureName, values);
        }

        public IResult<IReadOnlyCollection<Country>> GetAll()
        {
            string procedureName = "sp_select_country";
            var mapper = new Mapper<DataSet, Country> { MapCollection = MapCountryCollection };
            return base.GetAll(procedureName, mapper);
        }

        public IResult<Country> GetById(int id)
        {
            string procedureName = "sp_get_country_by_id";
            var values = new Dictionary<string, object>
            {
                { "CountryId", id }
            };
            var mapper = new Mapper<DataSet, Country> { MapItem = MapCountry };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<Country> Save(Country obj)
        {
            string procedureName = "sp_save_country";
            var mapper = new Mapper<DataSet, Country> { MapValues = MapCountryValues };
            return base.Save(obj, procedureName, mapper);
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