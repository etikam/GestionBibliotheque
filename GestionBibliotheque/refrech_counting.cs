using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// cette classe s'occupe uniquement du comptage des elements dans les tables pour les mettres dans les labels de compte sur la page d'accueil
namespace GestionBibliotheque
{
    internal class refrech_counting
    {
        public refrech_counting(Form1 form) {

           // MessageBox.Show("Je demarre le refrech");
            remplissage_nombre(form);
           // MessageBox.Show("Je termine le refrech");
        }
    
    
            private void remplissage_nombre(Form1 form)
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
                form.l_nombre_lecteur.Text = nombreLecteurs.ToString();
                form.l_nombre_livres.Text = nombreLivres.ToString();
                form.l_nombre_emprunts.Text = nombreEmprunts.ToString();
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
            }
}
