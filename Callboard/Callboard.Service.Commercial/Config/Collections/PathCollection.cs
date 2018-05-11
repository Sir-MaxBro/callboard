using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.Service.Commercial.Config
{
    [ConfigurationCollection(typeof(PathElement), AddItemName = "path")]
    public class PathCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PathElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PathElement)(element)).Path;
        }

        public PathElement this[int index]
        {
            get { return (PathElement)BaseGet(index); }
        }
    }
}
