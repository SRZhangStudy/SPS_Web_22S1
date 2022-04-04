using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace SPS_Web_22S1.DAL
{
    public class DBHelper
    {
        //创建数据库连接字符串
        private static string ConnString = "Data Source=localhost;Initial Catalog=db_tafesasps;Persist Security Info=True;User ID=sa;Password=sqlserver";    //.是服务器名称 ,stuDB是数据库名称,sa是数据库登录名,123456是数据库密码
        //创建数据库连接对象
        private static SqlConnection Conn = null;
        //初始化数据库连接,InitConnection方法名自定义
        private static void InitConnection()
        {
            if (Conn == null)    //如果数据库对象为空,则new一个数据库连接对象.
            {
                Conn = new SqlConnection(ConnString);    //new一个连接对象,连接字符串给它,用于连接    
            }
            if (Conn.State == ConnectionState.Closed)    //如果连接对象的状态是关闭的,就打开连接
            {
                Conn.Open();    //打开连接对象
            }
            if (Conn.State == ConnectionState.Broken)    //如果连接对象的状态是断开的,就关闭重新打开连接
            {
                Conn.Close();    //关闭连接对象
                Conn.Open();    //打开连接对象
            }
        }

        public static DataTable GetDataTable(string sqlStr)
        {
            InitConnection();    //连接数据库
            DataTable table = new DataTable();    //new一个数据表
            SqlDataAdapter dap = new SqlDataAdapter(sqlStr, Conn);    //创建数据适配器,sql语句和连接对象传给它,
            dap.Fill(table);    //将数据表填充进适配器
            Conn.Close();    //关闭数据连接
            return table;    //将数据表返回
        }

    

    }
}