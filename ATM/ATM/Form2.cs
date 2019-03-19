using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ATM
{
    public partial class Form2 : Form
    {
        string ID;
        string password;
       public string nume;
        string prenume;
        string oras;
        int varsta;
        int CNP;
        int nr_telefon;


        public Form2()
        {
            InitializeComponent();
            
        }
        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
            }
        }
        public string Nume1
        {
            get { return textBox1.Text; }
        }





        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool exists = File.Exists(textBox1.Text+".txt");
            if (exists == false)
            {
                var save = string.Join(Environment.NewLine, 0, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                File.WriteAllText(textBox1.Text + ".txt", save);
                Close();
            }
            else
            {
                MessageBox.Show("Acest ID este deja utilizat");
                textBox1.Text = String.Empty;
                
            }


        }
    }
}
