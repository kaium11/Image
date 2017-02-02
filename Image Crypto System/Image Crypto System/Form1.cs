using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Crypto_System
{
    public partial class Form1 : Form
    {
        static string user = "Admin";
        static string pass = "cse11";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string us = textBox1.Text;
            string ps = textBox2.Text;
            if (us == user && ps == pass)
            {
                SelectOperation frm = new SelectOperation();
                //Form1 fr = new Form1();
                frm.Show();
                this.Hide();

            }
            else
            {
                if (us == "" && ps == "")
                {
                    MessageBox.Show("Enter user Name And Password", "Image Crypto System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                   // textBox2.Focus();
                }
                else if (us == "")
                {
                    MessageBox.Show("Enter user Name", "Image Crypto System",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else if (ps == "")
                {
                    MessageBox.Show("Enter Password", "Image Crypto System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
                else
                {
                    MessageBox.Show("Enter correct user Name And Password", "Image Crypto System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Text = "";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
