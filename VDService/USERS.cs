//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VDService
{
    using System;
    using System.Collections.Generic;
    
    public partial class USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS()
        {
            this.BOOKS = new HashSet<BOOKS>();
            this.FEEDBACK = new HashSet<FEEDBACK>();
            this.PAINT = new HashSet<PAINT>();
            this.SUBSCRIPTION = new HashSet<SUBSCRIPTION>();
            this.USER_BOOKMARKS = new HashSet<USER_BOOKMARKS>();
        }
    
        public int ID_USER { get; set; }
        public string USER_NAME { get; set; }
        public string USER_INFO { get; set; }
        public string USER_AVATAR { get; set; }
        public bool ACCESS_LEVEL { get; set; }
        public System.DateTime DATA_CREATE { get; set; }
        public int ID_AUTHORIZED { get; set; }
    
        public virtual AUTHORIZED AUTHORIZED { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOKS> BOOKS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK> FEEDBACK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAINT> PAINT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBSCRIPTION> SUBSCRIPTION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_BOOKMARKS> USER_BOOKMARKS { get; set; }
    }
}
