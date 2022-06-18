using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPS_Web_22S1.Models
{
    public class CRNDayTime
    {
        public List<CRN_Session_Timetable> CRN_Session_Timetable{set;get;}
        public Day_Of_Week day_Of_Week { set; get; }


        public void AddCRNSessionTimeTable(CRN_Session_Timetable cst)
        {
            CRN_Session_Timetable.Add(cst);
        }
        public void RemoveCRNSessionTimeTable(CRN_Session_Timetable cst)
        {
            CRN_Session_Timetable.Remove(cst);
        }


    }
}