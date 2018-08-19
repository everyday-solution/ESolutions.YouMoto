namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Drawing;
	using System.IO;
	using System.Linq;

	public partial class Picture
	{
		#region Guid
		[Key]
		public Guid Guid { get; set; }
		#endregion

		#region PictureSourceGuid
		public Guid? PictureSourceGuid { get; set; }
		#endregion

		#region UpdateTimeStamp
		public DateTime UpdateTimeStamp { get; set; }
		#endregion

		#region CreateTimeStamp
		public DateTime CreateTimeStamp { get; set; }
		#endregion

		#region TraumautoUrl
		public string TraumautoUrl { get; set; }
		#endregion

		#region GaragePictures
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<GaragePicture> GaragePictures { get; set; }
		#endregion

		#region Manufacturers
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Manufacturer> Manufacturers { get; set; }
		#endregion

		#region PictureSource
		public virtual PictureSource PictureSource { get; set; }
		#endregion

		#region PictureSources
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<PictureSource> PictureSources { get; set; }
		#endregion

		#region Users
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<User> Users { get; set; }
		#endregion

		#region VehiclePictures
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<VehiclePicture> VehiclePictures { get; set; }
		#endregion

		//Constructors
		#region Picture
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Picture()
		{
			GaragePictures = new HashSet<GaragePicture>();
			Manufacturers = new HashSet<Manufacturer>();
			PictureSources = new HashSet<PictureSource>();
			Users = new HashSet<User>();
			VehiclePictures = new HashSet<VehiclePicture>();
		}
		#endregion
	}
}
