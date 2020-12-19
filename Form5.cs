using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.DBConnection;
using System.Data.SqlClient;
using static WindowsFormsApp1.Constants;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            conn = DBConnection.OpenConnection();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string SelectAll = "SELECT * FROM Passenger";

                SqlCommand cm = new SqlCommand(SelectAll, conn);

                cm.CommandText = SelectAll;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    comboBox1.Items.Add(drd["Name"].ToString());
                    comboBox3.Items.Add(drd["Phone_Number"].ToString());
                }
                drd.Close();
            }
            
            
            //con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search by name
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Search By ID
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Search By Drop OFf Location
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    listView1.View = View.Details;

                    listView1.Columns.Add("idOrderDetails");
                    listView1.Columns.Add("Transport_Provider_idTransport_Provider");
                    listView1.Columns.Add("Passenger_idPassenger");
                    listView1.Columns.Add("Passenger Name");
                    listView1.Columns.Add("WC or Ambulatory");
                    listView1.Columns.Add("Generated On");
                    listView1.Columns.Add("Total Payment");
                    listView1.Columns.Add("OneWay Or TwoWay");
                    listView1.Columns.Add("Order For Date");
                    listView1.Columns.Add("Pickup Time");
                    listView1.Columns.Add("Pickup Address");
                    listView1.Columns.Add("Drop off Address");
                    listView1.Columns.Add("Return Time");


                    //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                    //string addOrders = "SELECT * FROM OrderDetails where PassengerName = " + "'" + comboBox1.SelectedItem + "'";

                    string addOrders = "SELECT * FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger WHERE P.[Name] = '" + comboBox1.SelectedItem + "'";

                    //string addPassenger = "SELECT Name FROM Passenger WHERE PassengerName = "
                    SqlCommand cm = new SqlCommand(addOrders, conn);

                    cm.CommandText = addOrders;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = drd["idOrderDetails"].ToString();        // 1st column text
                        item.SubItems.Add(drd["Transport_Provider_idTransport_Provider"].ToString());
                        item.SubItems.Add(drd["Passenger_idPassenger"].ToString());
                        item.SubItems.Add(drd["Name"].ToString());
                        item.SubItems.Add(drd["WC_Ambulatory"].ToString());// 2nd column text
                        item.SubItems.Add(drd["OrderDate"].ToString());
                        item.SubItems.Add(drd["TotalPayment"].ToString());
                        item.SubItems.Add(drd["IsOne_Way"].ToString());
                        item.SubItems.Add(drd["Date_for_Order"].ToString());
                        item.SubItems.Add(drd["Pickup_Time"].ToString());
                        item.SubItems.Add(drd["Pickup_Address"].ToString());
                        item.SubItems.Add(drd["Drop_off_Address"].ToString());
                        item.SubItems.Add(drd["ReturnTime"].ToString());
                        item.SubItems.Add(drd["Name"].ToString());
                        listView1.Items.Add(item);
                    }
                    drd.Close();
                }
            }

            if (comboBox1.SelectedItem == null & comboBox3.SelectedItem != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    listView1.View = View.Details;

                    listView1.Columns.Add("idOrderDetails");
                    listView1.Columns.Add("Transport_Provider_idTransport_Provider");
                    listView1.Columns.Add("Passenger_idPassenger");
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
                    //string addOrders = "SELECT * FROM OrderDetails where PassengerNumber = " + "'" + comboBox3.SelectedItem + "'";
                    string addOrders = "SELECT * FROM OrderDetails OD Inner Join Passenger P ON OD.Passenger_idPassenger = P.idPassenger WHERE P.[Phone_Number] = '" + comboBox3.SelectedItem + "'";

                    SqlCommand cm = new SqlCommand(addOrders, conn);

                    cm.CommandText = addOrders;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = drd["idOrderDetails"].ToString();        // 1st column text
                        item.SubItems.Add(drd["Transport_Provider_idTransport_Provider"].ToString());
                        item.SubItems.Add(drd["Passenger_idPassenger"].ToString());
                        item.SubItems.Add(drd["Name"].ToString());
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
            if (comboBox1.SelectedItem == null & comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please select a value");
                return;
            }
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null & comboBox3.SelectedItem == null)
            {
                
                comboBox3.Items.Clear();
                if (conn.State == System.Data.ConnectionState.Open)
                 {
                     string SelectAll = "SELECT Phone_Number FROM Passenger where Name = " + "'" + comboBox1.SelectedItem + "'"; 

                     SqlCommand cm = new SqlCommand(SelectAll, conn);

                     cm.CommandText = SelectAll;

                     SqlDataReader drd = cm.ExecuteReader();
                     while (drd.Read())
                     {                       
                         comboBox3.Items.Add(drd["Phone_Number"].ToString());
                     }
                     drd.Close();
                 }

            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null & comboBox1.SelectedItem == null)
            {
                comboBox1.Items.Clear();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT Name FROM Passenger where Phone_Number = " + "'" + comboBox3.SelectedItem + "'"; 

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {                       
                        comboBox1.Items.Add(drd["Name"].ToString());
                    }
                    drd.Close();
                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }
    }
}
