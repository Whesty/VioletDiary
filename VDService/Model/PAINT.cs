namespace VDService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAINT")]
    public partial class PAINT
    {
        public int Id { get; set; }

        public int ID_ARTIST { get; set; }

        public int ID_BOOK { get; set; }

        public int ID_USER_ADD { get; set; }

        public string LINK { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DATA { get; set; }

        public virtual ARTIST ARTIST { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual USER USER { get; set; }
    }
}
