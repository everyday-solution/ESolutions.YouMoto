using ESolutions.Youmoto.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESolutions.Youmoto.Web.UI.Models;
using ESolutions.Youmoto.Persistence.Persister;

namespace ESolutions.Youmoto.Web.UI.Controllers
{
	public class NewsController : Controller
	{
		#region Index
		public ActionResult Index(GarageTypes? type)
		{
			return View();
		}
		#endregion

		#region Details
		public ActionResult Details(Guid guid)
		{
			YoumotoDbContext context = new YoumotoDbContext();
			var news = NewsPersister.LoadSingle(context, guid);
			var viewModel = new NewsViewModel.Details(news);
			return View(viewModel);
		}
		#endregion
	}
}