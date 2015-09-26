using System.Web;
using System.Web.Optimization;

namespace AERHiPets
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

          /* bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));*/

           bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-1.11.4.min.js"));

            bundles.Add(new StyleBundle("~/Content/themes/south-street/css").Include(
              "~/Content/themes/south-street/jquery.ui.css",
              "~/Content/themes/south-street/jquery.ui.all.css",
              "~/Content/themes/south-street/jquery.ui.datepicker.css",
              "~/Content/themes/south-street/jquery.ui.core.css",
              "~/Content/themes/south-street/jquery.ui.resizable.css",
              "~/Content/themes/south-street/jquery.ui.selectable.css",
              "~/Content/themes/south-street/jquery.ui.accordion.css",
              "~/Content/themes/south-street/jquery.ui.autocomplete.css",
              "~/Content/themes/south-street/jquery.ui.button.css",
              "~/Content/themes/south-street/jquery.ui.dialog.css",
              "~/Content/themes/south-street/jquery.ui.slider.css",
              "~/Content/themes/south-street/jquery.ui.tabs.css",
              "~/Content/themes/south-street/jquery.ui.datepicker.css",
              "~/Content/themes/south-street/jquery.ui.progressbar.css",
              "~/Content/themes/south-street/jquery.ui.theme.css"));
            
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
              "~/Content/themes/base/all.css",
              "~/Content/themes/base/core.css",
              "~/Content/themes/base/resizable.css",
              "~/Content/themes/base/selectable.css",
              "~/Content/themes/base/accordion.css",
              "~/Content/themes/base/autocomplete.css",
              "~/Content/themes/base/button.css",
              "~/Content/themes/base/dialog.css",
              "~/Content/themes/base/slider.css",
              "~/Content/themes/base/tabs.css",
              "~/Content/themes/base/datepicker.css",
              "~/Content/themes/base/progressbar.css",
              "~/Content/themes/base/theme.css"));
        }
    }
}
