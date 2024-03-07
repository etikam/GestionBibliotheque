using MySql.Data.MySqlClient;
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
            refrech_counting refrechCounting = new refrech_counting(this);
           

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

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click_1(object sender, EventArgs e)
        {

        }

         void remplissage_nombre()
        {
            DBConnector con = new DBConnector();
            // Définir les chaînes de connexion à la base de données
            string connectionString = con.getConnectionString(); // Remplacez YourConnectionString par votre propre chaîne de connexion

            // Compter le nombre de lecteurs
            string queryLecteurs = "SELECT COUNT(*) FROM readers";
            int nombreLecteurs = GetCountFromTable(connectionString, queryLecteurs);

            // Sommer les quantités de tous les livres
            string queryQuantiteLivres = "SELECT SUM(quantite) FROM books";
            int nombreLivres = GetCountFromTable(connectionString, queryQuantiteLivres);

            // Compter le nombre d'emprunts
            string queryEmprunts = "SELECT COUNT(*) FROM borrowed";
            int nombreEmprunts = GetCountFromTable(connectionString, queryEmprunts);

            // Mettre à jour les labels avec les nombres obtenus
            l_nombre_lecteur.Text = nombreLecteurs.ToString();
            l_nombre_livres.Text = nombreLivres.ToString();
            l_nombre_emprunts.Text = nombreEmprunts.ToString();
        }
         int GetCountFromTable(string connectionString, string query)
        {
            int count = 0;
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la récupération du nombre d'éléments : " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return count;
        }

        private void l_nombre_lecteur_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            refrech_counting refrechCounting = new refrech_counting(this);
        }
    }
}
