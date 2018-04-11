namespace AGSE_Manager
{
    partial class MenuPrincipal
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
            this.btNouveauDossier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btNouveauDossier
            // 
            this.btNouveauDossier.Location = new System.Drawing.Point(115, 94);
            this.btNouveauDossier.Name = "btNouveauDossier";
            this.btNouveauDossier.Size = new System.Drawing.Size(148, 123);
            this.btNouveauDossier.TabIndex = 0;
            this.btNouveauDossier.Text = "Nouveau dossier";
            this.btNouveauDossier.UseVisualStyleBackColor = true;
            this.btNouveauDossier.Click += new System.EventHandler(this.btNouveauDossier_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.btNouveauDossier);
            this.Name = "MenuPrincipal";
            this.Text = "AGSE - Menu Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btNouveauDossier;
    }
}

