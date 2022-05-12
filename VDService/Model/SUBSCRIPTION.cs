namespace VDService.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

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
