using System;

namespace Callboard.App.General.Results.Realizations
{
    public class FailureResult<T> : IFailureResult<T>
    {
        public FailureResult(Exception exception)
            :this(exception, "") { }

        public FailureResult(Exception exception, string errorMessage)
        {
            this.Exception = exception;
            this.ErrorMessage = errorMessage;
        }

        public Exception Exception { get; private set; }

        public string ErrorMessage { get; private set; }
    }
}