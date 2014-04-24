using System.Web;
using System.Web.Optimization;

namespace BlogWeb
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Clear();

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                        "~/Scripts/jquery-1.10.2.js",
                        "~/Content/Frameworks/JQueryUI/jquery.color-2.1.2.js",
                        //"~/Content/Frameworks/JQueryUI/jquery-ui-1.10.4.custom.min.js",
                        "~/Content/Frameworks/Bootstrap/js/bootstrap.min.js",
                        "~/Scripts/usefull.js",
                        "~/Scripts/mediator.js",
                        "~/Scripts/app.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/Frameworks/Bootstrap/css/bootstrap.css"));


        }
    }
}