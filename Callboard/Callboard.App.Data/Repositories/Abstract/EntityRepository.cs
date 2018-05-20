using Callboard.App.Data.Entities;
using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Extensions;

namespace Callboard.App.Data.Repositories
{
    internal abstract class EntityRepository
    {
        protected string _connectionString;
        protected Table _table;
        public EntityRepository()
        {
            var configuration = new DataConfiguration();
            _connectionString = configuration.ConnectionString;
            _table = configuration.GetTable(this.TableName);
        }

        protected abstract string TableName { get; }

        protected Procedure GetProcedure(string procedureType)
        {
            var procedure = _table.Procedures.FirstOfDefault(item => item.Type == procedureType);
            return procedure;
        }

        protected string GetName(string propertyName)
        {
            var columns = _table.Columns;
            string name = columns.FirstOfDefault(item => item.MapPropertyName.ToLower() == propertyName)?.Name;
            return name;
        }
    }
}
