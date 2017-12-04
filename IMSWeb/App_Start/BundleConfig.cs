using System.Web;
using System.Web.Optimization;

namespace IMSWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

 

            bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
                      "~/plugins/jquery/jquery.min.js",
                      "~/plugins/bootstrap/js/bootstrap.js",
                      "~/plugins/bootstrap-select/js/bootstrap-select.js",
                      "~/plugins/jquery-slimscroll/jquery.slimscroll.js",
                      "~/plugins/node-waves/waves.js",
                      "~/plugins/jquery-validation/jquery.validate.js",
                      "~/Scripts/admin.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
