﻿using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class KindDbContext : EntityDbContext<Kind>, IDataContext<Kind>
    {
        public KindDbContext(IDbContext context, ILoggerWrapper logger)
            : base(context, logger) { }

        public IResult<Kind> Delete(int id)
        {
            string procedureName = "sp_delete_kind_by_id";
            var values = new Dictionary<string, object>
            {
                { "KindId", id }
            };
            return base.Execute(procedureName, values);
        }

        public IResult<IReadOnlyCollection<Kind>> GetAll()
        {
            string procedureName = "sp_select_kind";
            var mapper = new Mapper<DataSet, Kind> { MapCollection = this.MapKindCollection };
            return base.GetAll(procedureName, mapper);
        }

        public IResult<Kind> GetById(int id)
        {
            string procedureName = "sp_get_kind_by_id";
            var mapper = new Mapper<DataSet, Kind> { MapItem = this.MapKind };
            var values = new Dictionary<string, object>
            {
                { "KindId", id }
            };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<Kind> Save(Kind obj)
        {
            string procedureName = "sp_save_kind";
            var mapper = new Mapper<DataSet, Kind> { MapValues = this.MapKindValues };
            return base.Save(obj, procedureName, mapper);
        }

        private IDictionary<string, object> MapKindValues(Kind kind)
        {
            return new Dictionary<string, object>
            {
                { "KindId", kind.KindId },
                { "Type", kind.Type }
            };
        }

        private IReadOnlyCollection<Kind> MapKindCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapKind).ToList();
        }

        private Kind MapKind(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapKind).FirstOrDefault();
        }

        private Kind MapKind(DataRow row)
        {
            return new Kind
            {
                KindId = row.Field<int>("KindId"),
                Type = row.Field<string>("Type")
            };
        }
    }
}