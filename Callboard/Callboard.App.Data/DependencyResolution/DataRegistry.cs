using Callboard.App.Data.Repositories;
using StructureMap;

namespace Callboard.App.Data.DependencyResolution
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
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
        }
    }
}
