namespace VDService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUBSCRIPTION")]
    public partial class SUBSCRIPTION
    {
        public int USERId { get; set; }

        public int AUTHORId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DATA_SUB { get; set; }

        public int Id { get; set; }

        public virtual AUTHOR AUTHOR { get; set; }

        public virtual USER USER { get; set; }
    }
}
