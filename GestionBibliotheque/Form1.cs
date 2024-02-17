using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibliotheque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            F_Connexion f = new F_Connexion();
            this.Hide();
            f.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_add_reader f = new F_add_reader();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_add_book f = new F_add_book();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            F_emprunt_emprunter f = new F_emprunt_emprunter();
            f.Show();
            this.Hide();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            F_emprunt_emprunter f_emprunt_emprunter = new F_emprunt_emprunter();
            f_emprunt_emprunter.Show();
        }

        private void btn_lecteurs_Click(object sender, EventArgs e)
        {
            F_add_reader f_add_reader = new F_add_reader();
            f_add_reader.Show();
        }

        private void btn_livres_Click(object sender, EventArgs e)
        {
            F_add_book f_add_book = new F_add_book();
            f_add_book.Show();
        }
    }
}
