﻿using Callboard.App.Business.Repositories;
using Callboard.App.General.Loggers;
using StructureMap;

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
                               scan.AssemblyContainingType<ILoggerWrapper>();
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
