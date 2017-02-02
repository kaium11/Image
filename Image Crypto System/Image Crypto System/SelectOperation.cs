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
    public partial class SelectOperation : Form
    {
        public SelectOperation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string slc = Convert.ToString(comboBox1.SelectedItem);
            if (slc == "")
            {
                MessageBox.Show("SELECT ONE ITEM PLZ!!!", "Image Crypto System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                comboBox1.Focus();
            }
            else if (slc == "ENCRYPTION")
            {
                ActivitySelect frm = new ActivitySelect();
                //Form1 fr = new Form1();
                frm.Show();
                this.Hide();
            }
            else if (slc == "DECRYPTION")
            {
                DECRYPTION frm = new DECRYPTION();
                frm.Show();
                this.Hide();
            }
        }
    }
}
