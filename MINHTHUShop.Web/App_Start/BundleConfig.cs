using System.Web;
using System.Web.Optimization;

namespace MINHTHUShop.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/jquery")
                    .Include("~/Content/Client/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/js/plugins")
                    .Include(
                        "~/Content/Client/lib/jqueryui/jquery-ui.min.js",
                        "~/Content/Client/lib/mustache.js/mustache.js",
                        "~/Content/Client/lib/numeral.js/numeral.min.js",
                        "~/Content/Client/lib/jquery-validate/jquery.validate.js",
                        "~/Content/Client/lib/jquery-validate/additional-methods.min.js",
                        "~/Content/Client/js/common.js"
                    ));

            bundles.Add(new StyleBundle("~/css/base")
                    .Include("~/Content/Client/css/bootstrap.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Client/fontawesome-free-5.15.4-web/css/fontawesome.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Client/lib/jqueryui/themes/smoothness/jquery-ui.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Client/css/style.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Client/css/custom.css", new CssRewriteUrlTransform())
                    );

            BundleTable.EnableOptimizations = true;
            /*bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));*/
        }
    }
}
