using Callboard.App.General.DependencyResolution;
using Callboard.App.General.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Business.DependencyResolution
{
    internal static class IoC
    {
        private static StructureMap.IContainer _container;
        static IoC()
        {
            InitializeContainer();
        }

        public static void InitializeContainer()
        {    
            _container = new StructureMap.Container(
                x => x.Scan
                       (
                           scan =>
                           {
                               scan.AssemblyContainingType<ILoggerWrapper>();
                               scan.LookForRegistries();
                           }
                       )
          );
        }

        public static StructureMap.IContainer Container => _container;

        public static T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}
