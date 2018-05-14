using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.General.Attributes
{
    public class ForeignKeyAttribute : Attribute
    {
        private string _fKey;
        public ForeignKeyAttribute(string fKey)
        {
            _fKey = fKey;
        }

        public string FKey
        {
            get => _fKey;
        }
    }
}
