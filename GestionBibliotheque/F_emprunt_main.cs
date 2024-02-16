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
    public partial class F_emprunt_main : Form
    {
        public F_emprunt_main()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            F_emprunt_emprunter f = new F_emprunt_emprunter();
            f.Show();
            this.Hide();
        }
    }
}
