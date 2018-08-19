using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ESolutions.Youmoto.Persistence;
using ESolutions.Youmoto.Persistence.Persister;
using ESolutions.Youmoto.Web.UI.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ESolutions.Youmoto.Web.UI.Hubs
{
	[HubName("manufacturerHub")]
	public class ManufacturerHub : Hub
	{
		//Fields
		#region context
		private YoumotoDbContext context = null;
		#endregion

		//Constructor
		#region ManufacturerHub
		public ManufacturerHub() : base()
		{

		}
		#endregion

		#region ManufacturerHub
		public ManufacturerHub(YoumotoDbContext context)
		{
			this.context = context;
		}
		#endregion

		//Methods
		#region LoadManufacturers
		[HubMethodName("loadManufacturers")]
		public IEnumerable<ManufacturerViewModel.Preview> LoadManufacturers(Int32 skip = 0, Int32 take = 5)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();
			return ManufacturerPersister
				.LoadPaged(context, skip, take)
				.Select(runner => new ManufacturerViewModel.Preview(runner))
				.ToList();
		}
		#endregion
	}
}