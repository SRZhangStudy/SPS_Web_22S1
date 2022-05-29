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
        private db_tafesaspsEntities db = DBHelper.InitConnection();

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
                studentName = studentName.Trim();
                if(studentName.Contains(" ")){
                    char[] whitespace = new char[] { ' ','\t'};
                    string[] nameSplit = studentName.Split(separator: whitespace);
                    List<string> nameWithoutWhiteSpace = new List<string>();
                    for(int i = 0; i < nameSplit.Length; i++)
                    {
                        if(nameSplit[i] != "" && nameSplit[i] != " " && nameSplit[i] != "\t")
                        {
                            nameWithoutWhiteSpace.Add(nameSplit[i]);
                        }
                    }
                    string firstName = nameWithoutWhiteSpace[0];
                    string lastName = nameWithoutWhiteSpace[1];
                    students = db.Students.Where(st=> st.GivenName.Contains(firstName) || st.LastName.Contains(lastName) || st.GivenName.Contains(lastName) || st.LastName.Contains(firstName)).ToList();
                }
                else
                {
                    students = db.Students.Where(st=> st.GivenName.Contains(studentName) || st.LastName.Contains(studentName) ).ToList();
                }
            }

            return View("Index",students.ToList());


        }

        // GET: students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

    }

      
}
