namespace ESolutions.Youmoto.Persistence
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using Newtonsoft.Json;
	using System.Linq;

	public partial class NewsVehicle
	{
		[Key]
		public Guid Guid { get; set; }

		public Guid NewsGuid { get; set; }

		public Guid VehicleGuid { get; set; }

		public int SortOrder { get; set; }

		[JsonIgnore]
		public virtual News News { get; set; }

		[JsonIgnore]
		public virtual Vehicle Vehicle { get; set; }
	}
}
