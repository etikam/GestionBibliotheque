namespace GestionBibliotheque
{
    partial class F_Connexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Connexion));
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lb_authentification = new System.Windows.Forms.Label();
            this.lb_login = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.tb_login = new Guna.UI2.WinForms.Guna2TextBox();
            this.tb_password = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_connexion = new Guna.UI2.WinForms.Guna2Button();
            this.lb_reinitialiser = new System.Windows.Forms.LinkLabel();
            this.lb_auth_error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Black;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-15, -1);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(387, 297);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lb_authentification
            // 
            this.lb_authentification.AutoSize = true;
            this.lb_authentification.Font = new System.Drawing.Font("Unispace", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_authentification.ForeColor = System.Drawing.Color.Blue;
            this.lb_authentification.Location = new System.Drawing.Point(380, 3);
            this.lb_authentification.Name = "lb_authentification";
            this.lb_authentification.Size = new System.Drawing.Size(337, 40);
            this.lb_authentification.TabIndex = 1;
            this.lb_authentification.Text = "Authentification";
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.Font = new System.Drawing.Font("Mongolian Baiti", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_login.Location = new System.Drawing.Point(393, 70);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(76, 21);
            this.lb_login.TabIndex = 2;
            this.lb_login.Text = "Login :";
            this.lb_login.Click += new System.EventHandler(this.label2_Click);
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Font = new System.Drawing.Font("Mongolian Baiti", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password.Location = new System.Drawing.Point(393, 119);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(108, 21);
            this.lb_password.TabIndex = 3;
            this.lb_password.Text = "Password :";
            this.lb_password.Click += new System.EventHandler(this.label3_Click);
            // 
            // tb_login
            // 
            this.tb_login.BorderColor = System.Drawing.Color.Blue;
            this.tb_login.BorderRadius = 10;
            this.tb_login.BorderThickness = 2;
            this.tb_login.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_login.DefaultText = "";
            this.tb_login.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_login.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_login.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_login.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tb_login.ForeColor = System.Drawing.Color.Black;
            this.tb_login.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_login.Location = new System.Drawing.Point(498, 55);
            this.tb_login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_login.Name = "tb_login";
            this.tb_login.PasswordChar = '\0';
            this.tb_login.PlaceholderText = "";
            this.tb_login.SelectedText = "";
            this.tb_login.Size = new System.Drawing.Size(234, 38);
            this.tb_login.TabIndex = 4;
            // 
            // tb_password
            // 
            this.tb_password.BorderColor = System.Drawing.Color.Blue;
            this.tb_password.BorderRadius = 10;
            this.tb_password.BorderThickness = 2;
            this.tb_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_password.DefaultText = "";
            this.tb_password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_password.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tb_password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_password.Location = new System.Drawing.Point(498, 104);
            this.tb_password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.PlaceholderText = "";
            this.tb_password.SelectedText = "";
            this.tb_password.Size = new System.Drawing.Size(234, 38);
            this.tb_password.TabIndex = 5;
            // 
            // btn_connexion
            // 
            this.btn_connexion.BorderRadius = 20;
            this.btn_connexion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_connexion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_connexion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_connexion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_connexion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.btn_connexion.ForeColor = System.Drawing.Color.White;
            this.btn_connexion.Location = new System.Drawing.Point(533, 149);
            this.btn_connexion.Name = "btn_connexion";
            this.btn_connexion.Size = new System.Drawing.Size(157, 45);
            this.btn_connexion.TabIndex = 6;
            this.btn_connexion.Text = "Connexion";
            this.btn_connexion.Click += new System.EventHandler(this.btn_connexion_Click);
            // 
            // lb_reinitialiser
            // 
            this.lb_reinitialiser.AutoSize = true;
            this.lb_reinitialiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_reinitialiser.Location = new System.Drawing.Point(569, 213);
            this.lb_reinitialiser.Name = "lb_reinitialiser";
            this.lb_reinitialiser.Size = new System.Drawing.Size(90, 20);
            this.lb_reinitialiser.TabIndex = 7;
            this.lb_reinitialiser.TabStop = true;
            this.lb_reinitialiser.Text = "Réinitialiser";
            // 
            // lb_auth_error
            // 
            this.lb_auth_error.AutoSize = true;
            this.lb_auth_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_auth_error.ForeColor = System.Drawing.Color.Red;
            this.lb_auth_error.Location = new System.Drawing.Point(397, 255);
            this.lb_auth_error.Name = "lb_auth_error";
            this.lb_auth_error.Size = new System.Drawing.Size(335, 17);
            this.lb_auth_error.TabIndex = 8;
            this.lb_auth_error.Text = "Login ou mot de passe incorrect, Veuillez reprendre";
            this.lb_auth_error.Visible = false;
            this.lb_auth_error.Click += new System.EventHandler(this.lb_auth_error_Click);
            // 
            // F_Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 287);
            this.Controls.Add(this.lb_auth_error);
            this.Controls.Add(this.lb_reinitialiser);
            this.Controls.Add(this.btn_connexion);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_login);
            this.Controls.Add(this.lb_authentification);
            this.Controls.Add(this.guna2PictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Connexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Connexion_FormClosing);
            this.Load += new System.EventHandler(this.F_Connexion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lb_authentification;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.Label lb_password;
        private Guna.UI2.WinForms.Guna2TextBox tb_login;
        private Guna.UI2.WinForms.Guna2TextBox tb_password;
        private Guna.UI2.WinForms.Guna2Button btn_connexion;
        private System.Windows.Forms.LinkLabel lb_reinitialiser;
        private System.Windows.Forms.Label lb_auth_error;
    }
}