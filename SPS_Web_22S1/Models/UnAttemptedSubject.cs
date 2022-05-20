using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPS_Web_22S1.Models
{
    public class UnAttemptedSubject
    {
        public Subject Subject;
        public Competency Competency;
        public List<CRNSelectionItem> CRNSelectionItemList;
    }
}