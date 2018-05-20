using StructureMap;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.DependencyResolution
{
    internal static class DataContainer
    {
        private static IContainer _container;
        static DataContainer()
        {
            Initialize();
        }

        private static void Initialize()
        {
            _container = new Container(
                x => x.Scan
                       (
                           scan =>
                           {
                               scan.AssemblyContainingType<Data::IEntityRepository<object>>();
                               scan.LookForRegistries();
                           }
                       )
            );
        }

        public static IContainer Container
        {
            get { return _container; }
        }

        public static T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}
