using System.Configuration;

namespace Callboard.App.Data.Config.Elements
{
    public class ProcedureElement : ConfigurationElement
    {
        [ConfigurationProperty("procedureName", IsKey = true)]
        public string ProcedureName
        {
            get { return ((string)(base["procedureName"])); }
            set { base["procedureName"] = value; }
        }

        [ConfigurationProperty("type")]
        public string Type
        {
            get { return ((string)(base["type"])); }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("params", DefaultValue = "")]
        public string Params
        {
            get { return ((string)(base["params"])); }
            set { base["params"] = value; }
        }
    }
}
