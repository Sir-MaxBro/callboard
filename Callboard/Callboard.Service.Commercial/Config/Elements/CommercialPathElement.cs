using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.Service.Commercial.Config
{
    public class CommercialPathElement : ConfigurationElement
    {
        [ConfigurationProperty("path", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Path
        {
            get { return ((string)(base["path"])); }
            set { base["path"] = value; }
        }
    }
}
