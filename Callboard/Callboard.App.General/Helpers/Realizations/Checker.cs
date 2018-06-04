using Callboard.App.General.Exceptions;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;

namespace Callboard.App.General.Helpers.Realizations
{
    internal class Checker : IChecker
    {
        private ILoggerWrapper _logger;
        public Checker(ILoggerWrapper logger)
        {
            this.CheckForNull(logger);
            _logger = logger;
        }

        public void CheckForNull<T>(T obj)
            where T : class
        {
            CheckForNull(obj, string.Empty);
        }

        public void CheckForNull<T>(T obj, string errorMessage)
            where T : class
        {
            if (Equals(obj, null))
            {
                errorMessage = $"Object { typeof(T) } is null.\n { errorMessage }";
                _logger?.ErrorFormat(errorMessage);
                throw new NullReferenceException(errorMessage);
            }
        }

        public void CheckId(int id)
        {
            CheckId(id, string.Empty);
        }

        public void CheckId(int id, string errorMessage)
        {
            if (id < 1)
            {
                string infoMessage = $"Id { id } is not valid.\n { errorMessage }";
                _logger?.InfoFormat(infoMessage);
                throw new InvalidIdException(infoMessage);
            }
        }
    }
}
