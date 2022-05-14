using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPS_Web_22S1.DAL;

namespace SPS_Web_22S1.Controllers
{
    public class SubjectManagementController : Controller
    {
        private db_tafesaspsEntities db = DBHelper.InitConnection();
        // GET: SubjectManagement
        public ActionResult Index(string studentID)
        {
            Student student = db.Students.Where(st => st.StudentID == studentID).FirstOrDefault<Student>();
            ViewBag.Student = student;
            var spList = db.Student_Studyplan.Where(s => s.StudentID == studentID).ToList();
            //var plan = db.student_studyplan.
            //ViewBag.StudyPlan = 
            //qualification qual = 
            ViewBag.Qualification = findQualifcation(spList[0].QualCode);
            ViewBag.StudentStudyPlan = findStudentStudyPlan(student.StudentID,spList[0].QualCode);
            ViewBag.StudyPlanList = spList.Select(sp=> new SelectListItem { 
                Text = sp.QualCode ,
                Value = sp.QualCode,
            });
            return View();
        }

        public ActionResult DetailsByQualCode(string QualCode, string StudentID)
        {
            ViewBag.Qualification = findQualifcation(QualCode);
            ViewBag.StudentStudyPlan = findStudentStudyPlan(QualCode, StudentID);
            return View("Index");
        }

        private Qualification findQualifcation(string studyPlanQualCode) {
        
            var qf = db.Qualifications.Where(q => q.QualCode == studyPlanQualCode);
            return qf.FirstOrDefault();
        }

        private Student_Studyplan findStudentStudyPlan(string studentID, string qualCode)
        {
            var studyplan = db.Student_Studyplan.Where(s => s.StudentID == studentID  && s.QualCode == qualCode);
            return studyplan.FirstOrDefault();
        }

        public ActionResult ListSubjects(string QualCode, string StudentID)
        {
            // find all subjects in studyplan
            var qual = db.Qualifications.Where(q=>q.QualCode == QualCode).FirstOrDefault();
            var studyplan = db.Studyplan_Qualification.FirstOrDefault();
            var subjectList = studyplan.Studyplan_Subject.ToList();
            var subjects_list_in_studyplan = subjectList.Select(sp=>sp.Subject).ToList();

            // find the subjects that have grades - passed subjects and attempted subjects
            var student_grade_list = db.Student_Grade.Where(s => s.StudentID == "000896534").ToList();
            var passed_CRN_list = student_grade_list.Where(sg=>sg.Grade=="PA").Select(sg => sg.CRN_Detail).ToList();
            var attempted_CRN_list = student_grade_list.Where(sg => sg.Grade != "PA").Select(sg => sg.CRN_Detail).ToList();

            var attempted_subject_code_list = attempted_CRN_list.Select(crn=>crn.SubjectCode).ToList();
            var passed_subject_code_list = passed_CRN_list.Select(crn=>crn.SubjectCode).ToList();

            var attempted_subject_list = db.Subjects.Where(sb => attempted_subject_code_list.Contains(sb.SubjectCode));
            var passed_subject_list = db.Subjects.Where(sb => passed_subject_code_list.Contains(sb.SubjectCode));


            // return the lists to View
            List<dynamic> li = new List<dynamic>();
            List<dynamic> passedList = new List<dynamic>();
            List<dynamic> attemptedList = new List<dynamic>();
            List<dynamic> unattemptedList = new List<dynamic>();
            foreach (var item in passed_subject_list)
            {
                dynamic d = new ExpandoObject();
                d.Subject = item;
                d.Grade = passed_CRN_list.Where(cr => cr.SubjectCode == item.SubjectCode).Select(cr=>cr.Student_Grade);
                d.CRN = passed_CRN_list.Where(cr => cr.SubjectCode == item.SubjectCode).FirstOrDefault();
                d.Competency = item.Competencies;

                passedList.Add(d);
            }
            foreach (var item in attempted_subject_list)
            {
                dynamic d = new ExpandoObject();
                d.Subject = item;
                d.Grade = attempted_CRN_list.Where(cr => cr.SubjectCode == item.SubjectCode).Select(cr => cr.Student_Grade);
                d.CRN = passed_CRN_list.Where(cr => cr.SubjectCode == item.SubjectCode).FirstOrDefault();
                d.Competency = item.Competencies;
                attemptedList.Add(d);
            }
            foreach (var item in attempted_subject_list)
            {
                if ( !passed_subject_code_list.Contains(item.SubjectCode))
                {
                    dynamic d = new ExpandoObject();
                    d.Subject = item;
                    d.CRNList = item.CRN_Detail.ToList();
                    unattemptedList.Add(d);
                }
            }

            ViewBag.PassedList = passedList;
            ViewBag.AttemptedList = attemptedList;
            ViewBag.UnattemptedList = unattemptedList;

            return View();
        }

    }
}