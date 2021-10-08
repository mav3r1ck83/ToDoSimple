using System.Web;
using System.Web.Optimization;

namespace GreenSlate.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new StyleBundle("~/bundle/css").Include(
                     "~/3rdParty/bootstrap/css/bootstrap.min.css",
                    "~/SPA/Style/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
            "~/3rdParty/kendo-ui-core/js/jquery.min.js",
            "~/3rdParty/kendo-ui-core/js/jszip.min.js",
            "~/3rdParty/kendo-ui-core/js/kendo.all.min.js",
            "~/3rdParty/kendo-ui-core/js/kendo.aspnetmvc.min.js",
            "~/3rdParty/requiree.js/require.min.js",
            "~/3rdParty/bootstrap/js/bootstrap.min.js",
            "~/3rdParty/lodash.js/lodash.min.js",
            "~/3rdParty/pubsub-js/pubsub.min.js",
            "~/3rdParty/kendo-ui-core/js/kendo.modrnizr.custom.js",
            "~/SPA/Scripts/GridRowStyling.js"

            ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //         "~/Content/bootstrap.css",
            //         "~/Content/Site.css"));
        }
    }
}
