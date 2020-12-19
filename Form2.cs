using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form6().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form5().Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form7().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form4().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
