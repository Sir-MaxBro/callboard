using Callboard.App.Data.Config.Elements;
using Callboard.App.Data.Config.Main;
using System.Configuration;

namespace Callboard.App.Data.Config.Collections
{
    [ConfigurationCollection(typeof(ColumnElement), AddItemName = "column")]
    public class ColumnCollection : ConfigCollection<ColumnElement>
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ColumnElement)(element)).Name;
        }
    }
}
