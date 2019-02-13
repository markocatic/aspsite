using System.Web;
using System.Web.Optimization;

namespace AspSite
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/styles").Include(
                      "~/Content/Style/bootstrap-site.css",
                      "~/Content/Style/style.css"));
            bundles.Add(new ScriptBundle("~/bundles/animations").Include(
                "~/Scripts/Animations/jquery-1.11.1.min.js",
                      "~/Scripts/Animations/bootstrap.min.js",
                      "~/Scripts/Animations/mojstil.js"
                      
                       //"~/Scripts/Animations/Slider/bootstrap-hover-dropdown.js",
                       //"~/Scripts/Animations/Slider/front.js",
                       //"~/Scripts/Animations/Slider/jquery.cookie.js",
                       //"~/Scripts/Animations/Slider/jquery.flexslider.js",
                       //"~/Scripts/Animations/Slider/jquery.flexslider.min.js",
                       //"~/Scripts/Animations/Slider/main.js",
                       //"~/Scripts/Animations/Slider/modernizr",
                       //"~/Scripts/Animations/Slider/owl.carousel.min.js",
                       //"~/Scripts/Animations/Slider/respond.min.js",
                       //"~/Scripts/Animations/Slider/waypoints.min.js"
                       ));
            bundles.Add(new StyleBundle("~/Content/cssstil").Include(
                      "~/Content/Style/Slider/font-awesome.css",
                      "~/Content/Style/Slider/bootstrap.min.css",
                      "~/Content/Style/Slider/animate.min.css",
                      "~/Content/Style/Slider/owl.carousel.css",
                     "~/Content/Style/Slider/owl.theme.css",
                      "~/Content/Style/Slider/style.default.css",
                      "~/Content/Style/Slider/custom.css"
                      ));
        }
    }
}
