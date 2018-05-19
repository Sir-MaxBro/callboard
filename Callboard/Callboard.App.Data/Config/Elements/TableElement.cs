using System.Configuration;
using Callboard.App.Data.Config.Collections;

namespace Callboard.App.Data.Config.Elements
{
    public class TableElement : ConfigurationElement
    {
        [ConfigurationProperty("procedures")]
        public ProcedureCollection Procedures
        {
            get { return ((ProcedureCollection)(base["procedures"])); }
        }

        [ConfigurationProperty("columns")]
        public ColumnCollection Columns
        {
            get { return ((ColumnCollection)(base["columns"])); }
        }

        [ConfigurationProperty("name", IsKey = true)]
        public string Name
        {
            get { return ((string)(base["name"])); }
            set { base["name"] = value; }
        }
    }
}
