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
    public partial class SQLMenuOracle : Form
    {
        public SQLMenuOracle()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PropertyOption property = new PropertyOption();
            property.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChoosedOption = $"select * from ";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ChoosedOption += "CLIENT";
                    break;
                case 1:
                    ChoosedOption += "PROPERTY_INFO";
                    break;
                case 2:
                    ChoosedOption += "COUNTRY_ID";
                    break;
                case 3:
                    ChoosedOption += "P_FACILITY";
                    break;
                case 4:
                    ChoosedOption += "P_LOCATION";
                    break;
                case 5:
                    ChoosedOption += "P_STATUS";
                    break;
                case 6:
                    ChoosedOption += "P_TYPE";
                    break;
            }
            DataBaseConnection connection = new DataBaseConnection(ChoosedOption);
            dataGridView1.DataSource = connection.ReadTables();
        }

        public int ClientRows()
        {
            DataBaseConnection connection = new DataBaseConnection("select * from client");
            dataGridView1.DataSource = connection.ReadTables();
            return dataGridView1.RowCount;
        }

        public int CountryRows()
        {
            DataBaseConnection connection = new DataBaseConnection("select * from country_id");
            dataGridView1.DataSource = connection.ReadTables();
            return dataGridView1.RowCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientOption client = new ClientOption();
            client.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Hide();
            button3.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.Hide();
            button4.Show();
            DataBaseConnection connection = new DataBaseConnection($"select * from client where cnp='{textBox1.Text}'");
            dataGridView1.DataSource = connection.ReadTables();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Hide();
            button6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button5.Show();
            button6.Hide();

            if (textBox2.Text == "" && !checkBox1.Checked)
            {
                DataBaseConnection connection = new DataBaseConnection($"select info.prop_id, l.country_name, l.city_name, c.street_name, c.street_number,t.type_name,t.prop_cost,t.prop_meters,s.status_rent,info.prop_owner from p_location l, country_id c, p_status s, property_info info ,p_type t where c.country_id = l.location_info and l.location_id = info.prop_location and t.type_id = info.prop_type and info.prop_status = s.status_id");
                dataGridView1.DataSource = connection.ReadTables();
            }
            else if (textBox2.Text != "" && checkBox1.Checked)
            {
                DataBaseConnection connection = new DataBaseConnection($"select info.prop_id,l.country_name, l.city_name, c.street_name, c.street_number,t.type_name,t.prop_cost,t.prop_meters,s.status_rent,info.prop_owner from p_location l, country_id c, p_status s, property_info info ,p_type t where c.country_id = l.location_info and l.location_id = info.prop_location and t.type_id = info.prop_type and info.prop_status = s.status_id and l.country_name ='{textBox2.Text}' and s.status_rent = 'Avaible'");
                dataGridView1.DataSource = connection.ReadTables();
            }
            else if (textBox2.Text == "" && checkBox1.Checked)
            {
                DataBaseConnection connection = new DataBaseConnection($"select info.prop_id,l.country_name, l.city_name, c.street_name, c.street_number,t.type_name,t.prop_cost,t.prop_meters,s.status_rent,info.prop_owner from p_location l, country_id c, p_status s, property_info info ,p_type t where c.country_id = l.location_info and l.location_id = info.prop_location and t.type_id = info.prop_type and info.prop_status = s.status_id and s.status_rent = 'Avaible'");
                dataGridView1.DataSource = connection.ReadTables();
            }
            else if (textBox2.Text != "" && !checkBox1.Checked)
            {
                DataBaseConnection connection = new DataBaseConnection($"select info.prop_id,l.country_name, l.city_name, c.street_name, c.street_number,t.type_name,t.prop_cost,t.prop_meters,s.status_rent,info.prop_owner from p_location l, country_id c, p_status s, property_info info ,p_type t where c.country_id = l.location_info and l.location_id = info.prop_location and t.type_id = info.prop_type and info.prop_status = s.status_id and l.country_name ='{textBox2.Text}'");
                dataGridView1.DataSource = connection.ReadTables();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AtribuieClient atribuieClient = new AtribuieClient();
            atribuieClient.Show();
        }
    }
}
