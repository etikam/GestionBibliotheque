using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibliotheque
{
    public partial class F_add_reader : Form
    {
        public F_add_reader()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            this.Hide();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichier images (*.png, *.PNG)|*.png;*.PNG";

            if (openFileDialog.ShowDialog()== DialogResult.OK)
            {
                tb_image.ImageLocation = openFileDialog.FileName;
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            bool erreur = false;
            String message_erreur = "";
            if (tb_nom.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n Aucun nom saisi";
            }

            if (tb_prenoms.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n Aucun prenom saisi";
            }

            if (tb_addresse.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n Aucune adresse saisie";
            }

            if (tb_email.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n Aucun Email saisi";
            }

            if (tb_telephone.Text.Length == 0)
            {
                erreur = true;
                message_erreur += "\n Aucun numero de téléphone saisi";
            }

            if (tb_image.Image == null) // Vérifiez si une image est sélectionnée
            {
                erreur = true;
                message_erreur += "\n Aucune image choisie";
            }

            if (erreur)
            {
                MessageBox.Show(message_erreur);
            }
            else
            {
                try
                {
                    byte[] imageBytes = ImageToByteArray(tb_image.Image);

                    DBConnector connexion = new DBConnector();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion.Connection;

                    if (string.IsNullOrEmpty(id_masque.Text))
                    {
                        // Insertion d'une nouvelle personne
                        String requete = "INSERT INTO readers(nom,prenom,addresse,email,telephone,photo) VALUES(@nom, @prenom, @addresse, @email, @telephone, @photo)";
                        cmd.CommandText = requete;
                    }
                    else
                    {
                        // Mise à jour d'une personne existante
                        String requete = "UPDATE readers SET nom = @nom, prenom = @prenom, addresse = @addresse, email = @email, telephone = @telephone, photo = @photo WHERE id = @id";
                        cmd.CommandText = requete;
                        cmd.Parameters.AddWithValue("@id", id_masque.Text);
                    }

                    cmd.Parameters.AddWithValue("@nom", tb_nom.Text);
                    cmd.Parameters.AddWithValue("@prenom", tb_prenoms.Text);
                    cmd.Parameters.AddWithValue("@addresse", tb_addresse.Text);
                    cmd.Parameters.AddWithValue("@email", tb_email.Text);
                    cmd.Parameters.AddWithValue("@telephone", tb_telephone.Text);
                    cmd.Parameters.AddWithValue("@photo", imageBytes);

                    connexion.OpenConnection();
                    cmd.ExecuteNonQuery();
                    connexion.CloseConnection();

                    tb_nom.Text = "";
                    tb_prenoms.Text = "";
                    tb_addresse.Text = "";
                    tb_email.Text = "";
                    tb_telephone.Text = "";
                    tb_image.Image = null;
                    id_masque.Text = "";

                    String query = "SELECT id, nom, prenom, addresse, email, telephone FROM readers";
                    connexion.Select(query, dataGridView1);
                   
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

        private void F_add_reader_Load(object sender, EventArgs e)
        {
            String requete = "SELECT id,nom,prenom,addresse,email,telephone FROM readers;";
            DBConnector connexion = new DBConnector();
            connexion.Select(requete, dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "id")
            {
                try
                {
                    int identifiant = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                    DBConnector con = new DBConnector();

                    // Ouvrir manuellement la connexion à la base de données
                    if (con.OpenConnection())
                    {
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.CommandText = "SELECT id, nom, prenom, adresse, telephone, photo FROM readers WHERE id = @identifiant";
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
                            tb_id_d.Text = row["id"].ToString();
                            Console.WriteLine("l'id: " + row["id"].ToString());
                            tb_nom_d.Text = row["nom"].ToString();
                            tb_prenom_d.Text = row["prenom"].ToString();
                            tb_addresse_d.Text = row["adresse"].ToString();
                            tb_telephone_d.Text = row["telephone"].ToString();

                            // Afficher l'image
                            byte[] imageBytes = (byte[])row["photo"];
                            MemoryStream ms = new MemoryStream(imageBytes);
                            pictureBox2.Image = new Bitmap(ms);
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "id")
            {
                try
                {
                    int identifiant = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                    DBConnector con = new DBConnector();

                    // Ouvrir manuellement la connexion à la base de données
                    if (con.OpenConnection())
                    {
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.CommandText = "SELECT id, nom, prenom, adresse, telephone, photo FROM readers WHERE id = @identifiant";
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
                            tb_id_d.Text = row["id"].ToString();
                            Console.WriteLine("l'id: " + row["id"].ToString());
                            tb_nom_d.Text = row["nom"].ToString();
                            tb_prenom_d.Text = row["prenom"].ToString();
                            tb_addresse_d.Text = row["adresse"].ToString();
                            tb_telephone_d.Text = row["telephone"].ToString();

                            // Afficher l'image
                            byte[] imageBytes = (byte[])row["photo"];
                            MemoryStream ms = new MemoryStream(imageBytes);
                            pictureBox2.Image = new Bitmap(ms);
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            tb_id_d.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tb_nom_d.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_prenom_d.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tb_addresse_d.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tb_email_d.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tb_telephone_d.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            // Récupérer l'identifiant de l'élément sélectionné
            int identifiant = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


                DBConnector con = new DBConnector();

                // Ouvrir manuellement la connexion à la base de données
                if (con.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT photo FROM readers WHERE id = @identifiant";
                    cmd.Parameters.AddWithValue("@identifiant", identifiant);
                    cmd.Connection = con.Connection;

                    // Exécuter la commande et récupérer les données de l'image
                    byte[] imageData = (byte[])cmd.ExecuteScalar();

                // Afficher l'image dans le PictureBox
                // Afficher l'image dans le PictureBox
                if (imageData != null && imageData.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox2.Image = Image.FromStream(ms);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        // Afficher un message d'erreur si les données de l'image sont invalides
                        MessageBox.Show("Les données de l'image sont invalides : " + ex.Message);
                    }
                }
                else
                {
                    pictureBox2.Image = null; // Effacer l'image si aucune n'est trouvée
                }


                // Fermer manuellement la connexion à la base de données
                con.CloseConnection();
                }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
            
           



        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    string nom = dataGridView1.SelectedRows[0].Cells["nom"].Value.ToString();

                    if (MessageBox.Show("Voulez-vous vraiment supprimer le lecteur " + nom + " ?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DBConnector connexion = new DBConnector();
                        string requete = "DELETE FROM readers WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(requete, connexion.Connection);
                        cmd.Parameters.AddWithValue("@id", id);

                        connexion.OpenConnection();
                        cmd.ExecuteNonQuery();
                        connexion.CloseConnection();

                        string query = "SELECT id,nom,prenom,addresse,email,telephone FROM readers;";
                        connexion.Select(query, dataGridView1);

                        MessageBox.Show("Le lecteur " + nom + " a été supprimé avec succès.");

                        tb_id_d.Text = "";
                        tb_nom_d.Text = "";
                        tb_prenom_d.Text = "";
                        tb_addresse_d.Text = "";
                        tb_telephone_d.Text = "";
                        tb_email_d.Text = "";
                        pictureBox2.Image = null;
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer les données de la ligne sélectionnée
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string nom = selectedRow.Cells["nom"].Value.ToString();
                string prenom = selectedRow.Cells["prenom"].Value.ToString();
                string adresse = selectedRow.Cells["addresse"].Value.ToString();
                string email = selectedRow.Cells["email"].Value.ToString();
                string telephone = selectedRow.Cells["telephone"].Value.ToString();

                // Remplir les champs du formulaire avec les données récupérées
                id_masque.Text = id.ToString();
                tb_nom.Text = nom;
                tb_prenoms.Text = prenom;
                tb_addresse.Text = adresse;
                tb_email.Text = email;
                tb_telephone.Text = telephone;
                tb_image.Image = pictureBox2.Image;
                // Vous pouvez également afficher l'image associée si nécessaire
                // Assurez-vous de récupérer les données de l'image et de les afficher dans le PictureBox approprié

                // Mettre à jour le texte du bouton "Enregistrer" pour indiquer qu'il s'agit d'une modification
            

                // Optionnel : désactiver d'autres fonctionnalités pendant la modification si nécessaire
                // Par exemple, vous pouvez désactiver la possibilité de sélectionner d'autres lignes dans le DataGridView
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un lecteur à modifier.");
            }

            
        }

        private void tb_nom_TextChanged(object sender, EventArgs e)
        {

        }

      /*  private void btn_search_Click(object sender, EventArgs e)
        {
            string searchTerm = tb_search.Text.Trim(); // Récupérer le terme de recherche
            string requete = "SELECT id, nom, prenom, adresse, email, telephone FROM readers;";
            DBConnector connexion = new DBConnector();
            DataTable dataTable = connexion.Select(requete);

            // Vérifier si le terme de recherche est vide
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Si le terme de recherche est vide, afficher toutes les données
                dataGridView1.DataSource = dataTable; // Utilisez votre DataTable existante ici
            }
            else
            {
                // Filtrer les données selon le terme de recherche
                DataTable filteredDataTable = FilterDataTable(dataTable, searchTerm);
                dataGridView1.DataSource = filteredDataTable;
            }
        } */

        // Méthode pour filtrer le DataTable en fonction du terme de recherche
        private DataTable FilterDataTable(DataTable dataTable, string searchTerm)
        {
            DataTable filteredDataTable = new DataTable();
            foreach (DataColumn column in dataTable.Columns)
            {
                filteredDataTable.Columns.Add(column.ColumnName, column.DataType);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                bool found = false;
                foreach (object item in row.ItemArray)
                {
                    if (item.ToString().IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    filteredDataTable.ImportRow(row);
                }
            }

            return filteredDataTable;
        }

        private void tb_image_Click(object sender, EventArgs e)
        {

        }
    }
}
