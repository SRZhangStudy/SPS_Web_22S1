using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SPS_Web_22S1;
using SPS_Web_22S1.DAL;


namespace SPS_Web_22S1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly db_tafesaspsEntities db;
        private IHttpContextAccessor _ihttpContextAccessor;
        public StudentsController() {
            this.db = DBHelper.InitConnection();
        }
        public StudentsController(db_tafesaspsEntities db, IHttpContextAccessor ihttpContextAccessor)
        {
                this._ihttpContextAccessor = ihttpContextAccessor;
                this.db = db;

        }

        // Initial Page get list

        public ActionResult SearchStudent()
        {
            return View(db.Students.ToList());
        }

        //Search button refresh table
        [HttpPost]
        public ActionResult SearchStudent(string studentName, string studentID)
        {
            List<Student> students = new List<Student>();
            if (studentID != "")
            {
                students.Add(db.Students.Find(studentID));
            }
            else if (studentName != "")
            {
                var studentNames = TrimStudentName(studentName);
                if(studentNames.Count <= 1){
                    
                    students = db.Students.Where(st=> st.GivenName.Contains(studentNames.FirstOrDefault()) || st.LastName.Contains(studentNames.FirstOrDefault())).ToList();
                }
                else
                {
                    students = db.Students.Where(st=> studentNames.Contains(st.GivenName) || studentNames.Contains(st.LastName)).ToList();
                }
            }


            return View("Index",students.ToList());
        }

        public List<string> TrimStudentName(string studentName)
        {
            List<string> nameList = new List<string>();
            if(!studentName.Contains(" "))
            {
                nameList.Add(studentName);
            }
            else
            {
                char[] whitespace = new char[] { ' ', '\t' };
                string[] nameSplit = studentName.Split(separator: whitespace);
                    for (int i = 0; i < nameSplit.Length; i++)
                    {
                        if (nameSplit[i] != "" && nameSplit[i] != " " && nameSplit[i] != "\t")
                        {
                            nameList.Add(nameSplit[i].Trim());
                        }
                    }
            }
            return nameList;
        }


        // GET: students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

    }

      
}
