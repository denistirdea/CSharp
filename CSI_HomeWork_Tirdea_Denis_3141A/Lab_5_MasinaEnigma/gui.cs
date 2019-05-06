using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasinaEnigma
{
    public partial class gui : Form
    {
        public gui()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select" || comboBox2.Text == "Select" || comboBox3.Text == "Select" || comboBox4.Text == "Select" || comboBox5.Text == "Select")
            {
                MessageBox.Show("Error, please select all fields");
            }
            else {
                richTextBox2.Text = Utils.Encrypt_Decrypt(richTextBox1.Text.ToUpper(), comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox5.SelectedIndex);
            }
            
        }
    }
}
