using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.General.Attributes
{
    public class TableAttribute : Attribute
    {
        private string _tableName;
        public TableAttribute(string tableName)
        {
            _tableName = tableName;
        }

        public string TableName
        {
            get => _tableName;
        }
    }
}
