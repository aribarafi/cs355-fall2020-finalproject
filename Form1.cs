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
using System.Configuration;
using static WindowsFormsApp1.DBConnection;
using static WindowsFormsApp1.Constants;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Set to no text.
            //textBox2.Text = "";
            // The password character is an asterisk.
            textBox2.PasswordChar = '*';

        }
        
        public void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = DBConnection.OpenConnection();
            if (conn.State == System.Data.ConnectionState.Open)
            {

                string username = textBox1.Text;
                string password = textBox2.Text;

                string LoginQuery = "SELECT count(1) FROM Client WHERE Username = '" + username + "' AND Password = HASHBYTES('SHA1', '" + password + "')";
                SqlDataAdapter sda = new SqlDataAdapter(LoginQuery, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Login successful!");
                    Constants.loginClientUser = username;
                    this.Hide();
                    new Form2().Show();
                }
                
                else
                {
                    MessageBox.Show("Login unsuccessful! Incorrect username and/or password.");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
