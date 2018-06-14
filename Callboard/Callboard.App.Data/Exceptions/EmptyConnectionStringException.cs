using System;
using System.Runtime.Serialization;

namespace Callboard.App.Data.Exceptions
{
    public class EmptyConnectionStringException : ApplicationException
    {
        public EmptyConnectionStringException() { }

        public EmptyConnectionStringException(string message) 
            : base(message) { }

        public EmptyConnectionStringException(string message, Exception innerException) 
            : base(message, innerException) { }

        protected EmptyConnectionStringException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
