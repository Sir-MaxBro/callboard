using System.Configuration;

namespace Callboard.Service.Commercial.Config
{
    public class StartupCommercialConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("pathways")]
        public ImagePathCollection Pathways
        {
            get { return ((ImagePathCollection)(base["pathways"])); }
        }
    }
}
