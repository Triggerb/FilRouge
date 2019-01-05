namespace FilRouge
{
    partial class FrmLauncher
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
            this.txtBoxHauteur = new System.Windows.Forms.TextBox();
            this.lblHauteur = new System.Windows.Forms.Label();
            this.lblLongueur = new System.Windows.Forms.Label();
            this.txtBoxLongueur = new System.Windows.Forms.TextBox();
            this.btnCommencer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxHauteur
            // 
            this.txtBoxHauteur.Location = new System.Drawing.Point(362, 225);
            this.txtBoxHauteur.Name = "txtBoxHauteur";
            this.txtBoxHauteur.Size = new System.Drawing.Size(99, 20);
            this.txtBoxHauteur.TabIndex = 0;
            this.txtBoxHauteur.Text = "8";
            // 
            // lblHauteur
            // 
            this.lblHauteur.AutoSize = true;
            this.lblHauteur.BackColor = System.Drawing.Color.Transparent;
            this.lblHauteur.Location = new System.Drawing.Point(305, 254);
            this.lblHauteur.Name = "lblHauteur";
            this.lblHauteur.Size = new System.Drawing.Size(45, 13);
            this.lblHauteur.TabIndex = 1;
            this.lblHauteur.Text = "Hauteur";
            // 
            // lblLongueur
            // 
            this.lblLongueur.AutoSize = true;
            this.lblLongueur.BackColor = System.Drawing.Color.Transparent;
            this.lblLongueur.Location = new System.Drawing.Point(298, 228);
            this.lblLongueur.Name = "lblLongueur";
            this.lblLongueur.Size = new System.Drawing.Size(52, 13);
            this.lblLongueur.TabIndex = 3;
            this.lblLongueur.Text = "Longueur";
            // 
            // txtBoxLongueur
            // 
            this.txtBoxLongueur.Location = new System.Drawing.Point(362, 251);
            this.txtBoxLongueur.Name = "txtBoxLongueur";
            this.txtBoxLongueur.Size = new System.Drawing.Size(99, 20);
            this.txtBoxLongueur.TabIndex = 2;
            this.txtBoxLongueur.Text = "8";
            // 
            // btnCommencer
            // 
            this.btnCommencer.Location = new System.Drawing.Point(513, 225);
            this.btnCommencer.Name = "btnCommencer";
            this.btnCommencer.Size = new System.Drawing.Size(116, 46);
            this.btnCommencer.TabIndex = 4;
            this.btnCommencer.Text = "Commencer";
            this.btnCommencer.UseVisualStyleBackColor = true;
            this.btnCommencer.Click += new System.EventHandler(this.btnCommencer_Click);
            // 
            // FrmLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FilRouge.Properties.Resources.sticker_cavalier_1_;
            this.ClientSize = new System.Drawing.Size(884, 456);
            this.Controls.Add(this.btnCommencer);
            this.Controls.Add(this.lblLongueur);
            this.Controls.Add(this.txtBoxLongueur);
            this.Controls.Add(this.lblHauteur);
            this.Controls.Add(this.txtBoxHauteur);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 495);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 495);
            this.Name = "FrmLauncher";
            this.ShowIcon = false;
            this.Text = "Cavalier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxHauteur;
        private System.Windows.Forms.Label lblHauteur;
        private System.Windows.Forms.Label lblLongueur;
        private System.Windows.Forms.TextBox txtBoxLongueur;
        private System.Windows.Forms.Button btnCommencer;
    }
}

