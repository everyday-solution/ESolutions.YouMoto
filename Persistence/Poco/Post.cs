namespace ESolutions.Youmoto.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Posts1 = new HashSet<Post>();
        }

        [Key]
        public Guid Guid { get; set; }

        public DateTime TimeStamp { get; set; }

        public Guid SenderUserGuid { get; set; }

        public Guid? ReceiverUserGuid { get; set; }

        public int? ForeignTypeEnum { get; set; }

        public Guid? ForeignTypeGuid { get; set; }

        [Required]
        public string Message { get; set; }

        public Guid? ParentPostGuid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts1 { get; set; }

        public virtual Post Post1 { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
