using System.Web;
using System.Web.Optimization;

namespace ESolutions.Youmoto.Web.UI
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/angular.min.js",
				"~/Scripts/angular-animate.min.js",
				"~/Scripts/angular-aria.min.js",
				"~/Scripts/angular-messages.min.js",
				"~/Scripts/angular-material.min.js",
				"~/Scripts/jquery-3.2.1.min.js",
				"~/Scripts/jquery.signalR-{version}.js",
				"~/Scripts/jquery.fancybox.min.js"
				));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.validate*"
				));

			bundles.Add(new StyleBundle("~/bundles/css").Include(
				"~/Style/screen.css",
				"~/Style/mobile.css",
				"~/Style/angular-material.min.css",
				"~/Style/jquery.fancybox.min.css"
				));
		}
	}
}
