using Callboard.App.Business.Repositories;
using StructureMap;

namespace Callboard.App.Business.DependencyResolution
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            For<IAdRepository>().Use<AdRepository>();
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<IAdDetailsRepository>().Use<AdDetailsRepository>();
            For<IImageRepository>().Use<ImageRepository>();

            For<ICommercialRepository>().Use<CommercialRepository>();

            For<IUserRepository>().Use<UserRepository>();
            For<IMailRepository>().Use<MailRepository>();
            For<IPhoneRepository>().Use<PhoneRepository>();

            For<ILocationRepository>().Use<LocationRepository>();
            For<ICityRepository>().Use<CityRepository>();
            For<ICountryRepository>().Use<CountryRepository>();
            For<IAreaRepository>().Use<AreaRepository>();
        }
    }
}
