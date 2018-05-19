using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Infrastructure
{
    internal class Mapper
    {
        public static IReadOnlyCollection<TResult> MapCollection<TResult>(DbDataReader reader, Func<DbDataReader, TResult> mapping)
        {
            List<TResult> items = null;
            if (!reader.IsClosed)
            {
                items = new List<TResult>();
                while (reader.Read())
                {
                    TResult item = mapping(reader);
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
