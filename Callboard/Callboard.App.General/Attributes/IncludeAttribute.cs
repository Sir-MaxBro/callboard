using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.General.Attributes
{
    public class IncludeAttribute : Attribute
    {
        private string _tableName;
        private string _fKey;
        public IncludeAttribute(string tableName, string fKey)
        {
            _tableName = tableName;
            _fKey = fKey;
        }

        public string TableName
        {
            get => _tableName;
        }

        public string FKey
        {
            get => _fKey;
        }
    }
}
