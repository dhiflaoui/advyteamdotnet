using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //admin


            bundles.Add(new ScriptBundle("~/bundles/admin/js").Include(
                        "~/js/jquery2.0.3.min.js", "~/js/modernizr.js", "~/js/jquery.cookie.js", "~/js/screenfull.js"
                        , "~/js/raphael-min.js", "~/js/morris.js", "~/js/skycons.js", "~/js/bootstrap.js", "~/js/proton.js"));


            bundles.Add(new StyleBundle("~/Content/admin/css").Include(
                      "~/css/bootstrap.css", "~/css/style.css", //"//fonts.googleapis.com/css?family=Roboto:400,100,100italic,300,300italic,400italic,500,500italic,700,700italic,900,900italic",
                     "~/css/font.css", "~/css/font-awesome.css", "~/css/morris.css"));
        }





    }
    }

