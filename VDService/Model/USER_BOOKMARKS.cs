namespace VDService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_BOOKMARKS
    {
        public int USERId { get; set; }

        public int BOOKId { get; set; }

        [Required]
        [StringLength(25)]
        public string STATUS_READING { get; set; }

        public bool PRESENCE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DATA_READING { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATA_ADD { get; set; }

        public int? MARKS { get; set; }

        public int Id { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual USER USER { get; set; }
    }
}
