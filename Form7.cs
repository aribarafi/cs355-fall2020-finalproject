using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static WindowsFormsApp1.DBConnection;
using System.Data.SqlClient;
using static WindowsFormsApp1.Constants;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            conn = DBConnection.OpenConnection();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string SelectAll = "SELECT distinct TP.[Name] AS TransportProviderName FROM OrderDetails OD INNER JOIN Transport_Provider TP  ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider";


                SqlCommand cm = new SqlCommand(SelectAll, conn);

                cm.CommandText = SelectAll;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();

                
                    string SelectOrderDate = "SELECT distinct Date_For_Order FROM OrderDetails";


                    SqlCommand m = new SqlCommand(SelectOrderDate, conn);

                    m.CommandText = SelectOrderDate;

                    SqlDataReader dd = m.ExecuteReader();
                    while (dd.Read())
                    {
                        //comboBox1.Items.Add(drd["PassengerName"].ToString());
                        //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                        comboBox3.Items.Add(dd["Date_For_Order"].ToString());
                        //comboBox4.Items.Add(drd["OrderDate"].ToString());
                        //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                    }
                    dd.Close();

                    string selectName = "SELECT distinct P.[Name] AS PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger";


                    SqlCommand cmm = new SqlCommand(selectName, conn);

                    cmm.CommandText = selectName;

                    SqlDataReader dr = cmm.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["PassengerName"].ToString());
                        //comboBox2.Items.Add(drd["TransportProviderName"].ToString());

                    }
                    dr.Close();

                    string Generatedon = "SELECT distinct OrderDate FROM OrderDetails";


                    SqlCommand mm = new SqlCommand(Generatedon, conn);

                    mm.CommandText = Generatedon;

                    SqlDataReader d = mm.ExecuteReader();
                    while (d.Read())
                    {
                        //comboBox1.Items.Add(drd["PassengerName"].ToString());
                        //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                        //comboBox3.Items.Add(d["Date_For_Order"].ToString());
                        comboBox4.Items.Add(d["OrderDate"].ToString());
                        //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                    }
                    d.Close();


                    string wcamb = "SELECT distinct WC_Ambulatory FROM OrderDetails";


                    SqlCommand ar = new SqlCommand(wcamb, conn);

                    ar.CommandText = wcamb;

                    SqlDataReader no = ar.ExecuteReader();
                    while (no.Read())
                    {
                        //comboBox1.Items.Add(drd["PassengerName"].ToString());
                        //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                        //comboBox3.Items.Add(d["Date_For_Order"].ToString());
                        //comboBox4.Items.Add(no["OrderDate"].ToString());
                        comboBox5.Items.Add(no["WC_Ambulatory"].ToString());

                    }
                    no.Close();


                }
            }

            private void Form7_Load(object sender, EventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {
                string query = "SELECT OD.idOrderDetails, OD.Transport_Provider_idTransport_Provider, OD.Passenger_idPassenger, OD.WC_Ambulatory,OD.OrderDate,OD.TotalPayment,OD.isOne_Way,OD.Date_for_Order,OD.Pickup_Time, OD.Pickup_Address, OD.Drop_off_Address, OD.ReturnTime, P.idPassenger, P.Client_idClient, P.[Name] as PassengerName, P.Phone_Number, TP.idTransport_Provider, TP.[Name] as TransportProviderName, TP.One_Way_Payment, TP.Return_Payment FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";
                

                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {                   
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

               if (comboBox2.Text!= "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");                 
                }

               if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {
                   
                    query = query +  String.Join(" AND ", conditions.ToArray());
                    
 
                
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                listView1.View = View.Details;

                listView1.Columns.Add("idOrderDetails");
                listView1.Columns.Add("idTransport_Provider");
                listView1.Columns.Add("Transport Provider Name");
                listView1.Columns.Add("idPassenger");
                listView1.Columns.Add("Passenger Name");
                listView1.Columns.Add("WC or Ambulatory");
                listView1.Columns.Add("Generated On");
                listView1.Columns.Add("Total Payment");
                listView1.Columns.Add("OneWay Or TwoWay");
                listView1.Columns.Add("Order for Date");
                listView1.Columns.Add("Pickup Time");
                listView1.Columns.Add("Pickup Address");
                listView1.Columns.Add("Drop off Address");
                listView1.Columns.Add("Return Time");


                //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                

                SqlCommand cm = new SqlCommand(query, conn);
                
                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    var item = new ListViewItem();
                    item.Text = drd["idOrderDetails"].ToString();        // 1st column text
                    item.SubItems.Add(drd["Transport_Provider_idTransport_Provider"].ToString());
                    item.SubItems.Add(drd["TransportProviderName"].ToString());
                    item.SubItems.Add(drd["Passenger_idPassenger"].ToString());
                    item.SubItems.Add(drd["PassengerName"].ToString());
                    item.SubItems.Add(drd["WC_Ambulatory"].ToString());// 2nd column text
                    item.SubItems.Add(drd["OrderDate"].ToString());
                    item.SubItems.Add(drd["TotalPayment"].ToString());
                    item.SubItems.Add(drd["IsOne_Way"].ToString());
                    item.SubItems.Add(drd["Date_for_Order"].ToString());
                    item.SubItems.Add(drd["Pickup_Time"].ToString());
                    item.SubItems.Add(drd["Pickup_Address"].ToString());
                    item.SubItems.Add(drd["Drop_off_Address"].ToString());
                    item.SubItems.Add(drd["ReturnTime"].ToString());
                    //item.SubItems.Add(drd["PassengerName"].ToString());
                    listView1.Items.Add(item);
                }
                drd.Close();
            }
        }

         private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
         {
            if (comboBox1.Text =="")
{
                comboBox1.Items.Clear();
                string query = "select distinct  P.[Name] AS PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";


                List<string> conditions = new List<string>();
                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());


                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  P.[Name] AS PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }
            if (comboBox2.Text == "")
{
                comboBox2.Items.Clear();
                string query = "select distinct  TP.[Name] AS TransportProviderName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";



                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                /*if (comboBox2.Text != "")
                {
                    conditions.Add("TransportProviderName = '" + comboBox2.Text + "' ");
                }*/

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

          
                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct TP.[Name] AS TransportProviderName FROM OrderDetails OD INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();

            }

            if (comboBox4.Text == "")
{
                comboBox4.Items.Clear();
                string query = "select distinct OD.OrderDate FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";



                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                /*if (comboBox4.Text != "")
                {
                    conditions.Add("OrderDate = '" + comboBox4.Text + "' ");
                }*/

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                 

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.OrderDate FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

            if (comboBox5.Text == "")
{
                comboBox5.Items.Clear();
                string query = "select distinct  OD.WC_Ambulatory FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                /*if (comboBox5.Text != "")
                {
                    conditions.Add("WC_Ambulatory = '" + comboBox5.Text + "' ");
                }*/

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

            
                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.WC_Ambulatory FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
{
                comboBox2.Items.Clear();
                string query = "select distinct TP.[Name] AS TransportProviderName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                /*if (comboBox2.Text != "")
                {
                    conditions.Add("TransportProviderName = '" + comboBox2.Text + "' ");
                }*/

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct TP.[Name] AS TransportProviderName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();

            }
            if (comboBox3.Text == "")
{
                comboBox3.Items.Clear();
                string query = "select distinct OD.Date_for_Order FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE "; 


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct OD.Date_for_Order FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";
  

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }
            if (comboBox4.Text == "")
{
                comboBox4.Items.Clear();
                string query = "select distinct  OD.OrderDate FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                /*if (comboBox4.Text != "")
                {
                    conditions.Add("OrderDate = '" + comboBox4.Text + "' ");
                }*/

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.OrderDate FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

            if (comboBox5.Text == "")
{
                comboBox5.Items.Clear();
                string query = "select distinct  OD.WC_Ambulatory FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                /*if (comboBox5.Text != "")
                {
                    conditions.Add("WC_Ambulatory = '" + comboBox5.Text + "' ");
                }*/

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.WC_Ambulatory FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }
     }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
{
                comboBox1.Items.Clear();
                string query = "select distinct P.[Name] AS PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";


                List<string> conditions = new List<string>();
                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct P.[Name] AS PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

            if (comboBox3.Text == "")
{
                comboBox3.Items.Clear();
                string query = "select distinct  OD.Date_for_Order FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.Date_for_Order FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

            if (comboBox4.Text == "")
{
                comboBox4.Items.Clear();
                string query = "select distinct  OD.OrderDate FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                /*if (comboBox4.Text != "")
                {
                    conditions.Add("OrderDate = '" + comboBox4.Text + "' ");
                }*/

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.OrderDate FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

            if (comboBox5.Text =="")
{
                comboBox5.Items.Clear();
                string query = "select distinct  OD.WC_Ambulatory FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                /*if (comboBox5.Text != "")
                {
                    conditions.Add("WC_Ambulatory = '" + comboBox5.Text + "' ");
                }*/

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.WC_AmbulatoryFROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider WHERE ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
{
                comboBox1.Items.Clear();
                string query = "select distinct P.[Name] AS  PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct P.[Name] AS PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

            if (comboBox2.Text == "")
{
                comboBox2.Items.Clear();
                string query = "select distinct  TP.[Name] AS TransportProviderName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                /*if (comboBox2.Text != "")
                {
                    conditions.Add("TransportProviderName = '" + comboBox2.Text + "' ");
                }*/

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct TP.[Name] AS TransportProviderName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();

            }

            if (comboBox3.Text == "")
{
                comboBox3.Items.Clear();
                string query = "select distinct  OD.Date_for_Order FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.Date_for_Order FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

            if (comboBox5.Text == "")
{
                comboBox5.Items.Clear();
                string query = "select distinct  OD.WC_Ambulatory FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                /*if (comboBox5.Text != "")
                {
                    conditions.Add("WC_Ambulatory = '" + comboBox5.Text + "' ");
                }*/

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.WC_Ambulatory FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text =="")
{
                comboBox1.Items.Clear();
                string query = "select distinct P.[Name] AS PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct P.[Name] AS PassengerName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }

            if (comboBox2.Text == "")
{
                comboBox2.Items.Clear();
                string query = "select distinct TP.[Name] AS  TransportProviderName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                /*if (comboBox2.Text != "")
                {
                    conditions.Add("TransportProviderName = '" + comboBox2.Text + "' ");
                }*/

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct TP.[Name] AS TransportProviderName FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();

            }

            if (comboBox3.Text == "")
{
                comboBox3.Items.Clear();
                string query = "select distinct OD.Date_for_Order FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                if (comboBox4.Text != "")
                {
                    conditions.Add("OD.OrderDate = '" + comboBox4.Text + "' ");
                }

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());

                    

                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OD.Date_for_Order FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider ";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    //comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }




            if (comboBox4.Text == "")
{
                comboBox4.Items.Clear();
                string query = "select distinct OD.OrderDate FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger INNER JOIN Transport_Provider TP ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider  Where ";


                List<string> conditions = new List<string>();
                if (comboBox1.Text != "")
                {
                    conditions.Add("P.[Name] = '" + comboBox1.Text + "' ");
                }

                if (comboBox3.Text != "")
                {
                    conditions.Add("OD.Date_for_Order = '" + comboBox3.Text + "' ");
                }

                if (comboBox2.Text != "")
                {
                    conditions.Add("TP.[Name] = '" + comboBox2.Text + "' ");
                }

                /*if (comboBox4.Text != "")
                {
                    conditions.Add("OrderDate = '" + comboBox4.Text + "' ");
                }*/

                if (comboBox5.Text != "")
                {
                    conditions.Add("OD.WC_Ambulatory = '" + comboBox5.Text + "' ");
                }

                if (conditions.Count > 0)
                {

                    query = query + String.Join(" AND ", conditions.ToArray());


                }

                else if (conditions.Count == 0)
                {

                    query = "select distinct  OrderDate FROM OrderDetails";

                }


                SqlCommand cm = new SqlCommand(query, conn);

                cm.CommandText = query;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    //comboBox1.Items.Add(drd["PassengerName"].ToString());
                    //comboBox2.Items.Add(drd["TransportProviderName"].ToString());
                    //comboBox3.Items.Add(drd["Date_For_Order"].ToString());
                    comboBox4.Items.Add(drd["OrderDate"].ToString());
                    //comboBox5.Items.Add(drd["WC_Ambulatory"].ToString());

                }
                drd.Close();
            }




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form7().Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }
    }
    }


