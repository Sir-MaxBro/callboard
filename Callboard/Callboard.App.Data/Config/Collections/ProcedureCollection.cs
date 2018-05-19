using Callboard.App.Data.Config.Elements;
using Callboard.App.Data.Config.Main;
using System.Configuration;

namespace Callboard.App.Data.Config.Collections
{
    [ConfigurationCollection(typeof(ProcedureElement), AddItemName = "procedure")]
    public class ProcedureCollection : ConfigCollection<ProcedureElement>
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProcedureElement)(element)).ProcedureName;
        }
    }
}
