namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class Manufacturer
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Manufacturer()
		{
			ManufacturerVehicles = new HashSet<ManufacturerVehicle>();
			Series = new HashSet<Series>();
		}

		[Key]
		public Guid Guid { get; set; }

		[Required]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string HomepageLink { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string WikipediaLink { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string Text { get; set; }

		public DateTime CreateTimeStamp { get; set; }

		public DateTime UpdateTimeStamp { get; set; }

		public Guid? PictureGuid { get; set; }

		public Guid? CountryGuid { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string InternetLinks { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string RelatedManufacturers { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string Address { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string Notes { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string PeriodOfActivity { get; set; }

		public int ClickCount { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string TraumautoUrl { get; set; }

		public virtual Country Country { get; set; }

		public virtual Picture Picture { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<ManufacturerVehicle> ManufacturerVehicles { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Series> Series { get; set; }

		//Methods
		#region Create
		public static Manufacturer Create(String name)
		{
			Manufacturer result = new Manufacturer();

			result.Address = String.Empty;
			result.CreateTimeStamp = DateTime.UtcNow;
			result.Guid = Guid.NewGuid();
			result.HomepageLink = String.Empty;
			result.InternetLinks = String.Empty;
			result.Name = name;
			result.Notes = String.Empty;
			result.PeriodOfActivity = String.Empty;
			result.RelatedManufacturers = String.Empty;
			result.Text = String.Empty;
			result.TraumautoUrl = String.Empty;
			result.UpdateTimeStamp = DateTime.UtcNow;
			result.WikipediaLink = String.Empty;

			return result;
		}
		#endregion
	}
}
