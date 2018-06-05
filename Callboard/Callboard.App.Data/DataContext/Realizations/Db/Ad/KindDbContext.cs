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
    internal class KindDbContext : EntityDbContext<Kind>, IKindContext
    {
        public KindDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker) 
            : base(context, logger, checker) { }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Kind> GetAll()
        {
            string procedureName = "sp_select_kind";
            var mapper = new Mapper<DataSet, Kind> { MapCollection = this.MapKindCollection };
            var kinds = base.GetAll(procedureName, mapper);
            return kinds;
        }

        public Kind GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Kind obj)
        {
            throw new NotImplementedException();
        }

        private IReadOnlyCollection<Kind> MapKindCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapKind).ToList();
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