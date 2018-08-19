namespace ESolutions.Youmoto.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ManufacturerVehicle
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid ManufacturerGuid { get; set; }

        public Guid VehicleGuid { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Vehicle Vehicle { get; set; }

		//Methods
		#region Create
		public static ManufacturerVehicle Create(Manufacturer manufacurer, Vehicle vehicle)
		{
			ManufacturerVehicle result = new ManufacturerVehicle();

			result.Guid = Guid.NewGuid();
			result.Manufacturer = manufacurer;
			result.Vehicle = vehicle;

			return result;
        }
		#endregion
	}
}
