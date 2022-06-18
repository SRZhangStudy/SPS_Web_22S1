using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace SPS_Web_22S1.DAL
{
    public static class DBHelper
    {
        private static db_tafesaspsEntities db;

        //初始化数据库连接,InitConnection方法名自定义


        public static db_tafesaspsEntities InitConnection()
        {
            if (System.Web.HttpContext.Current.Items["db"] == null)
            {
                db = new db_tafesaspsEntities();
                System.Web.HttpContext.Current.Items["db"] = db;
            }
            else
            {
                db = System.Web.HttpContext.Current.Items["db"] as db_tafesaspsEntities;
            }
            return db;
        }

      

        public static Student GetStudentByID(string StudentID)
        {
            return db.Students.Where(st => st.StudentID == StudentID).FirstOrDefault();
        }


    }
}