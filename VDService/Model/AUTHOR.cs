namespace VDService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUTHORS")]
    public partial class AUTHOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTHOR()
        {
            BOOK_AUTHOR = new HashSet<BOOK_AUTHOR>();
            SUBSCRIPTIONs = new HashSet<SUBSCRIPTION>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string AUTHOR_NAME { get; set; }

        [StringLength(50)]
        public string COUNTRY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOK_AUTHOR> BOOK_AUTHOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBSCRIPTION> SUBSCRIPTIONs { get; set; }
    }
}
