using Callboard.App.Business.Providers.Main;
using Callboard.App.Business.Providers.Realization;
using Callboard.App.Business.Services;
using StructureMap;

namespace Callboard.App.Business.DependencyResolution
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<ILogginService>().Use<LogginService>();

            For<IAdDetailsProvider>().Use<AdDetailsProvider>();
            For<IAdProvider>().Use<AdProvider>();
            For<ICategoryProvider>().Use<CategoryProvider>();
            For<IKindProvider>().Use<KindProvider>();
            For<IStateProvider>().Use<StateProvider>();

            For<IAreaProvider>().Use<AreaProvider>();
            For<ICityProvider>().Use<CityProvider>();
            For<ICountryProvider>().Use<CountryProvider>();

            For<IMembershipProvider>().Use<MembershipProvider>();
            For<IRoleProvider>().Use<RoleProvider>();
            For<IUserProvider>().Use<UserProvider>();

            For<ICommercialProvider>().Use<CommercialProvider>();
        }
    }
}
