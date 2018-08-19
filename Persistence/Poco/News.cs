namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Diagnostics;
	using System.Linq;
	using Newtonsoft.Json;

	[DebuggerDisplay("News: {Title}")]
	public partial class News
	{
		//Properties
		#region Guid
		/// <summary>
		/// Gets or sets the unique identifier.
		/// </summary>
		/// <value>
		/// The unique identifier.
		/// </value>
		[Key]
		[JsonProperty(PropertyName = "guid")]
		public Guid Guid { get; set; }
		#endregion

		#region Date
		/// <summary>
		/// Gets or sets the date the news was issued
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
		[JsonProperty(PropertyName = "date")]
		public DateTime Date { get; set; }
		#endregion

		#region Title
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		[Required]
		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }
		#endregion

		#region Text
		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>
		/// The text.
		/// </value>
		[Required(AllowEmptyStrings = true)]
		[JsonProperty(PropertyName = "text")]
		public string Text { get; set; }
		#endregion

		#region SourceLink
		/// <summary>
		/// Gets or sets the link to the articles source
		/// </summary>
		/// <value>
		/// The source link.
		/// </value>
		[Required(AllowEmptyStrings = true)]
		[JsonProperty(PropertyName = "sourceLink")]
		public string SourceLink { get; set; }
		#endregion

		#region UpdateTimeStamp
		/// <summary>
		/// Gets or sets the update time stamp.
		/// </summary>
		/// <value>
		/// The update time stamp.
		/// </value>
		[JsonProperty(PropertyName = "updateTimeStamp")]
		public DateTime UpdateTimeStamp { get; set; }
		#endregion

		#region CreateTimeStamp
		/// <summary>
		/// Gets or sets the create time stamp.
		/// </summary>
		/// <value>
		/// The create time stamp.
		/// </value>
		[JsonProperty(PropertyName = "createTimeStamp")]
		public DateTime CreateTimeStamp { get; set; }
		#endregion

		#region NewsPictures
		/// <summary>
		/// Gets or sets the pictures associated to the news
		/// </summary>
		/// <value>
		/// The news pictures.
		/// </value>
		[JsonProperty(PropertyName = "newsPictures")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<NewsPicture> NewsPictures { get; set; }
		#endregion

		#region NewsVehicles
		/// <summary>
		/// Gets or sets the vehicles associated to the news article
		/// </summary>
		/// <value>
		/// The news vehicles.
		/// </value>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[JsonProperty(PropertyName = "newsVehicles")]
		public virtual ICollection<NewsVehicle> NewsVehicles { get; set; }
		#endregion

		//Constructors
		#region News
		/// <summary>
		/// Initializes a new instance of the <see cref="News"/> class.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public News()
		{
			NewsPictures = new HashSet<NewsPicture>();
			NewsVehicles = new HashSet<NewsVehicle>();
		}
		#endregion
	}
}
