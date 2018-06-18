using Callboard.App.Business.Services;
using Callboard.App.Data.DataContext;
using Callboard.App.Data.DbContext;
using Callboard.App.Data.Repositories;
using Callboard.App.Data.ServiceContext;
using Callboard.App.General.Cache.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Loggers.Main;
using StructureMap;
using StructureMap.Graph;
using Service = Callboard.App.Data.CommercialService;

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
            scan.AssemblyContainingType<ICacheStorage>();
        }

        private static void AddBusinessDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<ILogginService>();

            scan.AssemblyContainingType<IAdDetailsService>();
            scan.AssemblyContainingType<IAdService>();
            scan.AssemblyContainingType<ICategoryService>();
            scan.AssemblyContainingType<IAreaService>();
            scan.AssemblyContainingType<ICityService>();
            scan.AssemblyContainingType<IRoleService>();
            scan.AssemblyContainingType<IMembershipService>();
            scan.AssemblyContainingType<ICommercialService>();

            scan.AssemblyContainingType<IEntityService<User>>();
            scan.AssemblyContainingType<IEntityService<Country>>();
            scan.AssemblyContainingType<IEntityService<Kind>>();
            scan.AssemblyContainingType<IEntityService<State>>();
        }

        private static void AddDataDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<IDbContext>();
            scan.AssemblyContainingType<IServiceContext<Service::ICommercialContract>>();

            scan.AssemblyContainingType<IRepository<Kind>>();
            scan.AssemblyContainingType<IRepository<State>>();
            scan.AssemblyContainingType<IRepository<Country>>();
            scan.AssemblyContainingType<IRepository<User>>();

            scan.AssemblyContainingType<ICategoryRepository>();
            scan.AssemblyContainingType<IRoleRepository>();

            scan.AssemblyContainingType<Data.Services.IAreaService>();
            scan.AssemblyContainingType<Data.Services.ICityService>();
            scan.AssemblyContainingType<Data.Services.IAdDetailsService>();
            scan.AssemblyContainingType<Data.Services.IAdService>();
            scan.AssemblyContainingType<Data.Services.ICommercialService>();
            scan.AssemblyContainingType<Data.Services.IMembershipService>();

            scan.AssemblyContainingType<IAdContext>();
            scan.AssemblyContainingType<IAdDetailsContext>();
            scan.AssemblyContainingType<ICategoryContext>();
            scan.AssemblyContainingType<IAreaContext>();
            scan.AssemblyContainingType<ICityContext>();
            scan.AssemblyContainingType<IMembershipContext>();
            scan.AssemblyContainingType<IRoleContext>();
            scan.AssemblyContainingType<ICommercialContext>();

            scan.AssemblyContainingType<IDataContext<Country>>();
            scan.AssemblyContainingType<IDataContext<Kind>>();
            scan.AssemblyContainingType<IDataContext<State>>();
            scan.AssemblyContainingType<IDataContext<User>>();
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}
