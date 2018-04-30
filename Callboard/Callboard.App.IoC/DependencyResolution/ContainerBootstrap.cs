using Callboard.App.Business.Abstract;
using Callboard.App.General.Entities;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.IoC.DependencyResolution
{
    public static class ContainerBootstrap
    {
        private static IContainer _container;
        public static void Initialize()
        {
            _container = new Container(
                x => x.Scan
                       (
                           scan =>
                           {
                               scan.AssemblyContainingType<IEntityRepository<object>>();
                               //scan.Assembly("Callboard.App.Business");
                               scan.WithDefaultConventions();
                               scan.LookForRegistries();
                           }
                       )
          );
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}
