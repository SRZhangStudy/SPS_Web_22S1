using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPS_Web_22S1.Models
{
    public class CRNSelectionItem
    {
        public CRN_Detail CRN_Detail;
        public List<CRN_Session_Timetable> CRN_Session_Timetable;
        public Day_Of_Week Day_Of_Week;
        public Lecturer Lecturer;
        public Campu Campu;
        public Department Department;
    }
}