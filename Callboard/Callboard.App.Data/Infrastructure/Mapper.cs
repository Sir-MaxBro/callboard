using Callboard.App.General.Attributes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Data.Infrastructure
{
    internal class Mapper
    {

        public static IReadOnlyCollection<T> MapCollection<T>(DbDataReader reader)
            where T : new()
        {
            var mappingCollection = new List<T>();
            T item = new T();

            while (reader.HasRows)
            {
                reader.Read();
                item = Map<T>(reader);
                mappingCollection.Add(item);
            }

            return mappingCollection;
        }

        private static T Map<T>(DbDataReader reader)
            where T : new()
        {
            T item = new T();
            var properties = typeof(T).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var columnType = properties[i].PropertyType;
                var columnName = properties[i].GetCustomAttributes(typeof(ColumnAttribute), false)
                    .OfType<ColumnAttribute>()
                    .ElementAt(0)
                    .ColumnName;
                if (columnName == null)
                {
                    columnName = properties[i].Name;
                }

                var columnValue = (T)reader[columnName];

                item = (T)Convert.ChangeType(columnValue, columnType);
            }
            return item;
        }
    }
}
