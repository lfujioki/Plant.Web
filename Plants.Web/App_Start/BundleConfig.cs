using System.Web;
using System.Web.Optimization;

namespace Plants.Web
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

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/ng/angular.js",
                    "~/Scripts/ng/angular-animate.js",
                    "~/Scripts/ng/angular-route.js",
                    "~/Scripts/ng-toastr/angular-toastr.js",
                    "~/Scripts/ng-toastr/angular-toastr.tpls.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/bootstrap.css",
                   "~/Content/site.css",
                   "~/Content/angular-toastr.css"));


            //  Starter application
            //  ------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/starter/base").Include(
                    "~/Scripts/myApp.js"));

            bundles.Add(new ScriptBundle("~/starter/core").Include(
                    "~/Scripts/myApp.module.js",
                    "~/Scripts/core/controllers/*.js",
                    "~/Scripts/core/services/*.js"));


            BundleTable.EnableOptimizations = false;
        }
    }
}
