using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SPS_Web_22S1.DAL;

using System.Text;

namespace SPS_Web_22S1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //String sql = "select * from Student";
            //DataTable dt = DBHelper.GetDataTable(sql);
            //List<DataRow> list = dt.AsEnumerable().ToList();
            //List<Student> students = new List<Student>();
            //DataColumnCollection dtColumns = dt.Columns;
            //foreach(DataRow dr in list)
            //{
            //    Student stu = new Student();
            //    PropertyInfo[] properties = stu.GetType().GetProperties();
            //    foreach(PropertyInfo pi in properties)
            //    {
            //        String name = pi.Name;
            //        if (dtColumns.Contains(name))
            //        {
            //            if (!pi.CanWrite)
            //            {
            //                continue;
            //            }
            //            Object value = dr[name];
            //            if(value != DBNull.Value)
            //            {
            //                pi.SetValue(stu, value, null);
            //            }
            //        }
            //    }
            //    students.Add(stu);
            //}
            //ViewData["StudentsList"] = students;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}