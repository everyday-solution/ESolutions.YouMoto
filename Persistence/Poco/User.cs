namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Security.Principal;

	public partial class User
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public User()
		{
			FavoriteVehicles = new HashSet<FavoriteVehicle>();
			Garages = new HashSet<Garage>();
			Posts = new HashSet<Post>();
			Posts1 = new HashSet<Post>();
		}

		[Key]
		public Guid Guid { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		public bool IsAdmin { get; set; }

		public int LoginAttempts { get; set; }

		public Guid ActivationCode { get; set; }

		public bool IsActivated { get; set; }

		[Required]
		public string Displayname { get; set; }

		public Guid? PasswordResetCode { get; set; }

		public Guid? ProfilePictureGuid { get; set; }

		[Required]
		public string AboutMe { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<FavoriteVehicle> FavoriteVehicles { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Garage> Garages { get; set; }

		public virtual Picture Picture { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Post> Posts { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Post> Posts1 { get; set; }

		public static User Get(IPrincipal principal)
		{
			return null;
		}
	}
}
