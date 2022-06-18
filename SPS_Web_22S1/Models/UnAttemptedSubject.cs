using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPS_Web_22S1.Models
{
    public class UnAttemptedSubject
    {
        public Subject Subject { get; set; }
        public Competency Competency { get; set; }
        public List<CRNSelectionItem> CRNSelectionItemList { get; private set; }

        public UnAttemptedSubject() {
            Subject = new Subject();
            Competency = new Competency();
            CRNSelectionItemList = new List<CRNSelectionItem>(); 
        }

        public UnAttemptedSubject(Subject Subject, Competency Competency)
        {
            this.Subject = Subject;
            this.Competency = Competency;
            CRNSelectionItemList = new List<CRNSelectionItem>();
        }

        public void AddCRNSelectionItem(CRNSelectionItem csi)
        {
            CRNSelectionItemList.Add(csi);
        }

        public void RemoveCRNSelectionItem(CRNSelectionItem csi)
        {
            CRNSelectionItemList.Remove(csi);
        }

        public void ClearCRNSelectionItem()
        {
            CRNSelectionItemList.Clear();
            CRNSelectionItemList = new List<CRNSelectionItem>();
        }
    }
}