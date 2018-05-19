using Callboard.App.Data.Config.Elements;
using Callboard.App.Data.Config.Main;
using System.Configuration;

namespace Callboard.App.Data.Config.Collections
{
    [ConfigurationCollection(typeof(TableElement), AddItemName = "table")]
    public class TableCollection : ConfigCollection<TableElement>
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TableElement)(element)).Name;
        }
    }
}
