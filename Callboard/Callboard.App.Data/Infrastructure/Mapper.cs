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
                item = Map<T>(reader);
                mappingCollection.Add(item);
            }

            return mappingCollection;
        }

        public static T MapElement<T>(DbDataReader reader)
            where T : new()
        {
            T item = new T();

            while (reader.Read())
            {
                item = Map<T>(reader);
            }

            return item;
        }

        private static T Map<T>(DbDataReader reader)
            where T : new()
        {
            T item = new T();
            var properties = typeof(T).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                var columnType = property.PropertyType;
                // get column name from attribute
                var columnName = property.GetCustomAttributes(typeof(ColumnAttribute), false)
                    .OfType<ColumnAttribute>()
                    .ElementAtOrDefault(0)
                    ?.ColumnName;

                if (columnName == null && columnType.IsClass)
                {
                    // create new instance of dependence type
                    var innerObj = columnType.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    // get foreign key from attribute
                    var fKeyName = property.GetCustomAttributes(typeof(ForeignKeyAttribute), false)
                        .OfType<ForeignKeyAttribute>()
                        .ElementAtOrDefault(0)
                        ?.FKey;
                    var fKeyValue = reader[fKeyName];
                    var propertyInner = innerObj.GetType().GetProperties()
                        .Where(prop => prop.GetCustomAttributes(typeof(ColumnAttribute), false).OfType<ColumnAttribute>().FirstOrDefault().ColumnName == fKeyName)
                        .FirstOrDefault();

                    propertyInner?.SetValue(innerObj, fKeyValue);

                    property.SetValue(item, innerObj);
                }
                else if (!columnType.IsInterface) // crutch
                {
                    try
                    {
                        var columnValue = reader[columnName];
                        if (columnValue != null)
                        {
                            property.SetValue(item, columnValue);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { }
                    catch(ArgumentException ex) { }
                }
            }
            return item;
        }
    }
}
