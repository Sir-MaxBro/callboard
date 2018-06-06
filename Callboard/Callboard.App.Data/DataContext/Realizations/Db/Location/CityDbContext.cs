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
    internal class CityDbContext : EntityDbContext<City>, ICityContext
    {
        public CityDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker)
            : base(context, logger, checker) { }

        public void Delete(int id)
        {
            string procedureName = "sp_delete_city_by_id";
            var values = new Dictionary<string, object>
            {
                { "CityId", id }
            };
            base.Execute(procedureName, values);
        }

        public IReadOnlyCollection<City> GetAll()
        {
            string procedureName = "sp_select_city";
            var mapper = new Mapper<DataSet, City> { MapCollection = this.MapCityCollection };
            var cities = base.GetAll(procedureName, mapper);
            return cities;
        }

        public City GetById(int id)
        {
            string procedureName = "sp_get_city_by_id";
            var values = new Dictionary<string, object>
            {
                { "CityId", id }
            };
            var mapper = new Mapper<DataSet, City> { MapItem = this.MapCity };
            var city = base.Get(procedureName, mapper, values);
            return city;
        }

        public IReadOnlyCollection<City> GetCitiesByAreaId(int areaId)
        {
            var procedureName = "sp_select_city_by_areaid";
            var values = new Dictionary<string, object>
            {
                { "AreaId", areaId }
            };
            var mapper = new Mapper<DataSet, City> { MapCollection = this.MapCityCollection };
            var cities = base.GetAll(procedureName, mapper, values);
            return cities;
        }

        public void Save(City obj)
        {
            throw new NotImplementedException();
        }

        private City MapCity(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapCity).FirstOrDefault();
        }

        private IReadOnlyCollection<City> MapCityCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapCity).ToList();
        }

        private City MapCity(DataRow row)
        {
            return new City
            {
                CityId = row.Field<int>("CityId"),
                Name = row.Field<string>("Name")
            };
        }
    }
}
