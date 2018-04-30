using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Callboard.App.Business.Abstract;
using Callboard.App.Business.Concrete;
using System.Threading.Tasks;
using Callboard.App.General.Entities;

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
