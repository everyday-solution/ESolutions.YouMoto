using ESolutions.Youmoto.Persistence;
using ESolutions.Youmoto.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESolutions.Youmoto.Web.UI.Controllers
{
	public class SearchController : Controller
	{
		#region Index
		[HttpGet]
		[ActionName("Index")]
		public ActionResult IndexGet()
		{
			return this.RedirectToAction("Index", "Home");
		}
		#endregion

		#region Index
		[HttpPost]
		public ActionResult Index(String searchTerm)
		{
			this.ViewBag.SearchTerm = searchTerm;
			return View();
		}
		#endregion
	}
}