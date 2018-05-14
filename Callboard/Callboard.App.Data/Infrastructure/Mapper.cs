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

            while (reader.Read())
            {
                var dic = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
                item = Map<T>(dic);
                //item = Map<T>(reader);           
                mappingCollection.Add(item);
            }

            return mappingCollection;
        }

        private static T Map<T>(/*DbDataReader reader*/IDictionary<string, object> dicReader)
            where T : new()
        {
            T item = new T();
            var properties = typeof(T).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var columnType = properties[i].PropertyType;
                var columnName = properties[i].GetCustomAttributes(typeof(ColumnAttribute), false)
                    .OfType<ColumnAttribute>()
                    .ElementAtOrDefault(0)?
                    .ColumnName;
                if (columnName == null)
                {
                    columnName = properties[i].Name;
                }

                try
                {
                    var columnValue = dicReader[columnName];
                    //var columnValue = reader[columnName];
                    if (columnValue != null)
                    {
                        columnValue = Convert.ChangeType(columnValue, columnType);
                        properties[i].SetValue(item, columnValue);
                    }
                }
                catch (KeyNotFoundException ex)
                {

                }
            }
            return item;
        }
    }
}
