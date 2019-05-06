using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSI_HomeWork_Tirdea_Denis_3141A
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
                richTextBox2.Text = Utils.Encrypt(richTextBox1.Text.ToUpper(), textBox1.Text.ToUpper());
            else
                richTextBox2.Text = Utils.Decrypt(richTextBox1.Text.ToUpper(), textBox1.Text.ToUpper());
        }
    }
}

