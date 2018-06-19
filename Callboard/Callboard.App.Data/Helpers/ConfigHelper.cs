using Callboard.App.General.Helpers;
using Callboard.App.General.Loggers.Main;
using System;
using System.Configuration;

namespace Callboard.App.Data.Helpers
{
    internal class ConfigHelper
    {
        private const string DB_NAME = "callboardDB";
        private ILoggerWrapper _logger;
        public ConfigHelper(ILoggerWrapper logger)
        {
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
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
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new NullReferenceException($"Cannot find connection string with name { DB_NAME } in App.Data.dll.config");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                _logger.ErrorFormat($"{ ex.Message }");
            }
            return connectionString;
        }
    }
}