using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibliotheque
{
    public partial class F_Connexion : Form
    {
        public F_Connexion()
        {
            InitializeComponent();
        }

        private void F_Connexion_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            String login = tb_login.Text;
            String password = tb_password.Text;
           
            //Vérification de la connexion

            try
            {
           
                DBConnector connector = new DBConnector();

                if (connector.OpenConnection())
                {

                    
                    string query = "SELECT COUNT(*) FROM User WHERE BINARY username = @login AND BINARY password = @password";


                    MySqlCommand command = new MySqlCommand(query, connector.Connection);
                    
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    
                
                    if (count > 0)
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                       
                        this.Hide();

                       
                    }
                    else
                    {
                
                        lb_auth_error.Visible = true;
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

        private void lb_auth_error_Click(object sender, EventArgs e)
        {
            lb_auth_error.Visible = false;
        }

        private void F_Connexion_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void lb_reinitialiser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            user_recover recover = new user_recover();
            this.Hide();
            recover.Show();
        }
    }
    }

