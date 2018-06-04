using Callboard.App.General.Helpers;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
using System.Configuration;

namespace Callboard.App.Data.Helpers
{
    internal class ConfigHelper
    {
        private const string DB_NAME = "callboardDB";
        private ILoggerWrapper _logger;
        private IChecker _checker;
        public ConfigHelper(ILoggerWrapper logger, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(logger);
            _logger = logger;
        }

        public string ConnectionString
        {
            get => GetConnectionString();
        }

        private string GetConnectionString()
        {
            var configuration = ConfigurationHelper.GetExecutingAssemblyConfig(this);
            var connStringsSection = configuration.ConnectionStrings;
            string connectionString = null;
            try
            {
                connectionString = connStringsSection?.ConnectionStrings[DB_NAME]?.ConnectionString;
                _checker.CheckForNull(connectionString, $"Cannot find connection string with name { DB_NAME } in App.Data.dll.config");
            }
            catch (ConfigurationErrorsException ex)
            {
                _logger.ErrorFormat($"{ ex.Message }");
            }
            return connectionString;
        }
    }
}