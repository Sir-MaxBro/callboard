using Callboard.App.General.Loggers;
using log4net;
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
            //For<ILoggerWrapper>().Singleton().Use<LoggerWrapper>();
            For<ILoggerWrapper>().Use(LoggerWrapper.GetInstance());
        }
    }
}
