namespace VDService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BOOK_TAG
    {
        public int BOOKId { get; set; }

        public int TAGId { get; set; }

        public int Id { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual TAG TAG { get; set; }
    }
}
