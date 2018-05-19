using Callboard.App.Data.Config.Elements;
using Callboard.App.Data.Config.Main;
using Callboard.App.Data.Config.Sections;
using Callboard.App.Data.Entities;
using Callboard.App.General.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Callboard.App.Data.Infrastructure
{
    internal class DataConfiguration
    {
        private const string SECTION_NAME = "dataSettings";
        private DataSettingsConfigSection _dataSettings;
        public DataConfiguration()
        {
            Configuration dllConfig = ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);
            _dataSettings = (DataSettingsConfigSection)dllConfig.GetSection(SECTION_NAME);
            Checker.CheckForNull(_dataSettings);
        }

        public IReadOnlyCollection<Table> GetTables()
        {
            Func<TableElement, Table> getTable = MapTable;
            var tables = GetEntities(_dataSettings.Tables, getTable);
            return tables;
        }

        private Table GetTable(string tableName)
        {
            Table table = null;
            var tableElem = _dataSettings.Tables.FirstOrDefault(item => item.Name == tableName);
            if (tableElem != null)
            {
                table = MapTable(tableElem);
            }
            return table;
        }

        private Table MapTable(TableElement tableElem)
        {
            Func<ProcedureElement, Procedure> getProcedure = MapProcedure;
            Func<ColumnElement, Column> getColumn = MapColumn;
            return new Table
            {
                Name = tableElem.Name,
                Columns = GetEntities(tableElem.Columns, getColumn),
                Procedures = GetEntities(tableElem.Procedures, getProcedure)
            };
        }

        private Column MapColumn(ColumnElement columnElem)
        {
            return new Column
            {
                Name = columnElem.Name,
                MapPropertyName = columnElem.MapPropertyName
            };
        }

        private Procedure MapProcedure(ProcedureElement procedureElem)
        {
            return new Procedure
            {
                Type = procedureElem.Type,
                ProcedureName = procedureElem.ProcedureName,
                Params = procedureElem.Params.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            };
        }

        private IReadOnlyCollection<TResult> GetEntities<TSource, TSourceElement, TResult>(TSource source, Func<TSourceElement, TResult> mapping)
            where TSource : ConfigCollection<TSourceElement>
            where TSourceElement : ConfigurationElement, new()
        {
            var entities = new List<TResult>();
            for (int i = 0; i < source.Count; i++)
            {
                TResult item = mapping(source[i]);
                entities.Add(item);
            }
            return entities;
        }
    }
}
