using Callboard.App.Data.Context.Main;
using Callboard.App.Data.Context.Realizations;
using Callboard.App.Data.DataProviders.Main;
using Callboard.App.Data.DataProviders.Realizations;
using Callboard.App.Data.Providers.Main;
using Callboard.App.Data.Providers.Realizations.Service;
using Callboard.App.Data.Providers.Realizations.Sql;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.Data.Repositories.Realizations.Sql;
using Callboard.App.General.Entities;
using StructureMap;

namespace Callboard.App.Data.DependencyResolution
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<ISqlDataProvider<Ad>>().Use<SqlDataProvider<Ad>>();
            For<ISqlDataProvider<AdDetails>>().Use<SqlDataProvider<AdDetails>>();
            For<ISqlDataProvider<Category>>().Use<SqlDataProvider<Category>>();
            For<ISqlDataProvider<User>>().Use<SqlDataProvider<User>>();
            For<ISqlDataProvider<Role>>().Use<SqlDataProvider<Role>>();
            For<ISqlDataProvider<Area>>().Use<SqlDataProvider<Area>>();
            For<ISqlDataProvider<City>>().Use<SqlDataProvider<City>>();
            For<ISqlDataProvider<Country>>().Use<SqlDataProvider<Country>>();
            For<ISqlDataProvider<Kind>>().Use<SqlDataProvider<Kind>>();
            For<ISqlDataProvider<State>>().Use<SqlDataProvider<State>>();

            For<ISqlDbContext>().Use<SqlDbContext>();

            For<ICategoryRepository>().Use<CategorySqlRepository>();
            For<IUserRepository>().Use<UserSqlRepository>();
            For<IRoleRepository>().Use<RoleSqlRepository>();
            For<ICityRepository>().Use<CitySqlRepository>();
            For<IAreaRepository>().Use<AreaSqlRepository>();
            For<ICountryRepository>().Use<CountrySqlRepository>();
            For<IKindRepository>().Use<KindSqlRepository>();
            For<IStateRepository>().Use<StateSqlRepository>();

            For<IMembershipProvider>().Use<MembershipSqlProvider>();
            For<IAdProvider>().Use<AdSqlProvider>();
            For<IAdDetailsProvider>().Use<AdDetailsSqlProvider>();

            For<ICommercialProvider>().Use<CommercialServiceProvider>();
        }
    }
}