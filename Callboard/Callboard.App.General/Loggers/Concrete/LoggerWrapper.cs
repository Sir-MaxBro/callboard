using Callboard.App.General.Loggers;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.General.Loggers
{
    internal class LoggerWrapper : ILoggerWrapper
    {
        private ILog _logger;
        public LoggerWrapper()
        {
            //var assembly = Assembly.GetEntryAssembly();
            //var applicationPath = Path.GetDirectoryName(assembly.Location);
            //var configFile = new FileInfo(Path.Combine(applicationPath, "logger.config"));
            //XmlConfigurator.ConfigureAndWatch(configFile);

            _logger = LogManager.GetLogger("LOGGER");

            //XmlConfigurator.Configure();
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
