using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPS_Web_22S1;
namespace SPS_Web_22S1.Models
{
    public class SubjectDetail
    {
        public Subject Subject { get; set; }
        public CRN_Detail CRN_Detail { get; set; }
        public Student_Grade Grade{ get; set; }
        public Competency Competency { get; set; }


}
}