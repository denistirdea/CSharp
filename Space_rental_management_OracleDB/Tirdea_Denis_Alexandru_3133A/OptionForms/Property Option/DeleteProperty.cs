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
    public partial class DeleteProperty : Form
    {
        public DeleteProperty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Property deleteProperty = new Property(textBox3.Text, null, null, null, null, null, null, null, null, null, null, null, null, null,null);
            deleteProperty.DeleteProperty();
            MessageBox.Show("Property Deleted");
        }
    }
}
