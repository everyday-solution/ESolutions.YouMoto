namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Linq;
	using Newtonsoft.Json;

	public partial class NewsPicture
	{
		//Properties
		#region Guid
		[Key]
		[JsonProperty(PropertyName ="guid")]
		public Guid Guid { get; set; }
		#endregion

		#region NewsGuid
		[JsonProperty(PropertyName = "newsGuid")]
		public Guid NewsGuid { get; set; }
		#endregion

		#region ImageLink
		[Required]
		[JsonProperty(PropertyName = "imageLink")]
		public string ImageLink { get; set; }
		#endregion

		#region SortOrder
		[JsonProperty(PropertyName = "sortOrder")]
		public int SortOrder { get; set; }
		#endregion

		#region News
		[JsonIgnore]
		public virtual News News { get; set; }
		#endregion
	}
}
