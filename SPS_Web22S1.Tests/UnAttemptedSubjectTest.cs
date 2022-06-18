using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPS_Web_22S1;
using SPS_Web_22S1.Models;
using System;

namespace SPS_Web22S1.Tests
{
    [TestClass]
    public class UnAttemptedSubjectTest
    {
        private Subject _Subject = new Subject {
            SubjectCode = "5WORK"
        };
        private CRN_Detail _CRNDetail = new CRN_Detail
        {
            CRN = "001111",
            TafeCompCode = "ADL",
            TermCodeStart = 1,
            TermYearStart = 2022,
            TermCodeEnd = 1,
            TermYearEnd = 2023,
            SubjectCode = "5DD",
            CampusCode = "ADL",
            LecturerID = "001",
            DepartmentCode = "003",
            FreezeDate = DateTime.Now,
            DateCreated = DateTime.Now
        };
        private Competency _Competency= new Competency{
            CompetencyName = "5WORK"
        };

        private CRN_Detail _CRNDetails = new CRN_Detail
            {
                CRN = "001111",
                TafeCompCode = "ADL",
                TermCodeStart = 1,
                TermYearStart = 2022,
                TermCodeEnd = 1,
                TermYearEnd = 2023,
                SubjectCode = "5DD",
                CampusCode = "ADL",
                LecturerID = "001",
                DepartmentCode = "003",
                FreezeDate = DateTime.Now,
                DateCreated = DateTime.Now
        };

    private UnAttemptedSubject _UnAttemptedSubject;

        [TestMethod]
        public void TestUnAttemptedSubject_AddCRNSelectionItem_ReturnTrue()
        {
            // Arrange
            _UnAttemptedSubject = new UnAttemptedSubject(_Subject, _Competency);
            CRNSelectionItem csi = new CRNSelectionItem(_CRNDetails);

            //Action
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);

            //Result
            Assert.AreEqual(4, _UnAttemptedSubject.CRNSelectionItemList.Count);
        }

        [TestMethod]
        public void TestUnAttemptedSubject_RemoveCRNSelectionItem_ReturnTrue()
        {
            // Arrange
            _UnAttemptedSubject = new UnAttemptedSubject(_Subject, _Competency);
            CRNSelectionItem csi = new CRNSelectionItem(_CRNDetails);

            //Action
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.RemoveCRNSelectionItem(csi);
            //Result
            Assert.AreEqual(3, _UnAttemptedSubject.CRNSelectionItemList.Count);
        }

        [TestMethod]
        public void TestUnAttemptedSubject_ClearCRNSelectionItem_ReturnTrue()
        {
            // Arrange
            _UnAttemptedSubject = new UnAttemptedSubject(_Subject, _Competency);
            CRNSelectionItem csi = new CRNSelectionItem(_CRNDetails);

            //Action
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.AddCRNSelectionItem(csi);
            _UnAttemptedSubject.ClearCRNSelectionItem();
            //Result
            Assert.AreEqual(0, _UnAttemptedSubject.CRNSelectionItemList.Count);
        }

    }
}
