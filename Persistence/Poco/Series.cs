namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class Series
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Series()
		{
			SeriesVehicles = new HashSet<SeriesVehicle>();
		}

		[Key]
		public Guid Guid { get; set; }

		public Guid ManufacturerGuid { get; set; }

		[Required]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string Text { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string Nickname { get; set; }

		public DateTime CreateTimeStamp { get; set; }

		public DateTime UpdateTimeStamp { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string WikipediaLink { get; set; }

		public string TraumautoUrl { get; set; }

		public virtual Manufacturer Manufacturer { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<SeriesVehicle> SeriesVehicles { get; set; }

		//Methods
		#region Create
		public static Series Create(Manufacturer manufacturer, String name)
		{
			Series result = new Series();

			result.CreateTimeStamp = DateTime.UtcNow;
			result.Guid = Guid.NewGuid();
			result.Manufacturer = manufacturer;
			result.Name = name;
			result.Nickname = String.Empty;
			result.Text = String.Empty;
			result.TraumautoUrl = String.Empty;
			result.UpdateTimeStamp = DateTime.UtcNow;
			result.WikipediaLink = String.Empty;

			return result;
		}
		#endregion
	}
}
