using MySql.Data.MySqlClient;
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

namespace GestionBibliotheque
{
    public partial class F_emprunt_emprunter : Form
    {
        public F_emprunt_emprunter()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void panel_emprunter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void F_emprunt_emprunter_Load(object sender, EventArgs e)
        {
            //Remplissage du comboBox des Lecteurs

            try
            {

                string queryCategories = "SELECT * FROM readers";
                DBConnector connexionCategories = new DBConnector();
                MySqlCommand cmd = new MySqlCommand(queryCategories, connexionCategories.Connection);

                connexionCategories.OpenConnection();

                MySqlDataReader reader = cmd.ExecuteReader();

                cb_lecteur.Items.Clear();

                while (reader.Read())
                {
                    String id = reader.GetString("id");
                    String nom = reader.GetString("nom");
                    String prenom = reader.GetString("prenom");
                    String nom_complet = id + " " + nom + " "+ prenom;
                    cb_lecteur.Items.Add(nom_complet);
                }

                reader.Close();
                connexionCategories.CloseConnection();
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                MessageBox.Show("Une erreur s'est produite lors de la récupération des catégories : " + ex.Message);
            }


            // Remplissage du ccomboBox des ISBN des livres

            try
            {
                string queryCategories = "SELECT * FROM books";
                DBConnector connexionCategories = new DBConnector();
                MySqlCommand cmd = new MySqlCommand(queryCategories, connexionCategories.Connection);

                connexionCategories.OpenConnection();

                MySqlDataReader reader = cmd.ExecuteReader();

                cb_isbn.Items.Clear();

                while (reader.Read())
                {
                    String isbn = reader.GetString("isbn");
                    String titre = reader.GetString("titre");
                    String livre = isbn + " / " + titre;
                    cb_isbn.Items.Add(livre);
                }

                reader.Close();
                connexionCategories.CloseConnection();
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                MessageBox.Show("Une erreur s'est produite lors de la récupération des catégories : " + ex.Message);
            }
        }

        private void l_lecteur(object sender, EventArgs e)
        {

        }

        private void cb_lecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = null;
            MySqlDataReader readerLecteur = null;

            try
            {
                // Récupérer le nom complet sélectionné dans le comboBox
                string nomComplet = cb_lecteur.SelectedItem.ToString();

                // Diviser le nom complet en nom et prénom
                string[] nomPrenom = nomComplet.Split(' ');
                string ids = nomPrenom[0];
                string nom = nomPrenom[1];
                string prenom = nomPrenom[2];
                
                int id = Convert.ToInt32(ids);
                    // Requête pour récupérer les 
          
                string queryLecteur = "SELECT * FROM readers WHERE id = @id";
                
                // Créer la connexion à la base de données
                connection = new MySqlConnection("connectionString");
                
                // Créer la commande SQL
                MySqlCommand cmdLecteur = new MySqlCommand(queryLecteur, connection);
                cmdLecteur.Parameters.AddWithValue("@id", id);

               
                // Ouvrir la connexion à la base de données
                connection.Open();

                // Exécuter la commande SQL
                readerLecteur = cmdLecteur.ExecuteReader();

                // Remplir les textBox avec les informations récupérées
                if (readerLecteur.Read())
                {
                   
                   
                    t_email.Text = readerLecteur.GetString("email");
                    t_telephone.Text = readerLecteur.GetString("telephone");
            

                    byte[] imageData = (byte[])readerLecteur["image"];

                   
                    MemoryStream ms = new MemoryStream(imageData);
                    p_image_lecteur.Image = Image.FromStream(ms);

                    // Libérer les ressources après avoir utilisé MemoryStream
                    ms.Close();
                    ms.Dispose();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la récupération des informations du lecteur : " + ex.Message);
            }
            finally
            {
                // Fermer le reader et la connexion à la base de données dans le bloc finally pour s'assurer qu'ils sont toujours fermés
                if (readerLecteur != null)
                    readerLecteur.Close();

                if (connection != null)
                    connection.Close();
            }
        }
    }
}
