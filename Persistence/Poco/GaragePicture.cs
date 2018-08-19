namespace ESolutions.Youmoto.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GaragePicture
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid GarageGuid { get; set; }

        [Required]
        public string Text { get; set; }

        public Guid PictureGuid { get; set; }

        public DateTime CreateTimeStamp { get; set; }

        public DateTime UpdateTimeStamp { get; set; }

        public int SortOrder { get; set; }

        public virtual Garage Garage { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
