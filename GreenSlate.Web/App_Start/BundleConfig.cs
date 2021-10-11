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
            //"~/3rdParty/require.js/require.js",
            "~/3rdParty/bootstrap/js/bootstrap.min.js",
            "~/3rdParty/lodash.js/lodash.min.js",
            "~/3rdParty/pubsub-js/pubsub.min.js",
            "~/3rdParty/kendo-ui-core/js/kendo.modrnizr.custom.js",
            "~/SPA/Scripts/GridRowStyling.js",
            "~/SPA/Scripts/antiForgeryToken.js"

            ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

        }
    }
}
