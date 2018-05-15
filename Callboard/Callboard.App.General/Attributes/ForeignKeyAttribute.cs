﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.General.Attributes
{
    public class ForeignKeyAttribute : Attribute
    {
        private string _fKey;
        private string _tableName;
        public ForeignKeyAttribute(string fKey, string tableName)
        {
            _fKey = fKey;
            _tableName = tableName;
        }

        public string FKey
        {
            get => _fKey;
        }

        public string TableName
        {
            get => _tableName;
        }
    }
}
