using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.Service.Commercial.Config
{
    [ConfigurationCollection(typeof(CommercialPathElement), AddItemName = "commercialPath")]
    public class PathCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CommercialPathElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CommercialPathElement)(element)).Path;
        }

        public CommercialPathElement this[int index]
        {
            get { return (CommercialPathElement)BaseGet(index); }
        }
    }
}
