using System;
using System.Collections.Generic;

namespace Callboard.App.General.Extensions
{
    public static class IReadOnlyCollectionExtension
    {
        public static T FirstOfDefault<T>(this IReadOnlyCollection<T> source, Predicate<T> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }
    }
}
