using Callboard.App.General.Cache.Main;
using Callboard.App.General.Cache.Realizations;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Helpers.Realizations;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Loggers.Realizations;
using StructureMap;

namespace Callboard.App.General.DependencyResolution
{
    public class GeneralRegistry : Registry
    {
        public GeneralRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
            For<ILoggerWrapper>().Singleton().Use<LoggerWrapper>();
            For<IChecker>().Singleton().Use<Checker>();
            For<ICacheStorage>().Singleton().Use<CacheStorage>();
        }
    }
}
