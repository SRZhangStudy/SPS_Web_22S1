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
    
    public partial class student_grade
    {
        public string StudentID { get; set; }
        public string CRN { get; set; }
        public string TafeCompCode { get; set; }
        public int TermCode { get; set; }
        public int TermYear { get; set; }
        public string Grade { get; set; }
        public Nullable<System.DateTime> GradeDate { get; set; }
    
        public virtual crn_detail crn_detail { get; set; }
        public virtual student student { get; set; }
        public virtual term_datetime term_datetime { get; set; }
    }
}
