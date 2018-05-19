using System.Configuration;

namespace Callboard.App.Data.Config.Elements
{
    public class ColumnElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true)]
        public string Name
        {
            get { return ((string)(base["name"])); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("mapPropertyName")]
        public string MapPropertyName
        {
            get { return ((string)(base["mapPropertyName"])); }
            set { base["mapPropertyName"] = value; }
        }
    }
}
