using LinqToExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static WindowsFormsApp1.DBConnection;
using static WindowsFormsApp1.Constants;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
            dateTimePicker2.CustomFormat = "  HH' : 'mm ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            dateTimePicker1.CustomFormat = "MM/dd/yyyy";

            dateTimePicker3.CustomFormat = "  HH' : 'mm ";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;

            conn = DBConnection.OpenConnection();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string SelectAll = "SELECT distinct Name FROM Passenger";
                SqlCommand cm = new SqlCommand(SelectAll, conn);
                cm.CommandText = SelectAll;
                SqlDataReader drd = cm.ExecuteReader();

                while (drd.Read())
                {
                    comboBox1.Items.Add(drd["Name"].ToString());

                }
                conn.Close();

                conn = DBConnection.OpenConnection();
                if (conn.State == System.Data.ConnectionState.Open)
                {

                    string SelectTransport = "SELECT distinct Name FROM Transport_Provider";
                    SqlCommand cm2 = new SqlCommand(SelectTransport, conn);
                    cm2.CommandText = SelectTransport;
                    SqlDataReader drd2 = cm2.ExecuteReader();

                    while (drd2.Read())
                    {
                        comboBox2.Items.Add(drd2["Name"].ToString());
                    }
                }
            }
            conn.Close();
            

        }
        public float oneWayFee;
        public string transportProviderName;
        public string pickUpTime;
        public string returnTime;
        public string isOneWay;
        public string type;
        public string totalAmount;
        public bool isReadyToAdd;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DIRECT TO TRANSPORT VENDOR DIRECTORY
            this.Hide();
            new Form6().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DIRECT TO PASSENGER DIRECTORY
            this.Hide();
            new Form5().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            new Form3().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //existing address loaded in Passenger database, can be edited
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //existing address loaded in Passenger database, can be edited
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // this will calculate the payment and display in the payment box
            //int oneWayFee;
            oneWayFee = 0;
            conn = DBConnection.OpenConnection();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                if (comboBox2.SelectedItem != null)
                {
                    transportProviderName = comboBox2.SelectedItem.ToString();
                    Console.WriteLine(transportProviderName);
                    string getOneWayFee = "select top 1 One_Way_Payment from Transport_Provider where Name = '" + transportProviderName + "' order by One_Way_Payment desc ";
                    SqlCommand cm3 = new SqlCommand(getOneWayFee, conn);
                    cm3.CommandText = getOneWayFee;
                    SqlDataReader drd3 = cm3.ExecuteReader();
                    
                    while (drd3.Read())
                    {
                        Console.WriteLine(drd3["One_Way_Payment"]);
                        oneWayFee = float.Parse(drd3["One_Way_Payment"].ToString());

                    }



                    if (radioButton1.Checked == true) //oneway
                    {
                        if (radioButton4.Checked == true) //wheelchair
                        {
                            oneWayFee = oneWayFee + 4;
                        }
                        else if (radioButton3.Checked == true) //ambulatory
                        {
                            oneWayFee = oneWayFee + 8;
                        }
                    }

                    else if (radioButton2.Checked == true) //roundtrip
                    {
                        oneWayFee = oneWayFee * 2;
                        if (radioButton4.Checked == true) //wheelchair
                        {
                            oneWayFee = oneWayFee + 4;
                        }
                        else if (radioButton3.Checked == true) //ambulatory
                        {
                            oneWayFee = oneWayFee + 8;
                        }
                    }
                }
                
                conn.Close();
            }
            textBox8.Text = oneWayFee.ToString();
            oneWayFee = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Add Order to OrderDetails
            if (DateTime.Compare(dateTimePicker2.Value, dateTimePicker3.Value) == 0)
            {

                MessageBox.Show("Please enter valid Pickup Time.");
            }

            //Constants.returnClientID();
            conn = DBConnection.OpenConnection();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                
                string passengerName = comboBox1.Text;
                string transportProvider = comboBox2.Text;
                string orderFor = dateTimePicker1.Value.ToString();
                string pickupAddress = textBox2.Text;
                string dropoffAddress = textBox3.Text;
                

                if (string.IsNullOrEmpty(passengerName)) {

                    MessageBox.Show("ERROR! Please select valid Passenger Name.");
                    isReadyToAdd = false;
                }
                else
                {
                    isReadyToAdd = true;
                }

                if (string.IsNullOrEmpty(transportProvider))
                {

                    MessageBox.Show("ERROR! Please select valid Transport Provider.");
                    isReadyToAdd = false;
                }
                else
                {
                    isReadyToAdd = true;
                }

                if (string.IsNullOrEmpty(orderFor))
                {

                    MessageBox.Show("ERROR! Please select valid Date.");
                    isReadyToAdd = false;
                }
                else
                {
                    isReadyToAdd = true;
                }

                if (string.IsNullOrEmpty(pickupAddress))
                {

                    MessageBox.Show("ERROR! Please select valid Pickup Address.");
                    isReadyToAdd = false;
                }
                else
                {
                    isReadyToAdd = true;
                }

                {
                    if (string.IsNullOrEmpty(isOneWay))
                    {
                        MessageBox.Show("Error! Please select valid Trip Type.");
                        isReadyToAdd = false;
                    }
                    else if (isOneWay == "Round Trip")
                    {
                        if (string.IsNullOrEmpty(dropoffAddress))
                        {

                            MessageBox.Show("ERROR! Please select valid Dropoff Address.");
                            isReadyToAdd = false;
                        }
                        else
                        {
                            isReadyToAdd = true;
                        }
                        if (string.IsNullOrEmpty(returnTime))
                        {
                            MessageBox.Show("Error! Please select valid Return Time.");
                            isReadyToAdd = false;
                        }
                        else
                        {
                            isReadyToAdd = true;
                        }
                    }
                    else
                    {
                        isReadyToAdd = true;
                    }

                }

                if (string.IsNullOrEmpty(type))
                {
                    MessageBox.Show("Error! Please select valid Vehicle Type.");
                    isReadyToAdd = false;
                }
                else
                {
                    isReadyToAdd = true;
                }

                if (string.IsNullOrEmpty(textBox8.Text.ToString()))
                {
                    MessageBox.Show("Please CALCULATE total payment amount.");
                    isReadyToAdd = false;
                }
                else
                {
                    isReadyToAdd = true;
                }


                if (isReadyToAdd && isOneWay == "Round Trip")
                {
                    string query = "INSERT INTO OrderDetails(Transport_Provider_idTransport_Provider, Passenger_idPassenger, WC_Ambulatory, OrderDate, TotalPayment, isOne_Way, Date_for_Order, Pickup_Time, Pickup_Address, Drop_off_Address, ReturnTime) VALUES ((SELECT distinct idTransport_Provider from Transport_Provider WHERE Name = '" + transportProvider + "'), (SELECT idPassenger from Passenger WHERE Name = '" + passengerName + "'),'" + type + "', (SELECT GETDATE()), '" + totalAmount + "','" + isOneWay + "','" + orderFor + "','" + pickUpTime + "','" + pickupAddress + "','" + dropoffAddress + "','" + returnTime + "' )";
                    SqlCommand cm = new SqlCommand(query, conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Order successfully added!");
                    cm.Dispose();
                    conn.Close();
                }
                else if (isReadyToAdd && isOneWay == "One Way")
                {
                    string query = "INSERT INTO OrderDetails(Transport_Provider_idTransport_Provider, Passenger_idPassenger, WC_Ambulatory, OrderDate, TotalPayment, isOne_Way, Date_for_Order, Pickup_Time, Pickup_Address) VALUES ((SELECT idTransport_Provider from Transport_Provider WHERE Name = '" + transportProvider + "'), (SELECT idPassenger from Passenger WHERE Name = '" + passengerName + "'),'" + type + "', (SELECT GETDATE()), '" + totalAmount + "','" + isOneWay + "','" + orderFor + "','" + pickUpTime + "','" + pickupAddress + "' )";
                    SqlCommand cm = new SqlCommand(query, conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Order successfully added!");
                    cm.Dispose();
                    conn.Close();
                }
                
                
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            returnTime = dateTimePicker2.Value.ToLongTimeString().Substring(0, 4) + ":00";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                isOneWay = "One Way";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                type = "Wheelchair";
            }
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
             
            dateTimePicker3.MinDate = dateTimePicker2.Value;
            pickUpTime = dateTimePicker2.Value.ToLongTimeString().Substring(0, 4) + ":00";
            //Console.WriteLine(pickUpTime);


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                isOneWay = "Round Trip";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                type = "Ambulatory";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            totalAmount = textBox8.Text.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Form5().Show();
        }
    }
}