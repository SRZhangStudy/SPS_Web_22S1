using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SPS_Web_22S1;
using SPS_Web_22S1.DAL;


namespace SPS_Web_22S1.Controllers
{
    public class StudentsController : Controller
    {
        private db_tafesaspsEntities db = DBHelper.db_instance;

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
            if (studentName == "")
            {
                students.Add(db.Students.Find(studentID));
            }
            else if (studentID == "")
            {
                studentName = "%" + studentName + "%";
                students = db.Students.SqlQuery("select * from student WHERE GivenName LIKE @name OR LastName LIKE @name", new SqlParameter("@name", studentName)).ToList<Student>();
            }

            return View(students.ToList());


        }

        // GET: students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

    }

      
}
