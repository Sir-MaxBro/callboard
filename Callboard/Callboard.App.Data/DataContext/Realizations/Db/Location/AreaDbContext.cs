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
    internal class AreaDbContext : EntityDbContext<Area>, IAreaContext
    {
        public AreaDbContext(IDbContext context, ILoggerWrapper logger) 
            : base(context, logger) { }

        public IResult<Area> Delete(int id)
        {
            string procedureName = "sp_delete_area_by_id";
            var values = new Dictionary<string, object>
            {
                { "AreaId", id }
            };
            return base.Execute(procedureName, values);
        }

        public IResult<IReadOnlyCollection<Area>> GetAll()
        {
            var procedureName = "sp_select_area";
            var mapper = new Mapper<DataSet, Area> { MapCollection = this.MapAreaCollection };
            return base.GetAll(procedureName, mapper);
        }

        public IResult<IReadOnlyCollection<Area>> GetAreasByCountryId(int countryId)
        {
            var procedureName = "sp_select_area_by_countryid";
            var values = new Dictionary<string, object>
            {
                { "CountryId", countryId }
            };
            var mapper = new Mapper<DataSet, Area> { MapCollection = this.MapAreaCollection };
            return base.GetAll(procedureName, mapper, values);
        }

        public IResult<Area> GetById(int id)
        {
            string procedureName = "sp_get_area_by_id";
            var values = new Dictionary<string, object>
            {
                { "AreaId", id }
            };
            var mapper = new Mapper<DataSet, Area> { MapItem = this.MapArea };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<Area> Save(int countryId, Area obj)
        {
            throw new NotImplementedException();
        }

        private Area MapArea(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapArea).FirstOrDefault();
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