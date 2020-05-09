using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCDay2
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/Scripts").Include(
                "~/scripts/jquery-3.0.0.min.js",
                "~/scripts/bootstrap.min.js",
                "~/scripts/jquery.validate.min.js",
                "~/scripts/jquery.validate.unobtrusive.min.js",
                "~/scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/SiteScripts/site.js"

                ));
            bundles.Add(new StyleBundle("~/Bundles/Styles").Include("~/Content/bootstrap.min.css"));
        }

    }
}