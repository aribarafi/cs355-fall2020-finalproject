using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class DBConnection
    {
        
        public static string CONN_STRING = "Data Source=DESKTOP-7RE7P7N\\SQLEXPRESS;Initial Catalog=iwantdeathFORTHISDEMO;Integrated Security=True";
        public static SqlConnection conn;

        public static SqlConnection OpenConnection()
        {
            if (conn != null)
            {
                if(conn.State != System.Data.ConnectionState.Open)
                {
                    conn = new SqlConnection(CONN_STRING);
                    conn.Open();
                }
            }
            else
            {
                conn = new SqlConnection(CONN_STRING);
                conn.Open();
            }
            return conn;
        }
        public static void CloseConnection()
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
