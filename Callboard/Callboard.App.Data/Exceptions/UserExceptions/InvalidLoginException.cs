﻿using System;
using System.Runtime.Serialization;

namespace Callboard.App.Data.Exceptions
{
    public class InvalidLoginException : UserException
    {
        public InvalidLoginException() { }

        public InvalidLoginException(string message)
            : base(message) { }

        public InvalidLoginException(string message, Exception innerException)
            : base(message, innerException) { }

        protected InvalidLoginException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
