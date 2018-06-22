using System;
using System.Runtime.Serialization;

namespace Callboard.App.Data.Exceptions
{
    public class LoginAlreadyExistsException : UserException
    {
        public LoginAlreadyExistsException() { }

        public LoginAlreadyExistsException(string message)
            : base(message) { }

        public LoginAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) { }

        protected LoginAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}