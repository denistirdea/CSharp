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
    public partial class Operatii : Form
    {
       
        public string[] array = new string[8];
        public string[] schimba = new string[8];
        public string suma; public int suma2;
        public string password;
        public string nume;
        public string prenume;
        public string oras;
        public string varsta;
        public string CNP;
        public string nr_telefon;
        public string fisier;
        public int depozit;
        public int retrage;
        public int transfer1;
        public int transfer2;

        public void at()
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


        public void citire_fisier()
        {
            int counter = 0;
            string line;

            Form1 frm1 = new Form1();
            System.IO.StreamReader file =
            new System.IO.StreamReader(fisier + ".txt");
            while ((line = file.ReadLine()) != null)
            {
                array[counter] = line;
                counter++;
            }
            file.Close();
            at();

        }

        public Operatii()
        {
            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Operatii_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            at();
            button1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            at();
            citire_fisier();
            depozit = Int32.Parse(suma);
            if (Int32.Parse(textBox1.Text) > 0)
            {
                depozit = depozit + Int32.Parse(textBox1.Text);
                MessageBox.Show("Noua suma in cont este: " + depozit + "");
                button1.Visible = true;
                var save = string.Join(Environment.NewLine, depozit, password, nume, prenume, CNP, nr_telefon, varsta, oras);
                File.WriteAllText(fisier + ".txt", save);
                textBox1.Text = string.Empty;
                label10.Text = depozit + "";
                
                
                
            }
            else
            {
                MessageBox.Show("Suma trebuie sa fie pozitiva");
                textBox1.Text = string.Empty;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            at();
            citire_fisier();
            retrage = Int32.Parse(suma);
            if (Int32.Parse(textBox2.Text) > 0)
            {
                if (retrage - Int32.Parse(textBox2.Text) < 0)
                {
                    MessageBox.Show("Sold indisponibil");
                    button2.Visible = true;
                    textBox2.Text = string.Empty;
                }
                else
                {
                    retrage = retrage - Int32.Parse(textBox2.Text);
                    MessageBox.Show("Retras cu succes! Sold ramas: " + retrage + "");
                    var save = string.Join(Environment.NewLine, retrage, password, nume, prenume, CNP, nr_telefon, varsta, oras);
                    File.WriteAllText(fisier + ".txt", save);
                    button2.Visible = true;
                    textBox2.Text = string.Empty; label10.Text = retrage + "";
                }
            }
            else
                MessageBox.Show("Nu poti retrage o valoarea negativa");
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            at();
            citire_fisier();
            transfer1 = Int32.Parse(suma);
            if (Int32.Parse(textBox4.Text) > 0)
            {
                if (transfer1 - Int32.Parse(textBox4.Text) < 0)
                {
                    MessageBox.Show("Sold indisponibil pentru trasfer!");
                    button4.Visible = true;
                    textBox3.Text = string.Empty;
                }
                else if (transfer1 - Int32.Parse(textBox4.Text) >= 0)
                {
                    transfer2 = Int32.Parse(textBox4.Text);

                    suma2 = transfer1 - transfer2; //suma2 = ramasa

                    MessageBox.Show("Transfer succesfull! Sold ramas: " + suma2 + "");
                    var save = string.Join(Environment.NewLine, suma2, password, nume, prenume, CNP, nr_telefon, varsta, oras);
                    File.WriteAllText(fisier + ".txt", save);
                    button4.Visible = true;
                    label10.Text = suma2 + "";


                    int counter = 0;
                    string line;

                    string[] array2 = new string[8];

                    System.IO.StreamReader file =
                    new System.IO.StreamReader(textBox3.Text + ".txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        array2[counter] = line;
                        counter++;
                    }
                    file.Close();
                    var save2 = string.Join(Environment.NewLine, transfer2 + Int32.Parse(array2[0]), array2[1], array2[2], array2[3], array2[4], array2[5], array2[6], array2[7]);
                    File.WriteAllText(textBox3.Text + ".txt", save2);

                }
            }
            else
                MessageBox.Show("Suma transferata nu poate fi negativa");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LOGOUT succesfull");
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atentie! LOGOUT necesar");
            System.IO.File.Move(fisier+".txt", textBox6.Text+".txt");
            button8.Visible = true;
            MessageBox.Show("ID schimbat! ");
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
            

            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var save3 = string.Join(Environment.NewLine, schimba[0], textBox5.Text, schimba[2], schimba[3], schimba[4], schimba[5], schimba[6], schimba[7]);
            File.WriteAllText(fisier + ".txt", save3);
            MessageBox.Show("Parola schimbata!");
            button10.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }
    }
}
