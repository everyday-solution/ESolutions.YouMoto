namespace ESolutions.Youmoto.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleVideo
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid VehicleGuid { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime CreateTimeStamp { get; set; }

        public DateTime UpdateTimeStamp { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
