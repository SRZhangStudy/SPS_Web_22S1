//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPS_Web_22S1
{
    using System;
    using System.Collections.Generic;
    
    public partial class competency_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public competency_type()
        {
            this.competency_qualification = new HashSet<competency_qualification>();
        }
    
        public string CompTypeCode { get; set; }
        public string CompTypeDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<competency_qualification> competency_qualification { get; set; }
    }
}
