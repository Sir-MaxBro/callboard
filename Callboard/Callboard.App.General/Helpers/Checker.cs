using Callboard.App.General.Exceptions;
using System;

namespace Callboard.App.General.Helpers
{
    public static class Checker
    {
        public static void CheckForNull<T>(T obj)
            where T : class
        {
            if (Equals(obj, null))
            {
                throw new NullReferenceException($"Object { typeof(T) } is null.");
            }
        }

        public static void CheckForNull<T>(T obj, string errorMessage)
            where T : class
        {
            if (Equals(obj, null))
            {
                throw new NullReferenceException($"Object { typeof(T) } is null.\n { errorMessage }");
            }
        }

        public static void CheckId(int id)
        {
            if (id < 1)
            {
                throw new InvalidIdException($"Id { id } is not valid.");
            }
        }
    }
}
