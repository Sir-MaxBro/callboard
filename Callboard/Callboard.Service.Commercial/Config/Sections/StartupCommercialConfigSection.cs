using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.Service.Commercial.Config
{
    public class StartupCommercialConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("pathways")]
        public PathCollection Pathways
        {
            get { return ((PathCollection)(base["pathways"])); }
        }
    }
}
