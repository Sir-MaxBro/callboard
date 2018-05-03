using Callboard.App.Business.Abstract;
using Callboard.App.Business.Concrete;
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
        }
    }
}
