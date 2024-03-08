using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibliotheque
{
    public partial class user_recover : Form
    {
        public user_recover()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_Connexion f = new F_Connexion();
            f.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            String email = txt_email.Text;
            String telephone = txt_telephone.Text;



            try
            {

                DBConnector connector = new DBConnector();

                if (connector.OpenConnection())
                {


                    string query = "SELECT COUNT(*) FROM user WHERE BINARY email = @email AND BINARY telephone = @telephone";


                    MySqlCommand command = new MySqlCommand(query, connector.Connection);

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@telephone", telephone);
                    int count = Convert.ToInt32(command.ExecuteScalar());


                    if (count > 0)
                    {
                        lb_password.Visible = true;
                        lb_repetter.Visible = true;
                        txt_password.Visible = true;
                        txt_repetter.Visible = true;
                        titre_password.Visible = true;
                        titre_password1.Visible = true;
                        btn_modifier.Visible = true;



                    }
                    else
                    {

                        lb_error.Visible = true;
                    }


                    connector.CloseConnection();
                }
                else
                {

                    MessageBox.Show("La connexion à la base de données a échoué.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            string password1 = txt_password.Text;
            string password2 = txt_repetter.Text;

            //Vérification de la connexion
            try
            {
                DBConnector connector = new DBConnector();

                if (connector.OpenConnection())
                {
                    if (password1 == password2)
                    {
                        string query = "UPDATE user SET password=@password WHERE email=@email AND telephone=@telephone";

                        MySqlCommand command = new MySqlCommand(query, connector.Connection);

                        command.Parameters.AddWithValue("@password", password1);
                        command.Parameters.AddWithValue("@email", txt_email.Text);
                        command.Parameters.AddWithValue("@telephone", txt_telephone.Text);
                        command.ExecuteNonQuery(); // Correction de la méthode d'exécution de la requête

                        lb_success.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Les mots de passe ne correspondent pas.");
                    }

                    connector.CloseConnection();
                }
                else
                {
                    MessageBox.Show("La connexion à la base de données a échoué.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

    }
}
