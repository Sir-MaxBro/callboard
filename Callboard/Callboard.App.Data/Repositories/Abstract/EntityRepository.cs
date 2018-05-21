using Callboard.App.Data.Entities;
using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Extensions;
using Callboard.App.General.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Common;

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

        public IReadOnlyCollection<T> GetEntities<T>(string procedureName, Func<DbDataReader, T> mapper, params object[] values)
        {
            IReadOnlyCollection<T> entities = null;
            using (var context = new DataContext(_connectionString))
            {
                var procedure = this.GetProcedure(procedureName);
                if (procedure != null)
                {
                    IDictionary<string, object> inputValues = null;
                    if (values.Length != 0)
                    {
                        inputValues = new Dictionary<string, object>
                        {
                            { procedure.Params[0], values[0] }
                        };
                    }
                    entities = context.ExecuteProcedure(procedure.ProcedureName, inputValues, mapper);
                }
            }
            return entities;
        }

        public T GetEntity<T>(string procedureName, Func<DbDataReader, T> mapper, params object[] values)
        {
            T entity = default(T);
            using (var context = new DataContext(_connectionString))
            {
                var procedure = this.GetProcedure(procedureName);
                if (procedure != null)
                {
                    IDictionary<string, object> inputValues = null;
                    if (values.Length != 0)
                    {
                        inputValues = new Dictionary<string, object>
                        {
                            { procedure.Params[0], values[0] }
                        };
                    }
                    entity = context.ExecuteProcedure(procedure.ProcedureName, inputValues, mapper).FirstOfDefault();
                }
            }
            return entity;
        }
    }
}
