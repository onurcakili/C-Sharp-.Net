//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PoliceDepartment
{
    using System;
    using System.Collections.Generic;
    
    public partial class Makam_Araclari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Makam_Araclari()
        {
            this.Amirlers = new HashSet<Amirler>();
        }
    
        public int makamAraciID { get; set; }
        public string makamAraciPlaka { get; set; }
        public Nullable<int> makamArabaKoruma { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Amirler> Amirlers { get; set; }
        public virtual Makam_Korumalari Makam_Korumalari { get; set; }
    }
}
