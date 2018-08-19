namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Threading.Tasks;

	public partial class Garage
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Garage()
		{
			GaragePictures = new HashSet<GaragePicture>();
		}

		[Key]
		public Guid Guid { get; set; }

		public Guid VehicleGuid { get; set; }

		public Guid UserGuid { get; set; }

		public DateTime UpdateTimeStamp { get; set; }

		public DateTime CreateTimeStamp { get; set; }

		public int VisitorCount { get; set; }

		[Required]
		public string Title { get; set; }

		public GarageTypes GarageType { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<GaragePicture> GaragePictures { get; set; }

		public virtual User User { get; set; }

		public virtual Vehicle Vehicle { get; set; }

		//Methods
		#region Create
		public async static Task<Garage> Create(User user, Vehicle vehicle, String title)
		{
			return await Task.Run<Garage>(() =>
			{
				Garage result = new Garage();

				result.CreateTimeStamp = DateTime.UtcNow;
				result.Guid = Guid.NewGuid();
				result.GarageType = GarageTypes.Showroom;
				result.Title = title;
				result.UpdateTimeStamp = DateTime.UtcNow;
				result.User = user;
				result.Vehicle = vehicle;

				return result;
			});
		}
		#endregion
	}
}
