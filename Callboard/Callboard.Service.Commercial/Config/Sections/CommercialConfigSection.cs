using System.Configuration;

namespace Callboard.Service.Commercial.Config
{
    public class CommercialConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("pathways")]
        public ImagePathCollection Pathways
        {
            get { return ((ImagePathCollection)(base["pathways"])); }
        }
    }
}
