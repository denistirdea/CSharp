using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_ADFGVX
{
    public partial class gui : Form
    {
        public gui()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                richTextBox2.Text = Utils.EncryptADFGVX(richTextBox1.Text.ToUpper(), textBox1.Text.ToUpper(), textBox2.Text.ToUpper());
            else {
                richTextBox2.Text = Utils.DecryptADFGVX(richTextBox1.Text.ToUpper(), textBox1.Text.ToUpper(), textBox2.Text.ToUpper());
            }
        }
    }
}
