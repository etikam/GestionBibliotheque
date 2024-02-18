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
            openFileDialog.Filter = "Fichier images (*.jpg, *.jpeg, *.png)| *.jpg;*.jpeg;*.png";
            if(openFileDialog.ShowDialog()== DialogResult.OK)
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

            if (tb_image == null)
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
                byte[] imageBytes = ImageToByteArray(tb_image.Image);
                string imageBase64 = Convert.ToBase64String(imageBytes); // Convertir l'image en base64

                DBConnector connexion = new DBConnector();
                String requete = "INSERT INTO readers(id,nom,prenom,addresse,email,telephone,photo)" +
                                  "VALUES(NULL,'" + tb_nom.Text + "','" + tb_prenoms.Text + "','" + tb_addresse.Text + "','" + tb_email.Text + "','" + tb_telephone.Text + "','" + imageBase64 + "')";
                connexion.Insert(requete);
                tb_nom.Text = "";
                tb_prenoms.Text = "";
                tb_addresse.Text = "";
                tb_email.Text = "";
                tb_telephone.Text = "";
                String query = "SELECT id,nom,prenom,addresse,email,telephone FROM readers;";

                connexion.Select(query, dataGridView1);
                MessageBox.Show("Le Lecteur est ajouté avec Succès");
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
                        cmd.CommandText = "SELECT photo FROM readers WHERE id = @identifiant";
                        cmd.Parameters.AddWithValue("@identifiant", identifiant);
                        cmd.Connection = con.Connection;

                        MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                        DataSet DS = new DataSet();
                        DA.Fill(DS);

                        if (DS.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Aucune image ne correspond à cet lecteur");
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream((byte[])DS.Tables[0].Rows[0]["photo"]);
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
    }
}
