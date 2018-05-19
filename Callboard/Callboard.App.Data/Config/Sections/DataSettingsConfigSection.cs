using Callboard.App.Data.Config.Collections;
using System.Configuration;

namespace Callboard.App.Data.Config.Sections
{
    public class DataSettingsConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("tables")]
        public TableCollection Tables
        {
            get { return ((TableCollection)(base["tables"])); }
        }
    }
}
