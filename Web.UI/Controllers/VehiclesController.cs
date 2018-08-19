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
	public class VehiclesController : Controller
	{
		#region Index
		public ActionResult Index()
		{
			return View();
		}
		#endregion

		#region Details
		public ActionResult Details(Guid guid)
		{
			var context = new YoumotoDbContext();
			var vehicle = VehiclePersister.LoadSingle(context, guid);
			return View(new VehicleViewModel.Details(vehicle));
		}
		#endregion
	}
}