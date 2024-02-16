namespace Bibliothèque1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Emprunter = new System.Windows.Forms.Button();
            this.Emprunts = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Emprunter
            // 
            this.Emprunter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Emprunter.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emprunter.Location = new System.Drawing.Point(35, 12);
            this.Emprunter.Name = "Emprunter";
            this.Emprunter.Size = new System.Drawing.Size(262, 42);
            this.Emprunter.TabIndex = 0;
            this.Emprunter.Text = "Emprunter";
            this.Emprunter.UseVisualStyleBackColor = false;
            this.Emprunter.Click += new System.EventHandler(this.Emprunter_Click);
            // 
            // Emprunts
            // 
            this.Emprunts.BackColor = System.Drawing.Color.Red;
            this.Emprunts.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emprunts.Location = new System.Drawing.Point(35, 73);
            this.Emprunts.Name = "Emprunts";
            this.Emprunts.Size = new System.Drawing.Size(262, 37);
            this.Emprunts.TabIndex = 1;
            this.Emprunts.Text = "Emprunts";
            this.Emprunts.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(35, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(262, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "Historique";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(356, 231);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Emprunts);
            this.Controls.Add(this.Emprunter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Emprunter;
        private System.Windows.Forms.Button Emprunts;
        private System.Windows.Forms.Button button3;
    }
}

