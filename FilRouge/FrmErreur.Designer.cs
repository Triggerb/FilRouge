namespace FilRouge
{
    partial class FrmErreur
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
            this.btnErreur = new System.Windows.Forms.Button();
            this.lblErreur = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnErreur
            // 
            this.btnErreur.Location = new System.Drawing.Point(325, 304);
            this.btnErreur.Name = "btnErreur";
            this.btnErreur.Size = new System.Drawing.Size(100, 35);
            this.btnErreur.TabIndex = 0;
            this.btnErreur.Text = "Continuer";
            this.btnErreur.UseVisualStyleBackColor = true;
            // 
            // lblErreur
            // 
            this.lblErreur.AutoSize = true;
            this.lblErreur.BackColor = System.Drawing.Color.Transparent;
            this.lblErreur.Font = new System.Drawing.Font("Reem Kufi", 9.749999F, System.Drawing.FontStyle.Bold);
            this.lblErreur.ForeColor = System.Drawing.Color.Black;
            this.lblErreur.Location = new System.Drawing.Point(29, 41);
            this.lblErreur.Name = "lblErreur";
            this.lblErreur.Size = new System.Drawing.Size(273, 25);
            this.lblErreur.TabIndex = 1;
            this.lblErreur.Text = "Veuillez entrer une valeur entre 3 et 10 !";
            this.lblErreur.Click += new System.EventHandler(this.lblErreur_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(117, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Continuer";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmErreur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FilRouge.Properties.Resources.sign_error_icon_1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(343, 143);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblErreur);
            this.Controls.Add(this.btnErreur);
            this.DoubleBuffered = true;
            this.Name = "FrmErreur";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Erreur";
            this.Load += new System.EventHandler(this.FrmErreur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnErreur;
        private System.Windows.Forms.Label lblErreur;
        private System.Windows.Forms.Button button1;
    }
}