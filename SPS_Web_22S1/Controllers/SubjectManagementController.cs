using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPS_Web_22S1.DAL;
using SPS_Web_22S1.Models;
namespace SPS_Web_22S1.Controllers
{
    public class SubjectManagementController : Controller
    {
        private db_tafesaspsEntities db = DBHelper.db_instance;
        // GET: SubjectManagement

        public ActionResult Index(string studentID, string QualCode)
        {
            StudentDetail sd = new StudentDetail();
            Student student = db.Students.Where(st => st.StudentID == studentID).FirstOrDefault<Student>();
            sd.Student = student;
            sd.StudyPlanList = student.Student_Studyplan.ToList();
            if(QualCode == null)
            {
                sd.StudyPlan = sd.StudyPlanList.FirstOrDefault();
                sd.Qualification = sd.StudyPlanList.FirstOrDefault().Qualification;
            }
            else
            {
                sd.StudyPlan = sd.StudyPlanList.Where(sp => sp.QualCode == QualCode).FirstOrDefault();
                sd.Qualification = db.Qualifications.Where(q => q.QualCode == QualCode).FirstOrDefault();
            }
            return View(sd);
        }

        

        public ActionResult ListSubjects(string QualCode, string StudentID)
        {
            // find all subjects in studyplan
            var qual = db.Qualifications.Where(q => q.QualCode == QualCode).FirstOrDefault();
            var studyplan = qual.Studyplan_Qualification.FirstOrDefault();
            var subjectList = studyplan.Studyplan_Subject.Select(sp => sp.Subject);

            // find the subjects that have grades - passed subjects and attempted subjects
            var student_grade_list = db.Student_Grade.Where(s => s.StudentID == StudentID).ToList();

            List<SubjectDetail> passedList = new List<SubjectDetail>();
            List<SubjectDetail> attemptedList = new List<SubjectDetail>();
            foreach (var grade in student_grade_list)
            {
                SubjectDetail sg = new SubjectDetail();
                sg.Grade = grade;
                sg.CRN_Detail = grade.CRN_Detail;
                sg.Competency = grade.CRN_Detail.Competency;
                sg.Subject = grade.CRN_Detail.Subject;
                if (grade.Grade=="PA")
                {
                    passedList.Add(sg);
                }
                else
                {
                    attemptedList.Add(sg);
                }
            }
            var unattemptedSubjectList = subjectList.Where(sb=> !(student_grade_list.Select(sg=>sg.CRN_Detail.Subject).Contains(sb)));
            List<UnAttemptedSubject> unattemptedList = new List<UnAttemptedSubject>();
            foreach (var item in unattemptedSubjectList)
            {
                UnAttemptedSubject uas = new UnAttemptedSubject();
                uas.Subject = item;
                unattemptedList.Add(uas);
            }
            var model = new Tuple <List<SubjectDetail>, List<SubjectDetail>>(passedList, attemptedList);
                return View(model);
        }

        public PartialViewResult SubjectSelectingListPartialView(List<CRN_Detail> passedCRNList)
        {
            return PartialView();
        }

      

    }
}