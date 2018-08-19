using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ESolutions.Youmoto.Web.UI.Logic;

namespace ESolutions.Youmoto.Web.UI.Models
{
	public class NewsViewModel
	{
		public class Preview
		{
			//Properties
			#region Guid
			/// <summary>
			/// Gets or sets the unique identifier.
			/// </summary>
			/// <value>
			/// The unique identifier.
			/// </value>
			[JsonProperty(PropertyName = "guid")]
			public Guid Guid
			{
				get;
				set;
			}
			#endregion

			#region Title
			/// <summary>
			/// Gets or sets the title.
			/// </summary>
			/// <value>
			/// The title.
			/// </value>
			[JsonProperty(PropertyName = "title")]
			public String Title
			{
				get;
				set;
			}
			#endregion

			#region Date
			/// <summary>
			/// Gets or sets the date.
			/// </summary>
			/// <value>
			/// The date.
			/// </value>
			[JsonProperty(PropertyName = "date")]
			public DateTime Date
			{
				get;
				set;
			}
			#endregion

			#region Text
			/// <summary>
			/// Gets or sets the text.
			/// </summary>
			/// <value>
			/// The text.
			/// </value>
			[JsonProperty(PropertyName = "text")]
			public String Text
			{
				get;
				set;
			}
			#endregion

			#region TextTeaser
			/// <summary>
			/// Gets or sets the text.
			/// </summary>
			/// <value>
			/// The text.
			/// </value>
			[JsonProperty(PropertyName = "textTeaser")]
			public String TextTeaser
			{
				get;
				set;
			}
			#endregion

			#region TeaserImageUrl
			/// <summary>
			/// Gets or sets the teaser image URL.
			/// </summary>
			/// <value>
			/// The teaser image URL.
			/// </value>
			[JsonProperty(PropertyName = "teaserImageUrl")]
			public String TeaserImageUrl
			{
				get;
				set;
			}
			#endregion

			//Constructor
			#region Preview
			public Preview(Persistence.News news)
			{
				this.Guid = news.Guid;
				this.Title = $"{news.Date.ToString("dd.MM.")} {news.Title}";
				this.Date = news.Date;
				this.Text = news.Text;

				this.TextTeaser = String.Concat(news.Text.Take(300).ToList()) + "...";
				this.TeaserImageUrl = news.NewsPictures.OrderBy(runner => runner.SortOrder).FirstOrDefault()?.ImageLink;
			}
			#endregion
		}

		public class Picture
		{
			#region Guid
			[JsonProperty(PropertyName = "guid")]
			public Guid Guid
			{
				get;
				set;
			} = Guid.NewGuid();
			#endregion

			#region ImageLink
			[JsonProperty(PropertyName = "imageLink")]
			public String ImageLink
			{
				get;
				set;
			} = String.Empty;
			#endregion
		}

		public class Vehicle
		{
			#region VehicleNewsGuid
			[JsonProperty(PropertyName = "vehicleNewsGuid")]
			public Guid VehicleNewsGuid
			{
				get;
				set;
			} = Guid.Empty;
			#endregion

			#region VehicleGuid
			[JsonProperty(PropertyName = "vehicleGuid")]
			public Guid VehicleGuid
			{
				get;
				set;
			} = Guid.Empty;
			#endregion

			#region Name
			[JsonProperty(PropertyName = "name")]
			public String Name
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region PictureGuid
			[JsonProperty(PropertyName = "pictureGuid")]
			public Guid? PictureGuid
			{
				get;
				set;
			}
			#endregion
		}

		public class Details
		{
			//Properties
			#region Guid
			[JsonProperty(PropertyName = "guid")]
			public Guid Guid
			{
				get;
				set;
			} = Guid.NewGuid();
			#endregion

			#region Date
			[JsonProperty(PropertyName = "date")]
			public DateTime Date
			{
				get;
				set;
			} = DateTime.UtcNow;
			#endregion

			#region Title
			[JsonProperty(PropertyName = "title")]
			public String Title
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region Text
			[JsonProperty(PropertyName = "text")]
			public String Text
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region SourceLink
			[JsonProperty(PropertyName = "sourceLink")]
			public String SourceLink
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region NewsPictures
			[JsonProperty(PropertyName = "newsPictures")]
			public IEnumerable<Picture> NewsPictures
			{
				get;
				set;
			} = new List<Picture>();
			#endregion

			#region NewsVehicles
			[JsonProperty(PropertyName = "newsVehicles")]
			public IEnumerable<Vehicle> NewsVehicles
			{
				get;
				set;
			} = new List<Vehicle>();
			#endregion

			//Constructors
			#region Details
			public Details(Persistence.News news)
			{
				this.Guid = news.Guid;
				this.Date = news.Date;
				this.Title = news.Title;
				this.Text = news.Text;
				this.SourceLink = news.SourceLink;
				this.NewsPictures = news.NewsPictures
					.OrderBy(runner => runner.SortOrder)
					.Select(runner => new Picture() { Guid = runner.Guid, ImageLink = runner.ImageLink });

				this.NewsVehicles = news.NewsVehicles
					.SelectMany(x => x.Vehicle.BuildNames()
						.Select(y => new Models.NewsViewModel.Vehicle()
						{
							VehicleNewsGuid = x.Guid,
							VehicleGuid = y.VehicleGuid,
							Name = y.Name,
							PictureGuid = y.PictureGuid
						}))
					.OrderBy(runner => runner.Name)
					.ToList();
			}
			#endregion

			//Methods
			#region ToJson
			public String ToJson()
			{
				return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Serialize,

				});
			}
			#endregion
		}
	}
}