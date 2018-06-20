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
                .IncludeDirectory("~/Scripts/Search", "*.js", false)
                .Include("~/Scripts/Common/category-load.js"));

            bundles.Add(new ScriptBundle("~/categoryMenu")
                .IncludeDirectory("~/Scripts/CategoryMenu", "*.js", false));

            bundles.Add(new ScriptBundle("~/categoryListBox")
                .IncludeDirectory("~/Scripts/CategoryListBox", "*.js", false));

            bundles.Add(new ScriptBundle("~/user")
                .IncludeDirectory("~/Scripts/User", "*.js", false));

            bundles.Add(new ScriptBundle("~/location")
                .IncludeDirectory("~/Scripts/Location", "*.js", false));

            bundles.Add(new ScriptBundle("~/addetails")
                .IncludeDirectory("~/Scripts/AdDetails", "*.js", false)
                .Include("~/Scripts/Common/category-load.js"));

            bundles.Add(new ScriptBundle("~/common")
                .Include("~/Scripts/Common/common.js"));

            bundles.Add(new ScriptBundle("~/admin")
                .Include("~/Scripts/Admin/user-edit.js"));

            bundles.Add(new ScriptBundle("~/editor")
                .IncludeDirectory("~/Scripts/Editor", "*.js", false));

            bundles.Add(new ScriptBundle("~/roles-list")
                .IncludeDirectory("~/Scripts/UserRoleEditList", "*.js", false));

            bundles.Add(new ScriptBundle("~/countries-edit")
                .IncludeDirectory("~/Scripts/CountriesEdit", "*.js", false));

            bundles.Add(new ScriptBundle("~/areas-edit")
                .IncludeDirectory("~/Scripts/AreasEdit", "*.js", false));

            bundles.Add(new ScriptBundle("~/cities-edit")
                .IncludeDirectory("~/Scripts/CitiesEdit", "*.js", false));
        }
    }
}