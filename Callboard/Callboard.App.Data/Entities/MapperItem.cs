using System;
using System.Reflection;

namespace Callboard.App.Data.Entities
{
    internal class MapperItem
    {
        public string TableName { get; set; }
        public string FKey { get; set; }
        public object Value { get; set; }
        public Type ValueType { get; set; }
        public PropertyInfo Property { get; set; }
    }
}
