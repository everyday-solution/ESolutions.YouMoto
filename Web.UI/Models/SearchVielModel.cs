using ESolutions.Youmoto.Web.UI.Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.Youmoto.Web.UI.Models
{
	public class SearchVielModel
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
			public Guid? TeaserImageGuid
			{
				get;
				set;
			} = null;
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
			public Preview(Persistence.Vehicle vehicle)
			{
				this.Guid = vehicle.Guid;
				this.Title = vehicle.BuildNames().FirstOrDefault()?.Name;
				this.Date = vehicle.CreateTimeStamp;

				var teaser = vehicle.VehiclePictures.OrderBy(runner => runner.SortOrder).FirstOrDefault();

				if (teaser != null)
				{
					this.TextTeaser = String.Concat(teaser.Text.Take(300).ToList()) + "...";
					this.TeaserImageGuid = teaser.PictureGuid;
				}
			}
			#endregion
		}
	}
}