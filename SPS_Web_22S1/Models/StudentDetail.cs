using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPS_Web_22S1.Models
{
    public class StudentDetail
    {
        public Student Student { get; set; }
        public List<Student_Studyplan> StudyPlanList { get; set; }
        public Student_Studyplan StudyPlan { get; set; }
        public Qualification Qualification { set; get; }
        public Competency Competency { get; set; }
    }
}