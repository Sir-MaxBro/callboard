using Callboard.App.Data.DataContext;
using Callboard.App.Data.DataContext.Realizations.Db;
using Callboard.App.Data.DataContext.Realizations.Service;
using Callboard.App.Data.DbContext;
using Callboard.App.Data.DbContext.Realizations;
using Callboard.App.Data.Repositories;
using Callboard.App.Data.Repositories.Realizations;
using Callboard.App.Data.Services;
using Callboard.App.Data.Services.Realizations;
using Callboard.App.General.Entities;
using StructureMap;

namespace Callboard.App.Data.DependencyResolution
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IDbContext>().Use<SqlDbContext>();

            For<ICategoryRepository>().Use<CategoryRepository>();
            For<IRoleRepository>().Use<RoleRepository>();
            
            For<IRepository<User>>().Use<UserRepository>();
            For<IRepository<Country>>().Use<CountryRepository>();
            For<IRepository<Kind>>().Use<KindRepository>();
            For<IRepository<State>>().Use<StateRepository>();

            For<ICityService>().Use<CityService>();
            For<IAreaService>().Use<AreaService>();

            For<IMembershipService>().Use<MembershipService>();
            For<IAdService>().Use<AdService>();
            For<IAdDetailsService>().Use<AdDetailsService>();
            For<ICommercialService>().Use<Services.Realizations.CommercialService>();

            For<ICategoryContext>().Use<CategoryDbContext>();
            For<IAreaContext>().Use<AreaDbContext>();
            For<ICityContext>().Use<CityDbContext>();

            For<IDataContext<Country>>().Use<CountryDbContext>();
            For<IDataContext<Kind>>().Use<KindDbContext>();
            For<IDataContext<State>>().Use<StateDbContext>();
            For<IDataContext<User>>().Use<UserDbContext>();

            For<IRoleContext>().Use<RoleDbContext>();
            For<IAdContext>().Use<AdDbContext>();
            For<IAdDetailsContext>().Use<AdDetailsDbContext>();
            For<ICommercialContext>().Use<CommercialServiceContext>();
            For<IMembershipContext>().Use<MembershipDbContext>();
        }
    }
}