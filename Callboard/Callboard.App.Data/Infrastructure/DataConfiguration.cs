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
        private const string DB_NAME = "callboardDB";
        private string _assemblyName;
        private DataSettingsConfigSection _dataSettings;
        private Configuration _configuration;
        public DataConfiguration()
        {
            var assembly = ConfigurationHelper.GetObjAssembly(this);
            _configuration = ConfigurationHelper.GetExecutingAssemblyConfig(this);
            _assemblyName = assembly.FullName;
            _dataSettings = GetDataSettingsSection();
        }

        public string ConnectionString
        {
            get => GetConnectionString();
        }

        private string GetConnectionString()
        {
            var connStringsSection = _configuration.ConnectionStrings;
            Checker.CheckForNull(connStringsSection, $"Cannot find ConnectionStrings section in { _assemblyName }");
            string connStrings = null;
            try
            {
                connStrings = connStringsSection.ConnectionStrings[DB_NAME]?.ConnectionString;
                Checker.CheckForNull(connStrings, $"Cannot find connection string with name { DB_NAME } in { _assemblyName }");
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
            return connStrings;
        }

        private DataSettingsConfigSection GetDataSettingsSection()
        {
            var dataSettings = (DataSettingsConfigSection)_configuration.GetSection(SECTION_NAME);
            Checker.CheckForNull(dataSettings, errorMessage: $"Cannot find { SECTION_NAME } section in { _assemblyName }");
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
            tableName = tableName.ToLower();
            var tableElem = _dataSettings.Tables.FirstOrDefault(item => item.Name.ToLower() == tableName);
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
