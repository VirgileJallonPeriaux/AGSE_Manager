using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGSE_Manager
{
    public partial class MenuPrincipal : Form
    {
        private BaseDeDonnees _BDD = new BaseDeDonnees();

        public MenuPrincipal()
        {
            InitializeComponent();
        }


        private void btNouveauDossier_Click(object sender, EventArgs e)
        {
            Dossier nouveauDossier = new Dossier();
            FormDossier nouveauFormulaireDossier = new FormDossier(nouveauDossier);
            _BDD.CreerDossier(nouveauDossier);
            nouveauFormulaireDossier.Show();


        }
    }
}
