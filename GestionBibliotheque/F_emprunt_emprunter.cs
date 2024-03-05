using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibliotheque
{
    public partial class F_emprunt_emprunter : Form
    {
        public Bitmap Image { get; private set; }

        public F_emprunt_emprunter()
        {
            InitializeComponent();
            chargement_du_dataview();
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
                    String nom_complet = id + " " + nom + " " + prenom;
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


            // Remplissage du comboBox des ISBN des livres

            try
            {
                string QueryCategories = "SELECT * FROM books";
                DBConnector connexionCategories = new DBConnector();
                MySqlCommand cmd = new MySqlCommand(QueryCategories, connexionCategories.Connection);

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
            DBConnector con = null;
            MySqlDataReader lecteure = null;
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


                con = new DBConnector();
                string query = "SELECT * FROM readers WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, con.Connection);
                con.OpenConnection();

                cmd.Parameters.AddWithValue("@id", id);
                lecteure = cmd.ExecuteReader();
                // Ouvrir la connexion à la base de données


                // Remplir les textBox avec les informations récupérées
                if (lecteure.Read())
                {
                    t_email.Text = lecteure.GetString("email");
                    t_telephone.Text = lecteure.GetString("telephone");

                    byte[] imageBytes = (byte[])lecteure["photo"];
                    MemoryStream ms = new MemoryStream(imageBytes);
                    p_image_lecteur.Image = new Bitmap(ms);

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
                if (lecteure != null)
                    lecteure.Close();

                if (con != null)
                    con.CloseConnection();
            }
        }

        private int get_set_quatity(String isbn = null)
        {
            int quantity = -1;

            DBConnector con = null;
            MySqlDataReader lecteure = null;
            try
            {
                // Récupérer le nom complet sélectionné dans le comboBox
                string nomComplet = cb_isbn.SelectedItem.ToString();

                // Diviser l'isbn en isbn et livre
                string[] isbns = nomComplet.Split(' ');
                isbn = isbns[0];

                con = new DBConnector();
                string query = "SELECT * FROM books WHERE isbn = @isbn";

                MySqlCommand cmd = new MySqlCommand(query, con.Connection);
                con.OpenConnection();

                cmd.Parameters.AddWithValue("@isbn", isbn);
                lecteure = cmd.ExecuteReader();

                if (lecteure.Read())
                {

                    quantity = lecteure.GetInt16("quantite");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la récupération de la quantité du livre : " + ex.Message);
            }
            finally
            {
                // Fermer le reader et la connexion à la base de données dans le bloc finally pour s'assurer qu'ils sont toujours fermés
                if (lecteure != null)
                    lecteure.Close();

                if (con != null)
                    con.CloseConnection();
            }

            return quantity;
        }

        private void set_quantity(int quantity, String isbn)
        {

            quantity = quantity - 1;
            DBConnector con = null;
            MySqlDataReader lecteure = null;
            try
            {


                con = new DBConnector();
                string query = "UPDATE books  set quantite=@qt WHERE isbn = @isbn";

                MySqlCommand cmd = new MySqlCommand(query, con.Connection);
                con.OpenConnection();

                cmd.Parameters.AddWithValue("@qt", quantity);
                cmd.Parameters.AddWithValue("@isbn", isbn);
                int row = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la récupération de la quantité du livre : " + ex.Message);
            }
            finally
            {
                // Fermer le reader et la connexion à la base de données dans le bloc finally pour s'assurer qu'ils sont toujours fermés
                if (lecteure != null)
                    lecteure.Close();

                if (con != null)
                    con.CloseConnection();
            }
        }

        private void cb_isbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            int quantity = -1;

            DBConnector con = null;
            MySqlDataReader lecteure = null;
            try
            {
                // Récupérer le nom complet sélectionné dans le comboBox
                string nomComplet = cb_isbn.SelectedItem.ToString();

                // Diviser l'isbn en isbn et livre
                string[] isbns = nomComplet.Split(' ');
                string isbn = isbns[0];

                con = new DBConnector();
                string query = "SELECT * FROM books WHERE isbn = @isbn";

                MySqlCommand cmd = new MySqlCommand(query, con.Connection);
                con.OpenConnection();

                cmd.Parameters.AddWithValue("@isbn", isbn);
                lecteure = cmd.ExecuteReader();

                if (lecteure.Read())
                {
                    t_titre.Text = lecteure.GetString("titre");
                    quantity = lecteure.GetInt16("quantite");

                    byte[] imageBytes = (byte[])lecteure["couverture"];
                    MemoryStream ms = new MemoryStream(imageBytes);
                    p_image_livre.Image = new Bitmap(ms);

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
                if (lecteure != null)
                    lecteure.Close();

                if (con != null)
                    con.CloseConnection();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            {
                bool erreur = false;
                String message_erreur = "";
                if (cb_lecteur.SelectedItem == null)
                {
                    erreur = true;
                    message_erreur += "\n Aucun lecteur selectionné";
                }

                if (cb_isbn.SelectedItem == null)
                {
                    erreur = true;
                    message_erreur += "\n Aucun Livre selectionné";
                }

                if (erreur)
                {
                    MessageBox.Show(message_erreur);
                }
                else
                {
                    try
                    {
                        byte[] imageBytes_lecteur = ImageToByteArray(p_image_lecteur.Image);
                        byte[] imageBytes_livre = ImageToByteArray(p_image_livre.Image);

                        DBConnector connexion = new DBConnector();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connexion.Connection;

                        string[] mon_isbn = cb_isbn.Text.Split(' ');
                        String isbn = mon_isbn[0];
                        MessageBox.Show("jai capturé isbn: " + isbn);

                        if (quantite(isbn) == 0)
                        {
                            MessageBox.Show("Ce livre n'est pas disponible en empunt");
                        }
                        else
                        {



                            // Insertion d'une nouvelle personne
                            String requete = "INSERT INTO borrowed(id_lecteur,id_livre,date_emprunt,date_retour)" +
                                " VALUES(@id_lecteur, @id_livre, @date_emprunt, @date_retour)";
                            cmd.CommandText = requete;

                            cmd.Parameters.AddWithValue("@id_lecteur", cb_lecteur.Text);
                            cmd.Parameters.AddWithValue("@id_livre", cb_isbn.Text);
                            cmd.Parameters.AddWithValue("@date_emprunt", t_date_deb.Value);
                            cmd.Parameters.AddWithValue("@date_retour", t_date_fin.Value);

                            connexion.OpenConnection();
                            cmd.ExecuteNonQuery();
                            connexion.CloseConnection();


                            chargement_du_dataview();

                            //    id_masque.Text = "";

                            update_quantite(isbn, false);
                            MessageBox.Show("Modification Effectuée.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur s'est produite lors de l'opération : " + ex.Message);
                    }
                }
            }

        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                image.Save(ms, ImageFormat.Png); // Vous pouvez choisir le format approprié
                return ms.ToArray();
            }
        }






        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void chargement_du_dataview()
        {

            DBConnector connexion = new DBConnector();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connexion.Connection;

            String query = "SELECT id_lecteur, id_livre,date_emprunt,date_retour FROM borrowed";
            connexion.Select(query, guna2DataGridView1);
        }



        public int quantite(String isbn)
        {
            int qt = 0;

            try
            {
                // Création de la connexion à la base de données
                DBConnector connexion = new DBConnector();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connexion.Connection;

                // Définition de la requête SQL avec un paramètre
                string query = "SELECT quantite FROM books WHERE isbn = @isbn";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@isbn", isbn);

                // Ouverture de la connexion à la base de données
                connexion.OpenConnection();

                // Exécution de la commande SQL et récupération du résultat
                object result = cmd.ExecuteScalar();

                // Vérification si le résultat n'est pas null
                if (result != null)
                {
                    // Conversion du résultat en entier
                    qt = Convert.ToInt32(result);
                }

                // Fermeture de la connexion à la base de données
                connexion.CloseConnection();
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                MessageBox.Show("Une erreur s'est produite lors de la récupération de la quantité du livre : " + ex.Message);
            }

            // Retour de la quantité récupérée
            return qt;
        }

        public void update_quantite(String isbn, bool increment)
        {
            int qt = quantite(isbn);

            if (increment == true)
            {
                qt = qt + 1;
            }
            else
            {
                qt = qt - 1;
            }

            try
            {
                // Création de la connexion à la base de données
                DBConnector connexion = new DBConnector();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connexion.Connection;

                // Définition de la requête SQL avec des paramètres
                String query = "UPDATE books SET quantite = @quantite WHERE isbn = @isbn";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@quantite", qt);
                cmd.Parameters.AddWithValue("@isbn", isbn);

                // Ouverture de la connexion à la base de données
                connexion.OpenConnection();

                // Exécution de la commande SQL
                int rowsAffected = cmd.ExecuteNonQuery();

                // Fermeture de la connexion à la base de données
                connexion.CloseConnection();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Quantité mise à jour avec succès.");
                }
                else
                {
                    MessageBox.Show("Aucune ligne n'a été mise à jour.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la mise à jour de la quantité : " + ex.Message);
            }
        }

    }
}
