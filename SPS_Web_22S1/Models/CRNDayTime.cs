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
    }
}