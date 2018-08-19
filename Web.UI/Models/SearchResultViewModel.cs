using ESolutions.Youmoto.Persistence;
using ESolutions.Youmoto.Web.UI.Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.Youmoto.Web.UI.Models
{
	public class SearchResultViewModel
	{
		//Classes
		#region SearchHitViewModel
		public class SearchHitViewModel
		{
			//Properties
			#region Guid
			[JsonProperty(PropertyName = "guid")]
			public Guid Guid
			{
				get;
				set;
			}
			#endregion

			#region Title
			[JsonProperty(PropertyName = "title")]
			public String Title
			{
				get;
				set;
			}
			#endregion

			#region TeaserImageUrl
			[JsonProperty(PropertyName = "teaserImageUrl")]
			public String TeaserImageUrl
			{
				get;
				set;
			}
			#endregion

			#region TargetUrl
			[JsonProperty(PropertyName = "targetUrl")]
			public String TargetUrl
			{
				get;
				set;
			}
			#endregion

			//Constructors
			#region SearchHitViewModel
			public SearchHitViewModel(Vehicle vehicle)
			{
				this.Guid = vehicle.Guid;
				this.Title = NameBuilder.BuildNames(vehicle).FirstOrDefault()?.Name;
				var teaserImage = vehicle.VehiclePictures
					.OrderBy(runner => runner.SortOrder)
					.Select(runner => runner.Picture)
					.FirstOrDefault();
				this.TeaserImageUrl = teaserImage == null ? $"./style/images/noimage.png" : $"./pictures/render/{teaserImage.Guid}";
				this.TargetUrl = $"./vehicles/details/{vehicle.Guid.ToShortString()}";
			}
			#endregion

			#region SearchHitViewModel
			public SearchHitViewModel(Garage garage)
			{
				this.Guid = garage.Guid;
				this.Title = garage.Title;
				var teaserImage = garage.GaragePictures
					.OrderBy(runner => runner.SortOrder)
					.Select(runner => runner.Picture)
					.FirstOrDefault();
				this.TeaserImageUrl = teaserImage == null ? $"./style/images/noimage.png" : $"./pictures/render/{teaserImage.Guid}";
				this.TargetUrl = $"./garages/details/{garage.Guid.ToShortString()}";
			}
			#endregion
		}
		#endregion

		//Properties
		#region SearchTerm
		[JsonProperty(PropertyName = "searchTerm")]
		public String SearchTerm
		{
			get;
			set;
		}
		#endregion

		#region SearchHits
		[JsonProperty(PropertyName = "searchHits")]
		public IEnumerable<SearchHitViewModel> SearchHits
		{
			get;
			set;
		}
		#endregion

		//Constructors
		#region SearchResultViewModel
		public SearchResultViewModel(SearchResult searchResult)
		{
			this.SearchTerm = searchResult.SearchTermParts;
			this.SearchHits =
				searchResult.Garages.Select(runner => new SearchHitViewModel(runner))
				.Union(searchResult.Vehicles.Select(x => new SearchHitViewModel(x)));
		}
		#endregion
	}
}