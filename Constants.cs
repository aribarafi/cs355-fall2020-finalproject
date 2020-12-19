using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static WindowsFormsApp1.DBConnection;

namespace WindowsFormsApp1
{
    class Constants
    {

        public static string loginClientUser;
        public static string clientID;

        public static string returnClientID()
        {
            conn = DBConnection.OpenConnection();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string findClientID = "SELECT idClient FROM Client WHERE Username = '" + Constants.loginClientUser + "'";
                SqlCommand searchcmd = new SqlCommand(findClientID, conn);
                searchcmd.CommandText = findClientID;
                SqlDataReader data_set = searchcmd.ExecuteReader();

                while (data_set.Read())
                {
                    clientID = data_set["idClient"].ToString();
                }
                conn.Close();

            }
            return clientID;
        }
    }
}
