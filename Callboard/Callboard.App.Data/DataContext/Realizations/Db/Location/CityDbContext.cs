using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class CityDbContext : EntityDbContext<City>, ICityContext
    {
        public CityDbContext(IDbContext context, ILoggerWrapper logger)
            : base(context, logger) { }

        public IResult<City> Delete(int id)
        {
            string procedureName = "sp_delete_city_by_id";
            var values = new Dictionary<string, object>
            {
                { "CityId", id }
            };
            return base.Execute(procedureName, values);
        }

        public IResult<IReadOnlyCollection<City>> GetAll()
        {
            string procedureName = "sp_select_city";
            var mapper = new Mapper<DataSet, City> { MapCollection = this.MapCityCollection };
            return base.GetAll(procedureName, mapper);
        }

        public IResult<City> GetById(int id)
        {
            string procedureName = "sp_get_city_by_id";
            var values = new Dictionary<string, object>
            {
                { "CityId", id }
            };
            var mapper = new Mapper<DataSet, City> { MapItem = this.MapCity };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<IReadOnlyCollection<City>> GetCitiesByAreaId(int areaId)
        {
            var procedureName = "sp_select_city_by_areaid";
            var values = new Dictionary<string, object>
            {
                { "AreaId", areaId }
            };
            var mapper = new Mapper<DataSet, City> { MapCollection = this.MapCityCollection };
            return base.GetAll(procedureName, mapper, values);
        }

        public IResult<City> Save(int areaId, City obj)
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