namespace VDService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FEEDBACK")]
    public partial class FEEDBACK
    {
        public int Id { get; set; }

        public int ID_USER { get; set; }

        public int ID_BOOK { get; set; }

        [Column("FEEDBACK")]
        public string FEEDBACK1 { get; set; }

        public float RATING { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DATE { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual USER USER { get; set; }
    }
}
