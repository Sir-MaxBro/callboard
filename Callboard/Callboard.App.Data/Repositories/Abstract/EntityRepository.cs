using Callboard.App.Data.Entities;
using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Extensions;
using Callboard.App.General.Helpers;

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
            Checker.CheckForNull(_table, $"Cannot find table { this.TableName } in Callboard.App.Data.dll.config");
        }

        protected abstract string TableName { get; }

        protected Procedure GetProcedure(string procedureType)
        {
            var procedure = _table.Procedures.FirstOfDefault(item => item.Type == procedureType);
            return procedure;
        }

        protected string GetName(string propertyName)
        {
            string name = _table.Columns.FirstOfDefault(item => item.MapPropertyName.ToLower() == propertyName)?.Name;
            return name;
        }
    }
}
