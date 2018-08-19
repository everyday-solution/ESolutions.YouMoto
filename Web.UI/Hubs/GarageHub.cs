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
	[HubName("garageHub")]
	public class GarageHub : Hub
	{
		//Methods
		#region context
		private YoumotoDbContext context = null;
		#endregion

		//Constructor
		#region GarageHub
		public GarageHub() : base()
		{

		}
		#endregion

		#region GarageHub
		public GarageHub(YoumotoDbContext context)
		{
			this.context = context;
		}
		#endregion

		//Methods
		#region LoadGarages
		[HubMethodName("loadGarages")]
		public IEnumerable<GarageViewModels.Preview> LoadGarages(GarageTypes garageType, Int32 skip = 0, Int32 take = 5)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();
			return GaragePersister
				.LoadRandomPaged(context, garageType, skip, take)
				.Select(runner => new GarageViewModels.Preview(runner));
		}
		#endregion

		#region LoadGarages
		[HubMethodName("loadGarages")]
		public IEnumerable<GarageViewModels.Preview> LoadGarages(Int32 skip = 0, Int32 take = 5)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();
			return GaragePersister
				.LoadRandomPaged(context, GarageTypes.Any, skip, take)
				.Select(runner => new GarageViewModels.Preview(runner));
		}
		#endregion
	}
}