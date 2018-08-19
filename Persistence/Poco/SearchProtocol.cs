namespace ESolutions.Youmoto.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SearchProtocol
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid? UserGuid { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        public string SearchTerm { get; set; }

        public int Hits { get; set; }
    }
}
