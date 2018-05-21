using Callboard.App.General.Exceptions;
using Callboard.App.General.Loggers;
using System;

namespace Callboard.App.General.Helpers
{
    public static class Checker
    {
        private static ILoggerWrapper _logger = LoggerWrapper.GetInstance();
        public static void CheckForNull<T>(T obj)
            where T : class
        {
            if (Equals(obj, null))
            {
                string errorMessage = $"Object { typeof(T) } is null.";
                _logger.ErrorFormat(errorMessage);
                throw new NullReferenceException(errorMessage);
            }
        }

        public static void CheckForNull<T>(T obj, string errorMessage)
            where T : class
        {
            if (Equals(obj, null))
            {
                errorMessage = $"Object { typeof(T) } is null.\n { errorMessage }";
                _logger.ErrorFormat(errorMessage);
                throw new NullReferenceException(errorMessage);
            }
        }

        public static void CheckId(int id)
        {
            if (id < 1)
            {
                string infoMessage = $"Id { id } is not valid.";
                _logger.InfoFormat(infoMessage);
                throw new InvalidIdException(infoMessage);
            }
        }
    }
}
