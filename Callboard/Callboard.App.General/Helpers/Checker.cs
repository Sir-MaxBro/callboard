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
                throw new NullReferenceException($"Object { typeof(T) } is null");
            }
        }
    }
}
