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
    public partial class AtribuieClient : Form
    {
        public AtribuieClient()
        {
            InitializeComponent();
        }

        private void AtribuieClient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClientToProperty clientToProperty = new AddClientToProperty(textBox3.Text, textBox1.Text, textBox2.Text, monthCalendar1.SelectionRange.Start.Date, monthCalendar2.SelectionRange.Start.Date);
            DataBaseConnection.InsertIntoDataBase(clientToProperty.PropertyOwner());
            DataBaseConnection.InsertIntoDataBase(clientToProperty.PropertyStatus());
            label6.Text = "Contract signed succesfull";
        }
    }
}
