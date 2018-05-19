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

        public static T MapProperty<T>(DbDataReader reader, string mapPropertyName, Func<string, string> getName)
        {
            T obj = default(T);
            if (!reader.IsClosed)
            {
                mapPropertyName = mapPropertyName.ToLower();
                string name = getName(mapPropertyName);
                if (name != null)
                {
                    try
                    {
                        obj = (T)reader[name];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                       
                    }
                }
            }
            return obj;
        }
    }
}
