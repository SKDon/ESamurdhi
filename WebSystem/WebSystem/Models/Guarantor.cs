//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guarantor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guarantor()
        {
            this.LoneLedgers = new HashSet<LoneLedger>();
        }
    
        public int GuarantorsID { get; set; }
        public string GFullName { get; set; }
        public string GAddress { get; set; }
        public string GNIC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoneLedger> LoneLedgers { get; set; }
    }
}
