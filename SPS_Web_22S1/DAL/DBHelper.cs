using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace SPS_Web_22S1.DAL
{
    public static class DBHelper
    {
        private static db_tafesaspsEntities db;

        //初始化数据库连接,InitConnection方法名自定义

        public static db_tafesaspsEntities InitConnection()
        {
            if (HttpContext.Current.Items["db"] == null)
            {
                db = new db_tafesaspsEntities();
                HttpContext.Current.Items["db"] = db;
            }
            else
            {
                db = HttpContext.Current.Items["db"] as db_tafesaspsEntities;
            }
            return db;
        }


        public static Student GetStudentByID(string StudentID)
        {
            return db.Students.Where(st => st.StudentID == StudentID).FirstOrDefault();
        }


    }
}