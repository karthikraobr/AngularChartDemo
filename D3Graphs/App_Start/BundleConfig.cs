using System.Web;
using System.Web.Optimization;

namespace D3Graphs
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                     "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/angular.min.js",
                        "~/Scripts/ui-grid.min.js",
                        "~/Scripts/Chart.min.js",
                        "~/Scripts/angular-chart.min.js",
                        "~/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                         "~/Content/ui-grid.min.css",
                         "~/Content/bootstrap.css",
                        "~/Content/angular-chart.css"));
        }
    }
}
