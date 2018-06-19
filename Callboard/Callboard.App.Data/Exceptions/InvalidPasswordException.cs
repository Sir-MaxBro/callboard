using System;
using System.Runtime.Serialization;

namespace Callboard.App.Data.Exceptions
{
    public class InvalidPasswordException : ApplicationException
    {
        public InvalidPasswordException() { }

        public InvalidPasswordException(string message)
            : base(message) { }

        public InvalidPasswordException(string message, Exception innerException)
            : base(message, innerException) { }

        protected InvalidPasswordException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
