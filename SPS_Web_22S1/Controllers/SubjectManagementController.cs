using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPS_Web_22S1.Controllers
{
    public class SubjectManagementController : Controller
    {
        private db_tafesaspsEntities1 db = new db_tafesaspsEntities1();
        // GET: SubjectManagement
        public ActionResult Index(string studentID)
        {
            student student = db.students.Where(st => st.StudentID == studentID).FirstOrDefault<student>();
            ViewBag.Student = student;
            var spList = db.student_studyplan.Where(s => s.StudentID == studentID).ToList();
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

        private qualification findQualifcation(string studyPlanQualCode) {
        
            var qf = db.qualifications.Where(q => q.QualCode == studyPlanQualCode);
            return qf.FirstOrDefault();
        }

        private student_studyplan findStudentStudyPlan(string studentID, string qualCode)
        {
            var studyplan = db.student_studyplan.Where(s => s.StudentID == studentID  && s.QualCode == qualCode);
            return studyplan.FirstOrDefault();
        }

        public ActionResult ListSubjects(string QualCode, string StudentID)
        {
            var sub_qual = db.subject_qualification.Where(sq=>sq.QualCode == QualCode).ToList();

            List<subject_qualification> sub_list = sub_qual.ToList<subject_qualification>();
            List<string> sub_code_list = new List<string>();
            foreach (subject_qualification sq in sub_list)
            {
                sub_code_list.Add(sq.SubjectCode);
            }

            var subject_records = from cd in db.crn_detail join s in db.subjects on cd.SubjectCode equals s.SubjectCode 
                                  where sub_code_list.Contains(s.SubjectCode) 
                                  select new {s, cd };

            var attempted_subject_records = from s in db.subjects
                                   join cd in db.crn_detail on s.SubjectCode equals cd.SubjectCode
                                   where sub_code_list.Contains(s.SubjectCode)
                                   join g in db.student_grade on cd.CRN equals g.CRN
                                   select new { s, cd, g };
            List<string> competedSubjectCodes = attempted_subject_records.Select(s => s.s.SubjectCode).ToList();

            var un_attempted_subject_records1 = from s in db.subjects
                                   join cd in db.crn_detail on s.SubjectCode equals cd.SubjectCode
                                   where sub_code_list.Contains(s.SubjectCode) && !competedSubjectCodes.Contains(s.SubjectCode)
                                   join g in db.student_grade on cd.CRN equals g.CRN into cd_s_g
                                   from g in cd_s_g.DefaultIfEmpty()
                                   select new { s, cd, g };

            var unattempted_subject_records = from s in db.subjects
                                              join cd in db.crn_detail on s.SubjectCode equals cd.SubjectCode
                                              where sub_code_list.Contains(s.SubjectCode) 
                                              join g in db.student_grade on cd.CRN equals g.CRN into cd_s_g
                                              from g in cd_s_g.DefaultIfEmpty()
                                              select new { s, cd, g };

            List<dynamic> li = new List<dynamic>();
            foreach (var item in attempted_subject_records.ToList())
            {
                dynamic d = new ExpandoObject();
                    d.Subject = item.s;
                    d.CRNDetails = item.cd;
                    d.Campus = item.cd.campu;
                    d.TermDateTime = item.cd.term_datetime;

                if (item.cd.lecturer != null)
                {
                    d.Lecture = item.cd.lecturer;
                }
                else
                {
                    d.Lecture = "";
                }
                var studentGrade = item.cd.student_grade;
                    if (studentGrade.Count != 0)
                    {
                        d.StudentGrade = studentGrade.FirstOrDefault().Grade;
                        d.StudentGradeDate = studentGrade.FirstOrDefault().GradeDate;
                    }
                    else
                    {
                        d.StudentGrade = "";
                        d.StudentGradeDate = "";
                    }
                    li.Add(d);       
            }
            foreach (var item in un_attempted_subject_records1.ToList())
            {
                dynamic d = new ExpandoObject();
                d.Subject = item.s;
                d.CRNDetails = item.cd;
                d.Campus = item.cd.campu;
                d.TermDateTime = item.cd.term_datetime;
                if(item.cd.lecturer != null)
                {
                    d.Lecture = item.cd.lecturer;
                }
                else
                {
                    d.Lecture = "";
                }
                var studentGrade = item.cd.student_grade;
                if (studentGrade.Count != 0)
                {
                    d.StudentGrade = studentGrade.FirstOrDefault().Grade;
                    d.StudentGradeDate = studentGrade.FirstOrDefault().GradeDate;
                }
                else
                {
                    d.StudentGrade = "";
                    d.StudentGradeDate = "";
                }
                li.Add(d);
            }

            return View(li);
        }

    }
}