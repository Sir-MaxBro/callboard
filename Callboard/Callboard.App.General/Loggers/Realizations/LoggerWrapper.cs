using Callboard.App.General.Loggers.Main;
using log4net;
using log4net.Config;
using System;
using System.IO;

namespace Callboard.App.General.Loggers.Realizations
{
    internal class LoggerWrapper : ILoggerWrapper
    {
        private ILog _logger;
        private const string PATH_CONFIG = "logger.config";
        private const string LOGGER_NAME = "LOGGER";
        public LoggerWrapper()
        {
            _logger = LogManager.GetLogger(LOGGER_NAME);
            InitLogger();
        }

        private void InitLogger()
        {
            var appConfigPath = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, PATH_CONFIG);
            var configFile = new FileInfo(appConfigPath);
            XmlConfigurator.ConfigureAndWatch(configFile);
        }

        public void DebugFormat(string message, params object[] values)
        {
            _logger.DebugFormat(message, values);
        }

        public void ErrorFormat(string message, params object[] values)
        {
            _logger.ErrorFormat(message, values);
        }

        public void FatalFormat(string message, params object[] values)
        {
            _logger.FatalFormat(message, values);
        }

        public void InfoFormat(string message, params object[] values)
        {
            _logger.InfoFormat(message, values);
        }

        public void WarnFormat(string message, params object[] values)
        {
            _logger.WarnFormat(message, values);
        }
    }
}
