using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibliotheque
{
    public partial class F_add_book : Form
    {
        public F_add_book()
        {
            InitializeComponent();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void F_add_book_Load(object sender, EventArgs e)
        {
            // Remplir la DataGridView avec les données de la table des livres
            String requeteBooks = "SELECT id, titre, auteur, category, date_publication, isbn, quantite FROM books;";
            DBConnector connexionBooks = new DBConnector();
            connexionBooks.Select(requeteBooks, dataGridView2);

            // Remplir la ComboBox avec les catégories
            try
            {
               
                string queryCategories = "SELECT nom FROM categories";

                DBConnector connexionCategories = new DBConnector();
                MySqlCommand cmd = new MySqlCommand(queryCategories, connexionCategories.Connection);

                connexionCategories.OpenConnection();

       
                MySqlDataReader reader = cmd.ExecuteReader();

            
                t_category.Items.Clear();

       
                while (reader.Read())
                {     
                    t_category.Items.Add(reader.GetString("nom"));
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.Hide();

        }

        private void t_enregistrer_Click(object sender, EventArgs e)
        {
            bool erreur = false;
            String message_erreur = "";
            if (t_titre.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n Veuillez entrer un titre pour le livre";
            }

            if (t_auteur.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n Veuillez entrer un auteur pour le livre";
            }

            if (t_category.SelectedIndex == -1)
            {
                erreur = true;
                message_erreur += "\n Veuillez choisir une catégorie pour le livre";
            }
            else
            {
                // Récupérer la valeur sélectionnée dans la ComboBox
                string category = t_category.SelectedItem.ToString();
            }

            if (t_date.Value == null)
            {
                erreur = true;
                message_erreur += "\n Veuillez choisir une date pour le livre";
            }

            if (t_isbn.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n L'ISBN ne doit pas être vide";
            }

            if (t_quantite.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n Aucune quantité saisie ";
            }
            else
            {
                // Vérifier si la quantité est un nombre
                int quantite;
                if (!int.TryParse(t_quantite.Text, out quantite))
                {
                    erreur = true;
                    message_erreur += "\n La quantité doit être un nombre";
                }
            }

            if (p_couverture.Image == null) // Vérifiez si une image est sélectionnée
            {
                erreur = true;
                message_erreur += "\n Aucune image de couverture choisie";
            }

            if (erreur)
            {
                MessageBox.Show(message_erreur);
            }
            else
            {
                try
                {
                    byte[] imageBytes = ImageToByteArray(p_couverture.Image);

                    DBConnector connexion = new DBConnector();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion.Connection;

                    if (string.IsNullOrEmpty(id_masque.Text))
                    {
                        // Insertion d'une nouvelle personne
                        String requete = "INSERT INTO books(titre,auteur,category,date_publication,isbn, quantite,couverture) VALUES(@titre, @auteur, @category, @date_publication, @isbn, @quantite, @couverture)";
                        cmd.CommandText = requete;
                    }
                    else
                    {
                        // Mise à jour d'une personne existante
                        String requete = "UPDATE books SET titre = @titre, auteur = @auteur, category = @category, date_publication = @date_publication, isbn = @isbn, quantite = @quantite, couverture = @couverture WHERE id = @id";
                        cmd.CommandText = requete;
                        cmd.Parameters.AddWithValue("@id", id_masque.Text);
                    }

                    cmd.Parameters.AddWithValue("@titre", t_titre.Text);
                    cmd.Parameters.AddWithValue("@auteur", t_auteur.Text);
                    cmd.Parameters.AddWithValue("@category", t_category.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@date_publication", t_date.Value);
                    cmd.Parameters.AddWithValue("@isbn", t_isbn.Text);
                    cmd.Parameters.AddWithValue("@quantite", t_quantite.Text);
                    cmd.Parameters.AddWithValue("@couverture", imageBytes);

                    connexion.OpenConnection();
                    cmd.ExecuteNonQuery();
                    connexion.CloseConnection();

                    t_titre.Text = "";
                    t_auteur.Text = "";
                    t_category.SelectedIndex = -1; // Réinitialiser la sélection de la ComboBox
                    t_date.Value = DateTime.Now; // Réinitialiser la date au jour actuel
                    t_isbn.Text = "";
                    p_couverture.Image = null;
                    t_quantite.Text = "";

                    String query = "SELECT id, titre, auteur, category, date_publication, isbn, quantite FROM books";
                    connexion.Select(query, dataGridView2);

                    MessageBox.Show("Modification Effectuée.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite lors de l'opération : " + ex.Message);
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichier images (*.png, *.PNG)|*.png;*.PNG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                p_couverture.ImageLocation = openFileDialog.FileName;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

                    if (e.RowIndex >= 0 )
                    {
                        try
                        {
                            int identifiant = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id"].Value);
                            DBConnector con = new DBConnector();

                            // Ouvrir manuellement la connexion à la base de données
                            if (con.OpenConnection())
                            {
                                MySqlCommand cmd = new MySqlCommand();
                                cmd.CommandText = "SELECT id, titre, auteur, category, date_publication, isbn, quantite, couverture FROM books WHERE id = @identifiant";
                                cmd.Parameters.AddWithValue("@identifiant", identifiant);
                                cmd.Connection = con.Connection;

                                MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                                DataSet DS = new DataSet();
                                DA.Fill(DS);

                                if (DS.Tables[0].Rows.Count == 0)
                                {
                                    MessageBox.Show("Aucune information ne correspond à cet lecteur");
                                }
                                else
                                {
                                    // Récupérer les données de l'utilisateur
                                    DataRow row = DS.Tables[0].Rows[0];
                                    t_id_d.Text = row["id"].ToString();
                                    t_titre_d.Text = row["titre"].ToString();
                                    t_auteur_d.Text = row["auteur"].ToString();
                                    t_category_d.Text = row["category"].ToString();
                                    t_date_d.Text = row["date_publication"].ToString();
                                    t_isbn_d.Text = row["isbn"].ToString();
                                    t_quantite_d.Text = row["quantite"].ToString();


                                    // Afficher l'image
                                    byte[] imageBytes = (byte[])row["couverture"];
                                    MemoryStream ms = new MemoryStream(imageBytes);
                                    p_couverture_d.Image = new Bitmap(ms);
                                }

                                // Fermer manuellement la connexion à la base de données
                                con.CloseConnection();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                        }

                    }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Récupérer les données de la ligne sélectionnée
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                    int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    string titre = selectedRow.Cells["titre"].Value.ToString();
                    string auteur = selectedRow.Cells["auteur"].Value.ToString();
                    string category = selectedRow.Cells["category"].Value.ToString();
                    string date_publication = selectedRow.Cells["date_publication"].Value.ToString();
                    string isbn = selectedRow.Cells["isbn"].Value.ToString();
                    string quantite = selectedRow.Cells["quantite"].Value.ToString();

                    // Remplir les champs du formulaire avec les données récupérées
                    id_masque.Text = id.ToString();
                    t_titre.Text = titre;
                    t_auteur.Text = auteur;
                    t_category.Text = category;
                    t_date.Text = date_publication;
                    t_quantite.Text = quantite;
                    t_isbn.Text = isbn;
                    p_couverture.Image = p_couverture_d.Image;
                   
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un lecteur à modifier.");
                }


            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);
                    string titre = dataGridView2.SelectedRows[0].Cells["titre"].Value.ToString();

                    if (MessageBox.Show("Voulez-vous vraiment supprimer le livre:  " + titre + " ?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DBConnector connexion = new DBConnector();
                        string requete = "DELETE FROM books WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(requete, connexion.Connection);
                        cmd.Parameters.AddWithValue("@id", id);

                        connexion.OpenConnection();
                        cmd.ExecuteNonQuery();
                        connexion.CloseConnection();

                        string query = "SELECT id,titre,auteur,category,date_publication,isbn, quantite FROM books;";
                        connexion.Select(query, dataGridView2);

                        MessageBox.Show("Le Livre " + titre + " a été supprimé avec succès.");

                        t_titre.Text = "";
                        t_auteur.Text = "";
                        t_category.Text = "";
                        t_date.Text = "";
                        t_isbn.Text = "";
                        t_quantite.Text = "";
                        p_couverture.Image = null;
                        id_masque.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite lors de la suppression du lecteur : " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un lecteur à supprimer.");
            }
        }
    }
}
