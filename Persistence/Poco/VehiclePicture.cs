namespace ESolutions.Youmoto.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehiclePicture
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid VehicleGuid { get; set; }

        public Guid PictureGuid { get; set; }

        public int SortOrder { get; set; }

        [Required]
        public string Text { get; set; }

        public bool IsTeaser { get; set; }

        public DateTime UpdateTimeStamp { get; set; }

        public DateTime CreateTimeStamp { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
