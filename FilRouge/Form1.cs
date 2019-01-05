/******************************************************************************
** PROGRAMME  FilRouge.cs                                                  **
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Tristan Gerber                                                **
** Date      : 04.01.2019                                                    **
**                                                                           **
** Modifications                                                             **
**   Auteur  :                                                               **
**   Version :                                                               **
**   Date    :                                                               **
**   Raisons :                                                               **
**                                                                           **
**                                                                           **
******************************************************************************/

/******************************************************************************
** DESCRIPTION                                                               **
**                                                                           **     
**    Ceci est un cavalier qui consiste à essayer de remplir le plus possible**
**    la grille avant de ne plus pouvoir jouer                               **
**                                                                           **
******************************************************************************/

// MODIFIÉ //

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilRouge
{
    public partial class FrmLauncher : Form
    {
        // Constantes
        const byte MIN = 3;
        const byte MAX = 10;
        const byte GRIS = 0;
        const byte JAUNE = 1;
        const byte ROUGE = 2;

        // Variables et controls
        int intWidth = 0;                                               // Nb de cases de large
        int intHigh = 0;                                                // Nb de cases de haut
        int intScore = 0;                                               // Score du joueur
        int[,] tab_intEtat = new int[MAX, MAX];                         // Tableau d'état des cases
        Label lblScore = new Label();                                   // Label de score
        Button[,] tab_btnGrille = new Button[MAX, MAX];                 // Grille de boutons

        public FrmLauncher()
        {
            InitializeComponent();
        }
        private void btnCommencer_Click(object sender, EventArgs e)
        {
            // On prend la hauteur et la longueur
            intHigh = Convert.ToInt32(txtBoxHauteur.Text);
            intWidth = Convert.ToInt32(txtBoxLongueur.Text);

            // Affichege du message d'erreur si valeur trop haute
            FrmErreur FrmErreur = new FrmErreur();
            if ((intHigh < 3 || intHigh > 10) || (intWidth < 3 || intWidth > 10))
            {
                FrmErreur.Show();
            }
            else
            {
                Controls.Clear();
                Grille(intHigh, intWidth);
            }
        }      // Méthode pour quand on clique sur le bouton commencer
        private void Grille(int high, int length)
        {
            // On nettoie la form
            Controls.Clear();
            int intPosX = 10;                                              // Position x du carré
            int intPosY = 10;                                              // Position y du carré

            // Boucle qui va créer les boutons
            for (int x = 0; x < high; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    // Création d'un bouton
                    tab_btnGrille[x, y] = new Button();
                    tab_btnGrille[x, y].Location = new System.Drawing.Point(intPosX, intPosY);
                    tab_btnGrille[x, y].Name = x + "," + y;
                    tab_btnGrille[x, y].Size = new System.Drawing.Size(50, 50);
                    tab_btnGrille[x, y].TabIndex = 7;
                    tab_btnGrille[x, y].TabStop = false;
                    tab_btnGrille[x, y].UseMnemonic = false;
                    tab_btnGrille[x, y].UseVisualStyleBackColor = false;
                    tab_intEtat[x, y] = GRIS;
                    Controls.Add(tab_btnGrille[x, y]);
                    intPosY += 55;
                    tab_btnGrille[x, y].Click += new System.EventHandler(DeplacerCavalier);

                }
                // Incrémentation de la position
                intPosX += 55;
                intPosY = 10;
            }

            // Création / Configuration du label de score
            lblScore = new Label();
            lblScore.AutoSize = true;
            lblScore.BackColor = System.Drawing.Color.Transparent;
            lblScore.ForeColor = System.Drawing.Color.Red;
            lblScore.Location = new System.Drawing.Point(675, 325);
            lblScore.Name = "lblScore";
            lblScore.Size = new System.Drawing.Size(100, 50);
            lblScore.Font = new System.Drawing.Font("Permanent Marker", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScore.TabIndex = 1;
            lblScore.Text = "Score : ";
            Controls.Add(lblScore);
        }                        // Méthode pour créer la grille de boutons
        private void DeplacerCavalier(object sender, EventArgs e)
        {

            // On va rechercher le bouton actuel
            Button btnActuel = (Button)sender;

            // On sépare le nom du bouton sender pour obtenir le numéro x et y du bouton
            string[] tab_strName = btnActuel.Name.Split(',');
            int intNameX = Convert.ToInt16(tab_strName[0]);
            int intNameY = Convert.ToInt16(tab_strName[1]);

            // On rend accessible le premier bouton sur lequel on clique
            if (intScore == 0)
            {
                tab_intEtat[intNameX, intNameY] = JAUNE;
            }

            // On va chercher dans le tableau les boutons obtenus par des additions/soustractions, on change leur couleur et leur état. Crée aussi une valeur qui contient leur noms
            if (tab_intEtat[intNameX, intNameY] != GRIS && tab_intEtat[intNameX, intNameY] != ROUGE)
            {
                
                // Écriture du score
                lblScore.Text = "Score : " + intScore;

                // Appel de la suite de méthodes de nettoyage et stabilité
                clearYellow();
                
                // Appel à la méthode qui applique certaines règles aux changements de couleurs
                btnColorChange(intNameX + 2, intNameY + 1, JAUNE);
                btnColorChange(intNameX + 2, intNameY - 1, JAUNE);
                btnColorChange(intNameX - 2, intNameY + 1, JAUNE);
                btnColorChange(intNameX - 2, intNameY - 1, JAUNE);
                btnColorChange(intNameX + 1, intNameY + 2, JAUNE);
                btnColorChange(intNameX + 1, intNameY - 2, JAUNE);
                btnColorChange(intNameX - 1, intNameY + 2, JAUNE);
                btnColorChange(intNameX - 1, intNameY - 2, JAUNE);
                btnColorChange(intNameX, intNameY, ROUGE);

                // On regarde si on peut encore jouer
                testJaunes();

                // On augmente le score
                intScore++;
            }
        }        // Méthode pour changer la couleur du bouton quand on clique dessus et proposer les cases
        private void squaresUpdate()
        {
            for (int x = 0; x < intHigh; x++)
            {
                for (int y = 0; y < intWidth; y++)
                {
                    if (tab_intEtat[x, y] == ROUGE) tab_btnGrille[x, y].BackColor = Color.Red;
                    if (tab_intEtat[x, y] ==  GRIS) tab_btnGrille[x, y].BackColor = Color.Empty;
                    if (tab_intEtat[x, y] == JAUNE) tab_btnGrille[x, y].BackColor = Color.Yellow;
                }
            }
        }                                     // Méthode qui garde stable les couleurs
        private void btnColorChange(int x, int y, byte bytColor)
        {
            // Pour ne pas que la case ne déborde
            if ((x <= intWidth && x >= 0) && (y <= intHigh && y >= 0))
            {
                // Si la couleur voulue est rouge, elle change sans prob.
                if (bytColor == ROUGE)
                {
                    tab_intEtat[x, y] = ROUGE;
                }
                // Si elle est jaune ou grise, et si l'état de la case à changer n'est pas rouge, change l'état de la case
                else if (bytColor == JAUNE || bytColor == GRIS)
                {
                    if (tab_intEtat[x, y] != ROUGE) tab_intEtat[x, y] = bytColor;

                }
                // On met tout à jour
                squaresUpdate();
            }
        }         // Méthode qui change les couleurs en suivant certaines règles
        private void clearYellow()
        {
            for (int x = 0; x < intHigh; x++)
            {
                for (int y = 0; y < intWidth; y++)
                {
                    btnColorChange(x, y, GRIS);
                }
            }
        }                                       // Méthode qui remet à zéro toutes les cases jaunes
        private void finDePartie()
        {
            // Suppression de tout ce qu'il y a dans la form
            Controls.Clear();

            // Création et ajout d'un label titre de fin de partie
            Label lblFinDePartie = new Label();
            lblFinDePartie.AutoSize = true;
            lblFinDePartie.BackColor = System.Drawing.Color.Transparent;
            lblFinDePartie.Location = new System.Drawing.Point(0,0);
            lblFinDePartie.Name = "lblFinDePartie";
            lblFinDePartie.Text = "Fin de la partie";
            lblFinDePartie.Font = new System.Drawing.Font("Permanent Marker", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblFinDePartie.ForeColor = System.Drawing.Color.Olive;
            Controls.Add(lblFinDePartie);

            // Création du label de score final
            Label lblScoreFinal = new Label();
            lblScoreFinal.AutoSize = true;
            lblScoreFinal.BackColor = System.Drawing.Color.Transparent;
            lblScoreFinal.Location = new System.Drawing.Point(45, 150);
            lblScoreFinal.Name = "lblScoreFinal";
            lblScoreFinal.Text = "Score : " + intScore + " !!";
            lblScoreFinal.Font = new System.Drawing.Font("Permanent Marker", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScoreFinal.ForeColor = System.Drawing.Color.Olive;
            Controls.Add(lblScoreFinal);

            // Création du bouton rejouer
            Button btnRejouer = new Button();
            btnRejouer.Font = new System.Drawing.Font("Permanent Marker", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnRejouer.Location = new System.Drawing.Point(57, 333);
            btnRejouer.Name = "btnRejouer";
            btnRejouer.Size = new System.Drawing.Size(354, 105);
            btnRejouer.Text = "Rejouer";
            btnRejouer.UseVisualStyleBackColor = true;
            btnRejouer.Click += new System.EventHandler(rejouer);
            Controls.Add(btnRejouer);

            // Création du bouton quitter
            Button btnQuitter = new Button();
            btnQuitter.Font = new System.Drawing.Font("Permanent Marker", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnQuitter.Location = new System.Drawing.Point(434, 333);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new System.Drawing.Size(354, 105);
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += new System.EventHandler(quitter);
            Controls.Add(btnQuitter);
        }                                       // Méthode qui crée tous les composants de l'écran de fin de partie
        private void rejouer(object sender, EventArgs e)
        {
            Controls.Clear();
            Grille(intWidth, intHigh);
            intScore = 0;
        }                 // Méthode qui remet tout à zéro
        private void quitter(object sender, EventArgs e)
        {
            Application.Exit();
        }                 // Méthode qui quitte l'application
        private void testJaunes()
        {
            // Création d'une valeur qui va déterminer le nombre de jaunes
            byte bytJaunes = 0;

            for (int x = 0; x < intHigh; x++)
            {
                for (int y = 0; y < intWidth; y++)
                {
                    if (tab_intEtat[x, y] == JAUNE || intScore == 0)
                    {
                        // Quand on vout une case jaune, on incrémente bytJaunes
                        bytJaunes++;
                    }
                }
            }// 
            // Si il n'y a plus de jaunes, la partie se termine.
            if (bytJaunes == 0)
                finDePartie();
        }                                        // Méthode qui vérifie si l'on peut encore jouer
}