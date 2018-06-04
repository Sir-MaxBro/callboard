using Callboard.App.Web.App_Start;
using StructureMap.Web.Pipeline;
using System.Web;

namespace Callboard.App.Web.DependencyResolution
{
    public class StructureMapScopeModule : IHttpModule
    {
        #region Public Methods and Operators

        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) => StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) =>
            {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }

        #endregion
    }
}