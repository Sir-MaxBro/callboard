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

            For<IAdProvider>().Use<AdProvider>();
            For<ICategoryProvider>().Use<CategoryProvider>();
            For<IUserProvider>().Use<UserProvider>();

            For<ICommercialProvider>().Use<CommercialProvider>();
            For<IAdDetailsProvider>().Use<AdDetailsProvider>();
            For<ICountryProvider>().Use<CountryProvider>();
            For<IAreaProvider>().Use<AreaProvider>();
            For<ICityProvider>().Use<CityProvider>();
            For<IKindProvider>().Use<KindProvider>();
            For<IStateProvider>().Use<StateProvider>();
        }
    }
}
