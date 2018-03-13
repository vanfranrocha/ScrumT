using System.Web;
using System.Web.Optimization;

namespace Ferramenta_Scrumt
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
                      "~/Scripts/jquery.multi-select.js",
                      "~/Scripts/jquery-ui-1.9.2.custom.min.js",
                      "~/Scripts/jquery-migrate-1.2.1.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/modernizr.min.js",
                      "~/Scripts/jquery.nicescroll.js",
                      "~/Scripts/sparkline/jquery.sparkline.js",
                      "~/Scripts/sparkline/sparkline-init.js",
                      "~/Scripts/iCheck/jquery.icheck.js",
                      "~/Scripts/icheck-init.js",
                      "~/Scripts/flot-chart/jquery.flot.js",
                      "~/Scripts/flot-chart/jquery.flot.min.js",
                      "~/Scripts/flot-chart/jquery.flot.tooltip.min.js",
                      "~/Scripts/flot-chart/jquery.flot.resize.js",
                      "~/Scripts/flot-chart/jquery.flot.pie.js",
                      "~/Scripts/flot-chart/jquery.flot.pie.resize.js",
                      "~/Scripts/flot-chart/jquery.flot.selection.js",
                      "~/Scripts/flot-chart/jquery.flot.stack.js",
                      "~/Scripts/fullcalendar/fullcalendar.min.js",
                      "~/Scripts/external-dragging-calendar.js",
                      "~/Scripts/flot-chart/jquery.flot.time.js",
                      "~/Scripts/flot.chart.init.js",
                      "~/Scripts/scripts.js"                     
                       ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/multi-select.css",
                      "~/Scripts/fullcalendar/bootstrap-fullcalendar.css",
                      "~/Content/clndr.css",
                      "~/fonts/icomoon.css",
                      "~/Content/style.css",
                      "~/Content/custom-ico-fonts.css",
                      "~/Content/partial-nucleo-icons.css",
                      "~/Content/style-responsive.css",
                      "~/Content/timeline.css",
                      "~/Content/bootstrap-reset.css",
                      "~/Scripts/iCheck/skins/minimal/minimal.css",
                      "~/Scripts/iCheck/skins/square/square.css",
                      "~/Scripts/iCheck/skins/minimal/red.css",
                      "~/Scripts/iCheck/skins/minimal/blue.css"
                      ));
        }
    }
}
