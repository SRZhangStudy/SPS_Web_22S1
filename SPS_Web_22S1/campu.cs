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
    
    public partial class Campu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campu()
        {
            this.CRN_Detail = new HashSet<CRN_Detail>();
            this.CRN_Session_Timetable = new HashSet<CRN_Session_Timetable>();
        }
    
        public string CampusCode { get; set; }
        public string CampusName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRN_Detail> CRN_Detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRN_Session_Timetable> CRN_Session_Timetable { get; set; }
    }
}
