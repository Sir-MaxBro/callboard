using Callboard.App.IoC.DependencyResolution;

namespace Callboard.App.Web.DependencyResolution
{
    using StructureMap;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            ContainerBootstrap.Initialize();
            return ContainerBootstrap.Container;
        }
    }
}