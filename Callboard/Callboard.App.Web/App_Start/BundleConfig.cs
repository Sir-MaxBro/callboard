using System.Web.Optimization;

namespace Callboard.App.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .IncludeDirectory("~/Content/css", "*.css", true));

            bundles.Add(new ScriptBundle("~/bundles/ajax")
                .Include("~/Scripts/jquery-1.10.2.min.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
                .Include("~/Scripts/ajax-helper.js"));
        }
    }
}