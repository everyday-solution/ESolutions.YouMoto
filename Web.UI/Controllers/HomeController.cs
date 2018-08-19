using ESolutions.Youmoto.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESolutions.Youmoto.Web.UI.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (this.Request.Url.Query == "?adminmode")
			{
				this.ViewBag.AdminMode = true;
			}
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}