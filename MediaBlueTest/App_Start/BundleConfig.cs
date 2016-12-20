using System.Web;
using System.Web.Optimization;

namespace MediaBlueTest
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Create a javascript bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //Create our css bundle
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));

            //Set whether we want to optimize/minify our documents
            if (HttpContext.Current.IsDebuggingEnabled)
                BundleTable.EnableOptimizations = false;
            else
                BundleTable.EnableOptimizations = true;
        }
    }
}
