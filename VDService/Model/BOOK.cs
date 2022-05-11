namespace VDService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOOKS")]
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            BOOK_AUTHOR = new HashSet<BOOK_AUTHOR>();
            BOOK_GENRE = new HashSet<BOOK_GENRE>();
            BOOK_TAG = new HashSet<BOOK_TAG>();
            FEEDBACKs = new HashSet<FEEDBACK>();
            PAINTs = new HashSet<PAINT>();
            USER_BOOKMARKS = new HashSet<USER_BOOKMARKS>();
        }

        public int Id { get; set; }

        [Required]
        public string BOOK_NAME { get; set; }

        public bool? BOOK_STATUS { get; set; }

        public string BOOK_SERIES { get; set; }

        public int ID_USER_ADD { get; set; }

        public string BOOK_DESCRIPTION { get; set; }

        public string BOOK_IMAGE { get; set; }

        public string BOOK_FILE { get; set; }

        public int? Chapters { get; set; }

        public int? DATA_RELEASE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOK_AUTHOR> BOOK_AUTHOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOK_GENRE> BOOK_GENRE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOK_TAG> BOOK_TAG { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK> FEEDBACKs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAINT> PAINTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_BOOKMARKS> USER_BOOKMARKS { get; set; }
    }
}
