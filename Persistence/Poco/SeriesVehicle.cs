namespace ESolutions.Youmoto.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SeriesVehicle
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid SeriesGuid { get; set; }

        public Guid VehicleGuid { get; set; }

        public virtual Series Series { get; set; }

        public virtual Vehicle Vehicle { get; set; }

		//Methods
		#region Create
		public static SeriesVehicle Create(Series series, Vehicle vehicle)
		{
			SeriesVehicle result = new SeriesVehicle();

			result.Guid = Guid.NewGuid();
			result.Series = series;
			result.Vehicle = vehicle;

			return result;
		}
		#endregion
	}
}
