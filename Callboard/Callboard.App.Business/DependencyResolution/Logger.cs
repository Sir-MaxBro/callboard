using Callboard.App.General.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Business.DependencyResolution
{
    internal class Logger
    {
        private static Logger _logger;
        private ILoggerWrapper _loggerWrapper;
        private Logger()
        {
            _loggerWrapper = new LoggerWrapper();
        }

        public static ILoggerWrapper GetLoggerInstance()
        {
            if(_logger == null)
            {
                _logger = new Logger();
            }
            return _logger._loggerWrapper;
        }
    }
}
