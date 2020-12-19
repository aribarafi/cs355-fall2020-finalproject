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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            conn = DBConnection.OpenConnection();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string SelectAll = "SELECT * FROM Transport_Provider";

                SqlCommand cm = new SqlCommand(SelectAll, conn);

                cm.CommandText = SelectAll;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    comboBox1.Items.Add(drd["Name"].ToString());
                    comboBox3.Items.Add(drd["One_Way_Payment"].ToString());
                    comboBox4.Items.Add(drd["Return_Payment"].ToString());

                }
                drd.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Search By Name
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Search By ID
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Search by one way fees
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Search by two way fees
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Search by mileage fees
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            
            if (comboBox1.SelectedItem != null & comboBox3.SelectedItem== null & comboBox4.SelectedItem == null )
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {

                    listView1.View = View.Details;

                    listView1.Columns.Add("Transporter ID");
                    listView1.Columns.Add("Transporter Name");
                    listView1.Columns.Add("One Way fees");
                    listView1.Columns.Add("Return Fees");


                    //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                    string addOrders = "SELECT * FROM Transport_Provider where [Name] = " + "'" + comboBox1.SelectedItem + "'";

                    SqlCommand cm = new SqlCommand(addOrders, conn);

                    cm.CommandText = addOrders;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = drd["idTransport_Provider"].ToString();        // 1st column text
                        item.SubItems.Add(drd["Name"].ToString());
                        item.SubItems.Add(drd["One_Way_Payment"].ToString());
                        item.SubItems.Add(drd["Return_Payment"].ToString());
                        listView1.Items.Add(item);
                    }
                    drd.Close();
                }
            }

            if (comboBox1.SelectedItem == null & comboBox3.SelectedItem != null & comboBox4.SelectedItem == null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    listView1.View = View.Details;

                    listView1.Columns.Add("Transporter ID");
                    listView1.Columns.Add("Transporter Name");
                    listView1.Columns.Add("One Way fees");
                    listView1.Columns.Add("Return Fees");


                    //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                    string addOrders = "SELECT * FROM Transport_Provider where One_Way_Payment = " + "'" + comboBox3.SelectedItem + "'";

                    SqlCommand cm = new SqlCommand(addOrders, conn);

                    cm.CommandText = addOrders;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = drd["idTransport_Provider"].ToString();        // 1st column text
                        item.SubItems.Add(drd["Name"].ToString());
                        item.SubItems.Add(drd["One_Way_Payment"].ToString());
                        item.SubItems.Add(drd["Return_Payment"].ToString());
                        listView1.Items.Add(item);
                    }
                    drd.Close();
                }
            }

                if (comboBox1.SelectedItem == null & comboBox3.SelectedItem == null & comboBox4.SelectedItem != null)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        listView1.View = View.Details;

                        listView1.Columns.Add("Transporter ID");
                        listView1.Columns.Add("Transporter Name");
                        listView1.Columns.Add("One Way fees");
                        listView1.Columns.Add("Return Fees");


                        //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                        string addOrders = "SELECT * FROM Transport_Provider where Return_Payment = " + "'" + comboBox4.SelectedItem + "'";

                        SqlCommand cm = new SqlCommand(addOrders, conn);

                        cm.CommandText = addOrders;

                        SqlDataReader drd = cm.ExecuteReader();
                        while (drd.Read())
                        {
                            var item = new ListViewItem();
                            item.Text = drd["idTransport_Provider"].ToString();        // 1st column text
                            item.SubItems.Add(drd["Name"].ToString());
                            item.SubItems.Add(drd["One_Way_Payment"].ToString());
                            item.SubItems.Add(drd["Return_Payment"].ToString());
                            listView1.Items.Add(item);
                        }
                        drd.Close();
                    }

                }

                if(comboBox1.SelectedItem != null & comboBox3.SelectedItem != null & comboBox4.SelectedItem == null)
                {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    listView1.View = View.Details;

                    listView1.Columns.Add("Transporter ID");
                    listView1.Columns.Add("Transporter Name");
                    listView1.Columns.Add("One Way fees");
                    listView1.Columns.Add("Return Fees");

                    
                    //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                    string addOrders = "SELECT * FROM Transport_Provider where [Name] = " + "'"+ comboBox1.SelectedItem+ "'" +" and One_Way_Payment = " + "'" + comboBox3.SelectedItem + "'";
                    MessageBox.Show(addOrders);
                    SqlCommand cm = new SqlCommand(addOrders, conn);

                    cm.CommandText = addOrders;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = drd["idTransport_Provider"].ToString();        // 1st column text
                        item.SubItems.Add(drd["Name"].ToString());
                        item.SubItems.Add(drd["One_Way_Payment"].ToString());
                        item.SubItems.Add(drd["Return_Payment"].ToString());
                        listView1.Items.Add(item);
                    }
                    drd.Close();
                }

                }

            if (comboBox1.SelectedItem != null & comboBox3.SelectedItem == null & comboBox4.SelectedItem != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    listView1.View = View.Details;

                    listView1.Columns.Add("Transporter ID");
                    listView1.Columns.Add("Transporter Name");
                    listView1.Columns.Add("One Way fees");
                    listView1.Columns.Add("Return Fees");

                    //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                    string addOrders = "SELECT * FROM Transport_Provider where [Name] = " + "'" + comboBox1.SelectedItem + "'" +" and Return_Payment = " + "'" + comboBox4.SelectedItem + "'";

                    SqlCommand cm = new SqlCommand(addOrders, conn);

                    cm.CommandText = addOrders;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = drd["idTransport_Provider"].ToString();        // 1st column text
                        item.SubItems.Add(drd["Name"].ToString());
                        item.SubItems.Add(drd["One_Way_Payment"].ToString());
                        item.SubItems.Add(drd["Return_Payment"].ToString());
                        listView1.Items.Add(item);
                    }
                    drd.Close();
                }

            }

            if (comboBox1.SelectedItem == null & comboBox3.SelectedItem != null & comboBox4.SelectedItem != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    listView1.View = View.Details;

                    listView1.Columns.Add("Transporter ID");
                    listView1.Columns.Add("Transporter Name");
                    listView1.Columns.Add("One Way fees");
                    listView1.Columns.Add("Return Fees");


                    //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                    string addOrders = "SELECT * FROM Transport_Provider where One_Way_Payment = " + "'" + comboBox3.SelectedItem + "' and Return_Payment = " + "'" + comboBox4.SelectedItem + "'";

                    SqlCommand cm = new SqlCommand(addOrders, conn);

                    cm.CommandText = addOrders;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = drd["idTransport_Provider"].ToString();        // 1st column text
                        item.SubItems.Add(drd["Name"].ToString());
                        item.SubItems.Add(drd["One_Way_Payment"].ToString());
                        item.SubItems.Add(drd["Return_Payment"].ToString());
                        listView1.Items.Add(item);
                    }
                    drd.Close();
                }

            }

            if (comboBox1.SelectedItem != null & comboBox3.SelectedItem != null & comboBox4.SelectedItem != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    listView1.View = View.Details;

                    listView1.Columns.Add("Transporter ID");
                    listView1.Columns.Add("Transporter Name");
                    listView1.Columns.Add("One Way fees");
                    listView1.Columns.Add("Return Fees");

                  
                    //"SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')"
                    string addOrders = "SELECT * FROM Transport_Provider where [Name] = " + "'" + comboBox1.SelectedItem + "' and One_Way_Payment = "+ "'" +comboBox3.SelectedItem +"' and Return_Payment = " + "'" + comboBox4.SelectedItem + "' ORDER BY NAME";

                    SqlCommand cm = new SqlCommand(addOrders, conn);

                    cm.CommandText = addOrders;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        var item = new ListViewItem();
                        item.Text = drd["idTransport_Provider"].ToString();        // 1st column text
                        item.SubItems.Add(drd["Name"].ToString());
                        item.SubItems.Add(drd["One_Way_Payment"].ToString());
                        item.SubItems.Add(drd["Return_Payment"].ToString());
                        listView1.Items.Add(item);
                    }
                    drd.Close();
                }

            }

            if (comboBox1.SelectedItem == null & comboBox3.SelectedItem == null & comboBox4.SelectedItem == null)
                {
                    MessageBox.Show("Please select a value");
                    return;
                }
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string SelectAll = "SELECT * FROM Transport_Provider";

                SqlCommand cm = new SqlCommand(SelectAll, conn);

                cm.CommandText = SelectAll;

                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    comboBox1.Items.Add(drd["Name"].ToString());
                    comboBox3.Items.Add(drd["One_Way_Payment"].ToString());
                    comboBox4.Items.Add(drd["Return_Payment"].ToString());

                }
                drd.Close();
            }


        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
           
            if (comboBox1.SelectedItem != null & comboBox3.SelectedItem == null & comboBox4.SelectedItem == null)
            {
              
                comboBox3.Items.Clear();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                        string SelectAll = "SELECT One_Way_Payment FROM Transport_Provider where Name = " + "'" + comboBox1.SelectedItem + "'";

                        SqlCommand cm = new SqlCommand(SelectAll, conn);

                        cm.CommandText = SelectAll;

                        SqlDataReader drd = cm.ExecuteReader();
                        while (drd.Read())
                        {
                            comboBox3.Items.Add(drd["One_Way_Payment"].ToString());
                        }
                        drd.Close();
                        
                    

                }

                comboBox4.Items.Clear();


                if (conn.State == System.Data.ConnectionState.Open)
                {
                     string SelectAll = "SELECT Return_Payment FROM Transport_Provider where Name = " + "'" + comboBox1.SelectedItem + "'";

                        SqlCommand cm = new SqlCommand(SelectAll, conn);

                        cm.CommandText = SelectAll;

                        SqlDataReader drd = cm.ExecuteReader();
                        while (drd.Read())
                        {
                            comboBox4.Items.Add(drd["Return_Payment"].ToString());
                        }
                        drd.Close();
                }

                
            }
            if (comboBox1.SelectedItem != null & comboBox3.SelectedItem == null & comboBox4.SelectedItem != null)
            {

                comboBox3.Items.Clear();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT One_Way_Payment FROM Transport_Provider where Name = " + "'" + comboBox1.SelectedItem + "' and Return_Payment = " +"'"+ comboBox4.SelectedItem +"'" ;

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        comboBox3.Items.Add(drd["One_Way_Payment"].ToString());
                    }
                    drd.Close();



                }

               
                


            }
            if (comboBox1.SelectedItem != null & comboBox3.SelectedItem != null & comboBox4.SelectedItem == null)
            {

               

                comboBox4.Items.Clear();


                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT Return_Payment FROM Transport_Provider where Name = " + "'" + comboBox1.SelectedItem + "' and One_Way_Payment = " + "'"+ comboBox3.SelectedItem +"'" ;

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        comboBox4.Items.Add(drd["Return_Payment"].ToString());
                    }
                    drd.Close();
                }


            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null & comboBox1.SelectedItem == null & comboBox4.SelectedItem == null)
            {
                comboBox1.Items.Clear();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT Name FROM Transport_Provider where One_Way_Payment = " + "'" + comboBox3.SelectedItem + "'";

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        comboBox1.Items.Add(drd["Name"].ToString());
                    }
                    drd.Close();



                }

                comboBox4.Items.Clear();


                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT Return_Payment FROM Transport_Provider where One_Way_Payment = " + "'" + comboBox3.SelectedItem + "'";

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        comboBox4.Items.Add(drd["Return_Payment"].ToString());
                    }
                    drd.Close();
                }

            }
            if (comboBox3.SelectedItem != null & comboBox1.SelectedItem == null & comboBox4.SelectedItem != null)
            {
                comboBox1.Items.Clear();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT Name FROM Transport_Provider where One_Way_Payment = " + "'" + comboBox3.SelectedItem + "' and Return_Payment = "+"'"+ comboBox4.SelectedItem+"'" ;

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
            if (comboBox3.SelectedItem != null & comboBox1.SelectedItem != null & comboBox4.SelectedItem == null)
            {
             
                comboBox4.Items.Clear();


                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT Return_Payment FROM Transport_Provider where One_Way_Payment = " + "'" + comboBox3.SelectedItem + "' and Name = " +"'" + comboBox1.SelectedItem +"'" ;

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        comboBox4.Items.Add(drd["Return_Payment"].ToString());
                    }
                    drd.Close();
                }

            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {   /*
            if (comboBox4.SelectedItem == null & comboBox3.SelectedItem == null)
            {
                comboBox1.Enabled = true;
            }
            if (comboBox4.SelectedItem != null || comboBox3.SelectedItem != null)
            {
                comboBox1.Enabled = false;
            }
            if (comboBox4.SelectedItem == null & comboBox1.SelectedItem == null)
            {
                comboBox3.Enabled = true;
            }
            if (comboBox1.SelectedItem != null || comboBox4.SelectedItem != null)
            {
                comboBox3.Enabled = false;
            }
            */
            if (comboBox3.SelectedItem != null & comboBox1.SelectedItem == null & comboBox4.SelectedItem == null)
            {
                comboBox1.Items.Clear();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT Name FROM Transport_Provider where Return_Payment = " + "'" + comboBox4.SelectedItem + "'";

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        comboBox1.Items.Add(drd["Name"].ToString());
                    }
                    drd.Close();



                }

                comboBox3.Items.Clear();


                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT One_Way_Payment FROM Transport_Provider where Return_Payment = " + "'" + comboBox4.SelectedItem + "'" ;

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        comboBox3.Items.Add(drd["One_Way_Payment"].ToString());
                    }
                    drd.Close();
                }
            }
            if (comboBox3.SelectedItem != null & comboBox1.SelectedItem == null & comboBox4.SelectedItem != null)
            {
                comboBox1.Items.Clear();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT Name FROM Transport_Provider where Return_Payment = " + "'" + comboBox4.SelectedItem + "' and One_Way_Payment = "+"'"+ comboBox3.SelectedItem +"'";

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

            if (comboBox3.SelectedItem != null & comboBox1.SelectedItem != null & comboBox4.SelectedItem == null)
            {
               
              comboBox3.Items.Clear();


                if (conn.State == System.Data.ConnectionState.Open)
                {
                    string SelectAll = "SELECT One_Way_Payment FROM Transport_Provider where Return_Payment = " + "'" + comboBox4.SelectedItem + "' and Name = "+"'"+ comboBox1.SelectedItem+"'" ;

                    SqlCommand cm = new SqlCommand(SelectAll, conn);

                    cm.CommandText = SelectAll;

                    SqlDataReader drd = cm.ExecuteReader();
                    while (drd.Read())
                    {
                        comboBox3.Items.Add(drd["One_Way_Payment"].ToString());
                    }
                    drd.Close();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Form6().Show();
        }
    }
    }

