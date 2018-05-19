using System.Configuration;
using System.Reflection;

namespace Callboard.App.General.Helpers
{
    public static class ConfigurationHelper
    {
        public static Configuration GetAssemblyConfiguration<T>(T obj)
        {
            var assembly = GetObjAssembly(obj);
            return ConfigurationManager.OpenExeConfiguration(assembly.Location);
        }

        public static Configuration GetAssemblyConfiguration(Assembly assembly)
        {
            return ConfigurationManager.OpenExeConfiguration(assembly.Location);
        }

        public static Assembly GetObjAssembly<T>(T obj)
        {
            return obj.GetType().Assembly;
        }
    }
}
