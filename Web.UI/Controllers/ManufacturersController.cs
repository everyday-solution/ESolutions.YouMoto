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
	public class ManufacturersController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Details(Guid guid)
		{
			YoumotoDbContext context = new YoumotoDbContext();
			var manufacturer = ManufacturerPersister.LoadSingle(context, guid);
			return this.View(new ManufacturerViewModel.Details(manufacturer));
		}
	}
}