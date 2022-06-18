using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPS_Web_22S1;
using SPS_Web_22S1.Models;
using System;

namespace SPS_Web22S1.Tests
{
    [TestClass]
    public class CRNSelectionItemUnitTest
    {
        private CRN_Detail _CRNDetails;
        private CRNSelectionItem _CRNSelectionItem;
        private CRN_Session_Timetable _cst1;
        private CRN_Session_Timetable _cst2;
        private CRN_Session_Timetable _cst3;
        private CRN_Session_Timetable _cst4;
        private CRN_Session_Timetable _cst5;

        [TestMethod]
        public void TestAddCRNSessionTable_ReturnListCountTrue()
        {
            //Arrange
            _CRNDetails = new CRN_Detail
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
            _CRNSelectionItem = new CRNSelectionItem(_CRNDetails);
            _cst1 = new CRN_Session_Timetable
            {
                CRN = "001111",
                TermCodeStart = 01,
                TermYearStart = 2022,
                DayCode = 3,
                StartTime = new TimeSpan(2, 00, 0),
                EndTime = new TimeSpan(4, 0, 0),
                Room = "B02",
                Building = "B",
                CampusCode = "ADL",
            };
            _cst2 = new CRN_Session_Timetable
            {
                CRN = "001111",
                TermCodeStart = 01,
                TermYearStart = 2022,
                DayCode = 3,
                StartTime = new TimeSpan(2, 00, 0),
                EndTime = new TimeSpan(4, 0, 0),
                Room = "B02",
                Building = "B",
                CampusCode = "ADL",
            };
            _cst3 = new CRN_Session_Timetable
            {
                CRN = "001111",
                TermCodeStart = 01,
                TermYearStart = 2022,
                DayCode = 3,
                StartTime = new TimeSpan(2, 00, 0),
                EndTime = new TimeSpan(4, 0, 0),
                Room = "B02",
                Building = "B",
                CampusCode = "ADL",
            };
            _cst4 = new CRN_Session_Timetable
            {
                CRN = "001111",
                TermCodeStart = 01,
                TermYearStart = 2022,
                DayCode = 3,
                StartTime = new TimeSpan(2, 00, 0),
                EndTime = new TimeSpan(4, 0, 0),
                Room = "B02",
                Building = "B",
                CampusCode = "ADL",
            };
            _cst5 = new CRN_Session_Timetable
            {
                CRN = "001111",
                TermCodeStart = 01,
                TermYearStart = 2022,
                DayCode = 3,
                StartTime = new TimeSpan(2, 00, 0),
                EndTime = new TimeSpan(4, 0, 0),
                Room = "B02",
                Building = "B",
                CampusCode = "ADL",
            };
            //Action
            _CRNSelectionItem.AddCRNSession(_cst1);
            _CRNSelectionItem.AddCRNSession(_cst2);
            _CRNSelectionItem.AddCRNSession(_cst3);
            _CRNSelectionItem.AddCRNSession(_cst4);
            _CRNSelectionItem.AddCRNSession(_cst5);

            //Result
            Assert.AreEqual(5, _CRNSelectionItem.CRNSessions.Count);
        }

        [TestMethod]
        public void TestRemoveCRNSessionTable_ReturnListCountTrue()
        {
            //Arrange
            _CRNDetails = new CRN_Detail
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
            _CRNSelectionItem = new CRNSelectionItem(_CRNDetails);
            _cst1 = new CRN_Session_Timetable
            {
                CRN = "001111",
                TermCodeStart = 01,
                TermYearStart = 2022,
                DayCode = 3,
                StartTime = new TimeSpan(2, 00, 0),
                EndTime = new TimeSpan(4, 0, 0),
                Room = "B02",
                Building = "B",
                CampusCode = "ADL",
            };
            _CRNSelectionItem.AddCRNSession(_cst1);
            _CRNSelectionItem.AddCRNSession(_cst2);
            //Action
            _CRNSelectionItem.RemoveCRNSession(_cst1);
            //Result
            Assert.AreEqual(1, _CRNSelectionItem.CRNSessions.Count);
        }

        [TestMethod]
        public void TestClearCRNSessionTable_ReturnListCountTrue()
        {
            //Arrange
            _CRNDetails = new CRN_Detail
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
            _CRNSelectionItem = new CRNSelectionItem(_CRNDetails);
            _cst1 = new CRN_Session_Timetable
            {
                CRN = "001111",
                TermCodeStart = 01,
                TermYearStart = 2022,
                DayCode = 3,
                StartTime = new TimeSpan(2, 00, 0),
                EndTime = new TimeSpan(4, 0, 0),
                Room = "B02",
                Building = "B",
                CampusCode = "ADL",
            };
            _CRNSelectionItem.AddCRNSession(_cst1);
            _CRNSelectionItem.AddCRNSession(_cst2);
            //Action
            _CRNSelectionItem.ClearCRNSession();
            //Result
            Assert.AreEqual(0, _CRNSelectionItem.CRNSessions.Count);
        }

    }
}
