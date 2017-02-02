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
    public partial class Send : Form
    {
        public string getData { get;set;}
        public Send()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fr = textBox1.Text;
            string to = textBox2.Text;
            string ps = textBox3.Text;
            textBox1.Text = "imagecryptosystem@gmail.com";
            textBox2.Text = "imagecryptographyreceive@gmail.com";
            textBox3.Text = "11041191104091";

            SendAndRec obj = new SendAndRec();
            MessageBox.Show(fr+" "+to+" "+ps+" "+getData);
            string ms = obj.sendData(fr,to,ps,getData);
            MessageBox.Show(ms);
            MessageBox.Show(getData);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
