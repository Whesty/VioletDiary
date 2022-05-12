namespace VDService.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ARTIST")]
    public partial class ARTIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTIST()
        {
            PAINTs = new HashSet<PAINT>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string ARTIST_NAME { get; set; }

        public string LINK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAINT> PAINTs { get; set; }
    }
}
