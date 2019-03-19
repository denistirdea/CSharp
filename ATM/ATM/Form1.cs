using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class Form1 : Form
    {
        public string[] array = new string[8];
        public static string suma;
        public static string password;
        public static string nume;
        public static string prenume;
        public static string oras;
        public static string varsta;
        public static string CNP;
        public string nr_telefon;
        public int a = 1;

        
        public void at(string[] array)
        {
            suma = array[0];
            password = array[1];
            nume = array[2];
            prenume = array[3];
            CNP = array[4];
            nr_telefon = array[5];
            varsta = array[6];
            oras = array[7];
        }
        

        public void citire()
        {
            bool check = (checkBox1.Checked);
            bool exists = File.Exists(textBox1.Text + ".txt");
            if (exists == false)
            {
                MessageBox.Show("Date invalide / Cont inexistent");
                a = 0; 
            }
            else
            {
                a = 1;
                int counter = 0;
                string line;
                
                System.IO.StreamReader file =
                new System.IO.StreamReader(textBox1.Text + ".txt");
                while ((line = file.ReadLine()) != null)
                {
                    array[counter] = line;
                    counter++;
                }
                at(array);
            }
            
            if (check == false)
            {
                MessageBox.Show("You need to accept T & C");
                a = 0;
            }
            else
                a = 1;
        }
        public void verificare() {
            if (textBox2.Text != password)
            {
                MessageBox.Show("Password wrong");
                textBox2.Text = String.Empty;
                a = 0;
            }
            else if ((textBox2.Text == password) && a == 1)
            {
               
                MessageBox.Show("Loggin Succesfull \nPlease wait a few seconds");
                

            }
            

        }
       // public string nume { get; set; }
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void IMAGE2_Click_2(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            citire();
            verificare();
            Operatii f3 = new Operatii();
            if(a == 1)
            {
                f3.Show();
                this.Hide();
               for (int i = 0; i <= 7; i++)
                f3.schimba[i] = String.Copy(array[i]);
                f3.label2.Text = array[2] + " " + array[3];
                f3.fisier = textBox1.Text;
                f3.label10.Text = suma;


            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
