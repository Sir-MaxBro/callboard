using Callboard.App.Business.Providers.Main;
using Callboard.App.Business.Services;
using Callboard.App.Data.Context.Main;
using Callboard.App.Data.DataProviders.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Cache.Main;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using StructureMap;
using StructureMap.Graph;

namespace Callboard.App.IoC.DependencyResolution
{
    public static class ContainerBootstrap
    {
        private static IContainer _container;
        public static void Initialize()
        {
            _container = new Container(
                x => x.Scan
                       (
                           scan =>
                           {                              
                               AddDataDependency(scan);
                               AddBusinessDependency(scan);
                               AddGeneralDependency(scan);
                               scan.LookForRegistries();
                           }
                       )
          );
        }

        private static void AddGeneralDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<ILoggerWrapper>();
            scan.AssemblyContainingType<IChecker>();
            scan.AssemblyContainingType<ICacheStorage>();
        }

        private static void AddBusinessDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<ILogginService>();
            scan.AssemblyContainingType<IEntityProvider<object>>();
        }

        private static void AddDataDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<ISqlDataProvider<object>>();
            scan.AssemblyContainingType<ISqlDbContext>();

            scan.AssemblyContainingType<ICategoryRepository>();
            scan.AssemblyContainingType<IUserRepository>();
            scan.AssemblyContainingType<IRoleRepository>();
            scan.AssemblyContainingType<IAreaRepository>();
            scan.AssemblyContainingType<ICityRepository>();
            scan.AssemblyContainingType<ICountryRepository>();
            scan.AssemblyContainingType<IKindRepository>();
            scan.AssemblyContainingType<IStateRepository>();

            scan.AssemblyContainingType<Data.Providers.Main.IAdProvider>();
            scan.AssemblyContainingType<Data.Providers.Main.IMembershipProvider>();
            scan.AssemblyContainingType<Data.Providers.Main.ICommercialProvider>();
            scan.AssemblyContainingType<Data.Providers.Main.IAdDetailsProvider>();
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}
