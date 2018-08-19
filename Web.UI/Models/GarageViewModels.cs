using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ESolutions.Youmoto.Web.UI.Logic;

namespace ESolutions.Youmoto.Web.UI.Models
{
	public class GarageViewModels
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
			} = Guid.Empty;
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
			} = String.Empty;
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
			} = String.Empty;
			#endregion

			#region TeaserImageGuid
			/// <summary>
			/// Gets or sets the teaser image URL.
			/// </summary>
			/// <value>
			/// The teaser image URL.
			/// </value>
			[JsonProperty(PropertyName = "teaserImageGuid")]
			public Guid TeaserImageGuid
			{
				get;
				set;
			} = Guid.Empty;
			#endregion

			#region Author
			public String Author
			{
				get;
				set;
			} = String.Empty;
			#endregion

			//Constructor
			#region Preview
			public Preview(Persistence.Garage garage)
			{
				this.Guid = garage.Guid;
				this.Title = garage.Title;
				this.Date = garage.CreateTimeStamp;

				var teaser = garage.GaragePictures.OrderBy(runner => runner.SortOrder).FirstOrDefault();

				if (teaser != null)
				{
					this.TextTeaser = String.Concat(teaser.Text.Take(300).ToList()) + "...";
					this.TeaserImageGuid = teaser.PictureGuid;
				}
			}
			#endregion
		}

		public class NewsPicture
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

		public class GaragePictureViewModel
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

			#region ImageLink
			[JsonProperty(PropertyName = "pictureGuid")]
			public Guid PictureGuid
			{
				get;
				set;
			} = Guid.Empty;
			#endregion

			#region Text
			[JsonProperty(PropertyName = "text")]
			public String Text
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region TextTeaser
			[JsonProperty(PropertyName = "textTeaser")]
			public String TextTeaser
			{
				get;
				set;
			}
			#endregion

			//Constructors
			#region 
			public GaragePictureViewModel(Persistence.GaragePicture garage)
			{
				this.Guid = garage.Guid;
				this.PictureGuid = garage.PictureGuid;
				this.Text = garage.Text;
				this.TextTeaser = garage.Text.Split(". ").FirstOrDefault() ?? String.Empty;
			}
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

			#region SourceLink
			[JsonProperty(PropertyName = "sourceTitle")]
			public String SourceLink
			{
				get;
				set;
			} = String.Empty;
			#endregion

			#region GaragePictures
			[JsonProperty(PropertyName = "newsPictures")]
			public IEnumerable<GaragePictureViewModel> GaragePictures
			{
				get;
				set;
			} = new List<GaragePictureViewModel>();
			#endregion

			//Constructors
			#region Details
			public Details(Persistence.Garage garages)
			{
				this.Guid = garages.Guid;
				this.Date = garages.CreateTimeStamp;
				this.Title = garages.Title;
				this.GaragePictures = garages.GaragePictures
					.OrderBy(runner => runner.SortOrder)
					.Select(runner => new GaragePictureViewModel(runner));
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