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
    
    public partial class Subject_Qualification
    {
        public string QualCode { get; set; }
        public string SubjectCode { get; set; }
        public string UsageType { get; set; }
    
        public virtual Qualification Qualification { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
