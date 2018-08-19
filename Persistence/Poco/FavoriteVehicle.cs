namespace ESolutions.Youmoto.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FavoriteVehicle
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid UserGuid { get; set; }

        public Guid VehicleGuid { get; set; }

        public int LikeTypeEnum { get; set; }

        public virtual User User { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
