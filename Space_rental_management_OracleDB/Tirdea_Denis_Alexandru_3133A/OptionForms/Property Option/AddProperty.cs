using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tirdea_Denis_Alexandru_3133A
{
    public partial class AddProperty : Form
    {
        public AddProperty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Property addProperty = new Property(textBox5.Text, textBox4.Text, textBox3.Text, comboBox4.SelectedItem.ToString(), textBox1.Text, textBox2.Text, comboBox5.SelectedItem.ToString(), comboBox6.SelectedItem.ToString(), comboBox7.SelectedItem.ToString(), comboBox8.SelectedItem.ToString(), comboBox9.SelectedItem.ToString(), comboBox10.SelectedItem.ToString(), comboBox11.SelectedItem.ToString(), comboBox12.SelectedItem.ToString(),textBox6.Text);
            DataBaseConnection.InsertIntoDataBase(addProperty.AddCountry());
            DataBaseConnection.InsertIntoDataBase(addProperty.AddLocation());
            DataBaseConnection.InsertIntoDataBase(addProperty.AddFacility());
            DataBaseConnection.InsertIntoDataBase(addProperty.AddType());
            DataBaseConnection.InsertIntoDataBase(addProperty.AddStatus());
            DataBaseConnection.InsertIntoDataBase(addProperty.AddProperty());
            MessageBox.Show("Property added");
        }

    }
}
