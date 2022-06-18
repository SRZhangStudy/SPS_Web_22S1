using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPS_Web_22S1.Models
{
    public class CRNSelectionItem
    {
        public CRN_Detail CRN_Detail { get; private set; }
        public List<CRN_Session_Timetable> CRNSessions { get; private set; }

        public CRNSelectionItem() { }

        public CRNSelectionItem(CRN_Detail cd)
        {
            CRN_Detail = cd;
            CRNSessions = new List<CRN_Session_Timetable>();
        }

        public void AddCRNSession(CRN_Session_Timetable cst)
        {
            CRNSessions.Add(cst);
        }

        public void RemoveCRNSession(CRN_Session_Timetable cst)
        {
            CRNSessions.Remove(cst);
        }

        public void ClearCRNSession()
        {
            CRNSessions.Clear();
            CRNSessions = new List<CRN_Session_Timetable>();
        }
    }
}