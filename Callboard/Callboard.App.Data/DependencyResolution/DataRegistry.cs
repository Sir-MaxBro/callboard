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
        }
    }
}
