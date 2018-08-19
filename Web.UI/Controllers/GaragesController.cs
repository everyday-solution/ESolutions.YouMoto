using ESolutions.Youmoto.Persistence;
using ESolutions.Youmoto.Persistence.Persister;
using ESolutions.Youmoto.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESolutions.Youmoto.Web.UI.Controllers
{
	public class GaragesController : Controller
	{
		#region Index
		public ActionResult Index(GarageTypes? type)
		{
			this.ViewBag.GarageType = type ?? GarageTypes.Showroom;
			return View();
		}
		#endregion

		#region Details
		public ActionResult Details(Guid guid)
		{
			YoumotoDbContext context = new YoumotoDbContext();
			var garage = GaragePersister.LoadSingle(context, guid);
			var viewModel = new GarageViewModels.Details(garage);
			return View(viewModel);
		}
		#endregion
	}
}