using Callboard.App.Data.Config.Elements;
using Callboard.App.Data.Config.Main;
using Callboard.App.Data.Config.Sections;
using Callboard.App.Data.Entities;
using Callboard.App.General.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace Callboard.App.Data.Infrastructure
{
    internal class DataConfiguration
    {
        private const string SECTION_NAME = "dataSettings";
        private const string DB_NAME = "callboardDB";
        private DataSettingsConfigSection _dataSettings;
        private string _connectionString;
        public DataConfiguration()
        {
            var assembly = ConfigurationHelper.GetObjAssembly(this);
            var configuration = ConfigurationHelper.GetAssemblyConfiguration(assembly);

            _dataSettings = GetDataSettingsSection(assembly, configuration);
            _connectionString = GetConnectionString(assembly, configuration);
        }

        public string ConnectionString
        {
            get => _connectionString;
        }

        private string GetConnectionString(Assembly assembly, Configuration configuration)
        {
            var connStringsSection = configuration.ConnectionStrings;
            Checker.CheckForNull(connStringsSection, $"Cannot find ConnectionStrings section in { assembly.FullName }");

            var connStrings = connStringsSection.ConnectionStrings[DB_NAME]?.ConnectionString;
            Checker.CheckForNull(connStrings, $"Cannot find connection string with name { DB_NAME } in { assembly.FullName }");

            return connStrings;
        }

        private DataSettingsConfigSection GetDataSettingsSection(Assembly assembly, Configuration configuration)
        {
            var dataSettings = (DataSettingsConfigSection)configuration.GetSection(SECTION_NAME);
            Checker.CheckForNull(dataSettings, errorMessage: $"Cannot find { SECTION_NAME } section in { assembly.FullName }");
            return dataSettings;
        }

        public IReadOnlyCollection<Table> GetTables()
        {
            Func<TableElement, Table> getTable = MapTable;
            var tables = GetEntities(_dataSettings.Tables, getTable);
            return tables;
        }

        public Table GetTable(string tableName)
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
