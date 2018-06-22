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
    internal class StateDbContext : EntityDbContext<State>, IDataContext<State>
    {
        public StateDbContext(IDbContext context, ILoggerWrapper logger)
            : base(context, logger) { }

        public IResult<State> Delete(int id)
        {
            string procedureName = "sp_delete_state_by_id";
            var values = new Dictionary<string, object>
            {
                { "StateId", id }
            };
            return base.Execute(procedureName, values);
        }

        public IResult<IReadOnlyCollection<State>> GetAll()
        {
            string procedureName = "sp_select_state";
            var mapper = new Mapper<DataSet, State> { MapCollection = this.MapStateCollection };
            return base.GetAll(procedureName, mapper);
        }

        public IResult<State> GetById(int id)
        {
            string procedureName = "sp_get_state_by_id";
            var mapper = new Mapper<DataSet, State> { MapItem = this.MapState };
            var values = new Dictionary<string, object>
            {
                { "StateId", id }
            };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<State> Save(State obj)
        {
            string procedureName = "sp_save_state";
            var mapper = new Mapper<DataSet, State> { MapValues = this.MapStateValues };
            return base.Save(obj, procedureName, mapper);
        }

        private IDictionary<string, object> MapStateValues(State state)
        {
            return new Dictionary<string, object>
            {
                { "StateId", state.StateId },
                { "Condition", state.Condition }
            };
        }

        private State MapState(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(this.MapState).FirstOrDefault();
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