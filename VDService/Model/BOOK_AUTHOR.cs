namespace VDService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BOOK_AUTHOR
    {
        public int BOOKId { get; set; }

        public int AUTHORId { get; set; }

        public int Id { get; set; }

        public virtual AUTHOR AUTHOR { get; set; }

        public virtual BOOK BOOK { get; set; }
    }
}
