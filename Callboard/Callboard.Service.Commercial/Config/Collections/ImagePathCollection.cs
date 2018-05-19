using System.Configuration;

namespace Callboard.Service.Commercial.Config
{
    [ConfigurationCollection(typeof(ImagePathElement), AddItemName = "imagePath")]
    public class ImagePathCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ImagePathElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ImagePathElement)(element)).Path;
        }

        public ImagePathElement this[int index]
        {
            get { return (ImagePathElement)BaseGet(index); }
        }
    }
}
