using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.DataContext.Realizations.Db;
using Callboard.App.Data.DataContext.Realizations.Service;
using Callboard.App.Data.DbContext.Main;
using Callboard.App.Data.DbContext.Realizations;
using Callboard.App.Data.Providers.Main;
using Callboard.App.Data.Providers.Realizations.Service;
using Callboard.App.Data.Providers.Realizations.Sql;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.Data.Repositories.Realizations;
using StructureMap;

namespace Callboard.App.Data.DependencyResolution
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IDbContext>().Use<SqlDbContext>();

            For<ICategoryRepository>().Use<CategoryRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<IRoleRepository>().Use<RoleRepository>();
            For<ICityRepository>().Use<CityRepository>();
            For<IAreaRepository>().Use<AreaRepository>();
            For<ICountryRepository>().Use<CountryRepository>();
            For<IKindRepository>().Use<KindRepository>();
            For<IStateRepository>().Use<StateRepository>();

            For<IMembershipProvider>().Use<MembershipProvider>();
            For<IAdProvider>().Use<AdProvider>();
            For<IAdDetailsProvider>().Use<AdDetailsProvider>();
            For<ICommercialProvider>().Use<CommercialProvider>();

            For<ICategoryContext>().Use<CategoryDbContext>();
            For<IAreaContext>().Use<AreaDbContext>();
            For<ICityContext>().Use<CityDbContext>();
            For<ICountryContext>().Use<CountryDbContext>();
            For<IKindContext>().Use<KindDbContext>();
            For<IRoleContext>().Use<RoleDbContext>();
            For<IStateContext>().Use<StateDbContext>();
            For<IUserContext>().Use<UserDbContext>();
            For<IAdContext>().Use<AdDbContext>();
            For<IAdDetailsContext>().Use<AdDetailsDbContext>();
            For<ICommercialContext>().Use<CommercialServiceContext>();
            For<IMembershipContext>().Use<MembershipDbContext>();
        }
    }
}