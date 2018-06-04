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
    internal class AreaSqlRepository : SqlProvider<Area>, IAreaRepository
    {
        public AreaSqlRepository(ISqlDataProvider<Area> sqlProvider, ILoggerWrapper logger, IChecker checker)
            : base(sqlProvider, logger, checker) { }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Area> GetAll()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Area> GetAreasByCountryId(int countryId)
        {
            var procedureName = "sp_select_area_by_countryid";
            var values = new Dictionary<string, object>
            {
                { "CountryId", countryId }
            };
            var mapper = new Mapper<DataSet, Area> { MapCollection = this.MapAreaCollection };
            var areas = base.GetAll(procedureName, mapper, values);
            return areas;
        }

        public Area GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Area obj)
        {
            throw new NotImplementedException();
        }

        private IReadOnlyCollection<Area> MapAreaCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable()
                .Select(this.MapArea)
                .ToList();
        }

        private Area MapArea(DataRow row)
        {
            return new Area
            {
                AreaId = row.Field<int>("AreaId"),
                Name = row.Field<string>("Name")
            };
        }
    }
}
