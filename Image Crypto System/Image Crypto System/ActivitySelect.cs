using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Image_Crypto_System
{
    public partial class ActivitySelect : Form
    {
        public ActivitySelect()
        {
            InitializeComponent();
        }

        private void ActivitySelect_Load(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //button5.Text = "Image From Base 64" + char.ConvertFromUtf32(8594);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            try
            {

                if (dr == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog1.FileName;
                    string s = textBox1.Text;
                    if (s.Contains("jpg"))
                    {
                        textBox1.Text = openFileDialog1.FileName;
                    }
                    else
                    {
                        MessageBox.Show("Only Jpg images Please", "Image Crypto System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox1.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string data = "";
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No Path Specified", "Image Crypto System", MessageBoxButtons.OK, MessageBoxIcon.Question);
                textBox1.Focus();
            }
            else
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(textBox1.Text);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                data = base64ImageRepresentation;
                // string base64ImageRepresentation=Convert.to
                richTextBox1.Text = base64ImageRepresentation;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(richTextBox1.Text.ToString());
            MessageBox.Show("Copied To Clipboard!!!", "Image Crypto System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            richTextBox1.Clear();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            DECRYPTION fm = new DECRYPTION();
            fm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Send fr = new Send();
            fr.getData = data;
            fr.Show();
            this.Hide();
        }

        
       
    }
}
