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
    public partial class DeleteClient : Form
    {
        public DeleteClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient add = new AddClient();
            Client client = new Client(null, null, textBox3.Text,add.monthCalendar1.SelectionStart, null);

            if (textBox1.Text != "")
            {
                DataBaseConnection.InsertIntoDataBase(client.DeleteClientProperty());
                DataBaseConnection.InsertIntoDataBase(client.DeleteClient());
                DataBaseConnection.InsertIntoDataBase(client.DeletePropertyStatus(textBox1.Text));
            }

            else {
                DataBaseConnection.InsertIntoDataBase(client.DeleteClient());
            }
            MessageBox.Show("Client Deleted");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteClient_Load(object sender, EventArgs e)
        {

        }
    }
}
