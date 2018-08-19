using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ESolutions.Youmoto.Persistence;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ESolutions.Youmoto.Web.UI.Models;

namespace ESolutions.Youmoto.Web.UI.Hubs
{
	[HubName("searchHub")]
	public class SearchHub : Hub
	{
		//Methods
		#region context
		private YoumotoDbContext context = null;
		#endregion

		//Constructor
		#region SearchHub
		public SearchHub() : base()
		{

		}
		#endregion

		#region SearchHub
		public SearchHub(YoumotoDbContext context)
		{
			this.context = context;
		}
		#endregion

		//Methods
		#region Search
		[HubMethodName("search")]
		public SearchResultViewModel Search(String searchTerm, Int32 skip, Int32 take)
		{
			YoumotoDbContext context = new YoumotoDbContext();
			var searchResult = Searcher.PerformFreetextSearch(context, searchTerm, skip, take);
			return new SearchResultViewModel(searchResult);
		}
		#endregion

		#region SearchVehicles
		[HubMethodName("searchVehicles")]
		public IEnumerable<VehicleSearchViewModel> SearchVehicles(String searchTerm)
		{
			YoumotoDbContext context = new YoumotoDbContext();
			var result = Searcher.PerformVehicleSearch(context, searchTerm);
			return result.Select(runner => new Models.VehicleSearchViewModel()
			{
				Guid = runner.Guid,
				Fullname = runner.Fullname
			});
		}
		#endregion
	}
}