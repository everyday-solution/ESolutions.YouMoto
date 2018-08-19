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
	[HubName("vehicleHub")]
	public class VehicleHub : Hub
	{
		//Fields
		#region context
		private YoumotoDbContext context = null;
		#endregion

		//Constructor
		#region VehicleHub
		public VehicleHub() : base()
		{

		}
		#endregion

		#region VehicleHub
		public VehicleHub(YoumotoDbContext context)
		{
			this.context = context;
		}
		#endregion

		//Methods
		#region LoadVehiclesRandom
		[HubMethodName("loadVehiclesRandom")]
		public IEnumerable<VehicleViewModel.Preview> LoadVehiclesRandom(Int32 take = 5)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();
			return VehiclePersister
				.LoadRandomPaged(context, take)
				.Select(runner => new VehicleViewModel.Preview(runner));
		}
		#endregion

		#region LoadVehicles
		[HubMethodName("loadVehicles")]
		public IEnumerable<VehicleViewModel.Preview> LoadVehicles(Int32 skip = 0, Int32 take = 5)
		{
			YoumotoDbContext context = this.context ?? new YoumotoDbContext();
			return VehiclePersister
				.LoadPaged(context, skip, take)
				.Select(runner => new VehicleViewModel.Preview(runner));
		}
		#endregion
	}
}