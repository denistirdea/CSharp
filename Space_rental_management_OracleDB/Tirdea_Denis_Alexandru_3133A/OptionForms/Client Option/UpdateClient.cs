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
    public partial class UpdateClient : Form
    {
        public UpdateClient()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client(textBox1.Text, textBox2.Text, textBox3.Text, monthCalendar1.SelectionRange.Start.Date, comboBox1.SelectedItem.ToString());
            DataBaseConnection.InsertIntoDataBase(client.UpdateClient());
            MessageBox.Show("Client updated");
        }
    }
}
