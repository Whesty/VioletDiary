namespace VDService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            BOOKS = new HashSet<BOOK>();
            FEEDBACKs = new HashSet<FEEDBACK>();
            PAINTs = new HashSet<PAINT>();
            SUBSCRIPTIONs = new HashSet<SUBSCRIPTION>();
            USER_BOOKMARKS = new HashSet<USER_BOOKMARKS>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_NAME { get; set; }

        public string USER_INFO { get; set; }

        [StringLength(256)]
        public string USER_AVATAR { get; set; }

        public bool ACCESS_LEVEL { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DATA_CREATE { get; set; }

        public int ID_AUTHORIZED { get; set; }

        public virtual AUTHORIZED AUTHORIZED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOK> BOOKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK> FEEDBACKs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAINT> PAINTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBSCRIPTION> SUBSCRIPTIONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_BOOKMARKS> USER_BOOKMARKS { get; set; }
    }
}
