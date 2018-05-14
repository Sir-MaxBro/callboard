using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.General.Attributes
{
    public class ColumnAttribute :Attribute
    {
        private string _columnName;
        public ColumnAttribute(string columnName)
        {
            _columnName = columnName;
        }

        public string ColumnName
        {
            get => _columnName;
        }
    }
}
