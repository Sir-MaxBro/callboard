using Callboard.App.Business.Services;
using Callboard.App.Business.Services.Realizations;
using Callboard.App.General.Entities;
using StructureMap;

namespace Callboard.App.Business.DependencyResolution
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<ILogginService>().Use<LogginService>();

            For<IAdDetailsService>().Use<AdDetailsService>();
            For<IAdService>().Use<AdService>();
            For<ICategoryService>().Use<CategoryService>();
            For<IAreaService>().Use<AreaService>();
            For<ICityService>().Use<CityService>();
            For<IMembershipService>().Use<MembershipService>();
            For<IRoleService>().Use<RoleService>();
            For<ICommercialService>().Use<CommercialService>();

            For<IEntityService<User>>().Use<UserService>();
            For<IEntityService<Country>>().Use<CountryProvider>();
            For<IEntityService<Kind>>().Use<KindService>();
            For<IEntityService<State>>().Use<StateService>();
        }
    }
}