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
        private static db_tafesaspsEntities db = new db_tafesaspsEntities();
        public static db_tafesaspsEntities db_instance { get { return db; } }      
        
    }
}