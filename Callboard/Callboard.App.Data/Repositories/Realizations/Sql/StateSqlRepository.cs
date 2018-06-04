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
    internal class StateSqlRepository : SqlProvider<State>, IStateRepository
    {
        public StateSqlRepository(ISqlDataProvider<State> sqlProvider, ILoggerWrapper logger, IChecker checker)
            : base(sqlProvider, logger, checker) { }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<State> GetAll()
        {
            string procedureName = "sp_select_state";
            var mapper = new Mapper<DataSet, State> { MapCollection = this.MapStateCollection };
            var states = base.GetAll(procedureName, mapper);
            return states;
        }

        public State GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(State obj)
        {
            throw new NotImplementedException();
        }

        private IReadOnlyCollection<State> MapStateCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapState).ToList();
        }

        private State MapState(DataRow row)
        {
            return new State
            {
                StateId = row.Field<int>("StateId"),
                Condition = row.Field<string>("Condition")
            };
        }
    }
}
