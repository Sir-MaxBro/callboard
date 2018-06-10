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

            bundles.Add(new ScriptBundle("~/bundles/validate")
                .Include("~/Scripts/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/search")
                .IncludeDirectory("~/Scripts/Search", "*.js", false));

            bundles.Add(new ScriptBundle("~/category")
                .IncludeDirectory("~/Scripts/Category", "*.js", false));

            bundles.Add(new ScriptBundle("~/user")
                .IncludeDirectory("~/Scripts/User", "*.js", false));

            bundles.Add(new ScriptBundle("~/location")
                .IncludeDirectory("~/Scripts/Location", "*.js", false));

            bundles.Add(new ScriptBundle("~/addetails")
                .IncludeDirectory("~/Scripts/AdDetails", "*.js", false));
        }
    }
}