namespace VDService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BOOK_GENRE
    {
        public int BOOKId { get; set; }

        public int GENREId { get; set; }

        public int Id { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual GENRE GENRE { get; set; }
    }
}
