using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGSE_Manager
{
    public partial class FormDossier : Form
    {

        private Dossier _dossier;
        private BaseDeDonnees _BDD = new BaseDeDonnees();

        public FormDossier(Dossier dossier)
        {
            InitializeComponent();
            this._dossier = dossier;
        }

        private void FormDossier_Load(object sender, EventArgs e)
        {
            // ############################################################################################################## \\
            //                                    INITIALISATION DES OBJETS DE FormDossier                                    \\
            // ############################################################################################################## \\

            // MISSION\\
            dtpMissionDateSurvenanceSinistre.Format = DateTimePickerFormat.Custom;
            dtpMissionDateSurvenanceSinistre.CustomFormat = "dd-MM-yyyy";
            _BDD.RemplirComboBox(cbMissionTypeSinistre, "sinistre");
            pnlMissionRepresentantClient.Hide();
            lblMissionErreurRepresentant.Hide();
            lblMissionErreurNouveauClientParticulier.Hide();
            pnlMissionRepresentantValiditeNom.Hide();
            pnlMissionRepresentantValiditePrenom.Hide();
            pnlMissionRepresentantValiditeTelephone.Hide();
            pnlMissionRepresentantValiditeMail.Hide();
            btMissionNouveauTypeSinistre.Hide();
            btMissionMettreAJourSinistre.Hide();
            lblMissionErreurSinistre.Hide();
            btMissionMettreAJourClientParticulier.Hide();
            btMissionMettreAJourRepresentant.Hide();
            btMissionMettreAJourClientProfessionnel.Hide();
            lblMissionErreurNouveauClientProfessionnel.Hide();
            pnlMissionNouveauClientProfessionnel.Hide();
            pnlMissionRechercheClientParticulier.Hide();
            pnlMissionRechercheClientProfessionnel.Hide();


            // Si le dossier est un dossier existant alors on remplit les textbox, coche les boutons radios ...
            //sinon :

            // MISSION \\
            rbtMissionClientNouveau.Checked = true;
            rbtMissionClientParticulier.Checked = true;
            rbtMissionRepresentantAucun.Checked = true;
            pnlMissionNouveauClientParticulier.Show();

            // Client exp = _BDD.RechercherClientParId(2);
            // MessageBox.Show(exp.ToString()+exp.Representant.Nom);

            Compagnie r = _BDD.RechercherCompagnieParId(17);
            MessageBox.Show(r.ToString());

        }


        // ############################################################################################################## \\
        //                                                 TAB MISSION                                                    \\
        // ############################################################################################################## \\

                        // ################################### MISSION #################################### \\
        private void cbMissionTypeSinistre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!btMissionMettreAJourSinistre.Visible) { btMissionMettreAJourSinistre.Show(); }
            if(String.IsNullOrEmpty(cbMissionTypeSinistre.SelectedItem.ToString()))
            {
                if(!btMissionNouveauTypeSinistre.Visible)
                {
                    btMissionNouveauTypeSinistre.Show();
                } 
            }
            else
            {
                if(btMissionNouveauTypeSinistre.Visible)
                {
                    btMissionNouveauTypeSinistre.Hide();
                }
            }
        }
        private void dtpMissionDateSurvenanceSinistre_ValueChanged(object sender, EventArgs e)
        {
            if (!btMissionMettreAJourSinistre.Visible) { btMissionMettreAJourSinistre.Show(); }
        }
        private void btMissionNouveauTypeSinistre_Click(object sender, EventArgs e)
        {
            AjouterValeurDansComboBox(cbMissionTypeSinistre, tbMissionTypeSinistre, btMissionNouveauTypeSinistre, "sinistre");
        }

        private void btMissionMettreAJourSinistre_Click(object sender, EventArgs e)
        {
            if (lblMissionErreurSinistre.Visible) { lblMissionErreurSinistre.Hide(); }
            if (VerificationSyntaxeVille(tbMissionVilleSinistre.Text) && VerificationSyntaxeCodePostal(tbMissionCodePostalSinistre.Text))
            {
                btMissionMettreAJourSinistre.Hide();
                pnlMissionValiditeVilleSinistre.Hide();
                pnlMissionValiditeCodePostalSinistre.Hide();

                _dossier.Sinistre.Type = cbMissionTypeSinistre.Text;
                _dossier.Sinistre.DateSurvenance = dtpMissionDateSurvenanceSinistre.Value;
                _dossier.Sinistre.Adresse = tbMissionAdresseSinistre.Text;
                _dossier.Sinistre.Ville = tbMissionVilleSinistre.Text;
                _dossier.Sinistre.CodePostal = tbMissionCodePostalSinistre.Text;
                _BDD.MettreAJourSinistre(_dossier.Sinistre);
            }
            else
            {
                lblMissionErreurSinistre.Text = "Le ou les champ(s) signalé(s) en rouge doit(vent) être corrigé(s)";
                lblMissionErreurSinistre.Show();
            }
        }

        private void tbMissionVilleSinistre_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourSinistre, pnlMissionValiditeVilleSinistre, tbMissionVilleSinistre.Text, "ville");
        }
        private void tbMissionCodePostalSinistre_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourSinistre, pnlMissionValiditeCodePostalSinistre, tbMissionCodePostalSinistre.Text, "codePostal");
        }



        // Boutons radios (x6)  MANQUE VERIFS AVANT DE SHOW OU HIDE LES PANELS
        private void rbtMissionClientParticulier_Click(object sender, EventArgs e)
        {
            if (rbtMissionClientParticulier.Checked)
            {
                if (rbtMissionClientNouveau.Checked)
                {
                    // Affichage du panel pour la création d'un nouveau client particulier
                    pnlMissionNouveauClientParticulier.Show();
                    pnlMissionNouveauClientProfessionnel.Hide();
                    pnlMissionRechercheClientParticulier.Hide();
                    pnlMissionRechercheClientProfessionnel.Hide();
                }
                else
                {
                    // Affichage du panel pour la recherche d'un client particulier
                    pnlMissionNouveauClientParticulier.Hide();
                    pnlMissionNouveauClientProfessionnel.Hide();
                    pnlMissionRechercheClientParticulier.Show();
                    pnlMissionRechercheClientProfessionnel.Hide();
                }
            }
        }
        private void rbtMissionClientProfessionnel_Click(object sender, EventArgs e)
        {
            if (rbtMissionClientProfessionnel.Checked)
            {
                if (rbtMissionClientNouveau.Checked)
                {
                    // Affichage du panel pour la création d'un nouveau client professionnel
                    pnlMissionNouveauClientParticulier.Hide();
                    pnlMissionNouveauClientProfessionnel.Show();
                    pnlMissionRechercheClientParticulier.Hide();
                    pnlMissionRechercheClientProfessionnel.Hide();
                }
                else
                {
                    // Affichage du panel pour la recherche d'un client professionnel
                    pnlMissionNouveauClientParticulier.Hide();
                    pnlMissionNouveauClientProfessionnel.Hide();
                    pnlMissionRechercheClientParticulier.Hide();
                    pnlMissionRechercheClientProfessionnel.Show();
                }
            }
        }
        private void rbtMissionClientNouveau_Click(object sender, EventArgs e)
        {
            if (rbtMissionClientNouveau.Checked)
            {
                if (rbtMissionClientParticulier.Checked)
                {
                    // Affichage du panel pour la création d'un nouveau client particulier
                    pnlMissionNouveauClientParticulier.Show();
                    pnlMissionNouveauClientProfessionnel.Hide();
                    pnlMissionRechercheClientParticulier.Hide();
                    pnlMissionRechercheClientProfessionnel.Hide();
                }
                else
                {
                    // Affichage du panel pour la création d'un nouveau client professionnel
                    pnlMissionNouveauClientParticulier.Hide();
                    pnlMissionNouveauClientProfessionnel.Show();
                    pnlMissionRechercheClientParticulier.Hide();
                    pnlMissionRechercheClientProfessionnel.Hide();
                }
            }
        }
        private void rbtMissionClientRechercher_Click(object sender, EventArgs e)
        {
            if (rbtMissionClientRechercher.Checked)
            {
                if (rbtMissionClientParticulier.Checked)
                {
                    // Affichage du panel pour la recherche d'un client particulier
                    pnlMissionNouveauClientParticulier.Hide();
                    pnlMissionNouveauClientProfessionnel.Hide();
                    pnlMissionRechercheClientParticulier.Show();
                    pnlMissionRechercheClientProfessionnel.Hide();
                }
                else
                {
                    // Affichage du panel pour la recherche d'un client professionnel
                    pnlMissionNouveauClientParticulier.Hide();
                    pnlMissionNouveauClientProfessionnel.Hide();
                    pnlMissionRechercheClientParticulier.Hide();
                    pnlMissionRechercheClientProfessionnel.Show();
                }
            }
        }
        private void rbtMissionRepresentantAucun_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_dossier.Mission.Client.Representant.Nom))
            {
                DialogResult choixMessageBox = MessageBox.Show("Voulez-vous vraiment supprimer le représentant déjà sauvegardé ?", "Suppression", MessageBoxButtons.YesNo);
                if (choixMessageBox == DialogResult.Yes)
                {
                    pnlMissionRepresentantClient.Hide();
                    _dossier.Mission.Client.Representant.Nom = null;
                    _dossier.Mission.Client.Representant.Prenom = null;
                    _dossier.Mission.Client.Representant.Telephone = null;
                    _dossier.Mission.Client.Representant.Mail = null;
                    _dossier.Mission.Client.Representant.Qualite = null;
                    _BDD.MettreAJourRepresentant(_dossier.Mission.Client.Representant);
                }
                else
                {
                    rbtMissionRepresentantPresent.Checked = true;
                    rbtMissionRepresentantAucun.Checked = false;
                }
            }
            else
            {
                pnlMissionRepresentantClient.Hide();
            }

        }
        private void rbtMissionRepresentantPresent_Click(object sender, EventArgs e)
        {
            if (!pnlMissionRepresentantClient.Visible)
            {
                pnlMissionRepresentantClient.Show();
            }
        }



                        // ################################ REPRESENTANT ################################# \\
        private void btMissionMettreAJourRepresentant_Click(object sender, EventArgs e)
        {
            if(lblMissionErreurRepresentant.Visible) { lblMissionErreurRepresentant.Hide(); }
            if(String.IsNullOrEmpty(tbMissionNomRepresentant.Text))
            {
                lblMissionErreurRepresentant.Text = "Le champ 'Nom' doit être rempli";
                lblMissionErreurRepresentant.Show();
            }
            else
            {
                if(VerificationSyntaxeNom(tbMissionNomRepresentant.Text) && VerificationSyntaxeNom(tbMissionPrenomRepresentant.Text) && VerificationSyntaxeTelephone(tbMissionTelephoneRepresentant.Text) && VerificationSyntaxeMail(tbMissionMailRepresentant.Text))
                {
                    btMissionMettreAJourRepresentant.Hide();
                    pnlMissionRepresentantValiditeNom.Hide();
                    pnlMissionRepresentantValiditePrenom.Hide();
                    pnlMissionRepresentantValiditeTelephone.Hide();
                    pnlMissionRepresentantValiditeMail.Hide();

                    _dossier.Mission.Client.Representant.Nom = tbMissionNomRepresentant.Text;
                    _dossier.Mission.Client.Representant.Prenom = tbMissionPrenomRepresentant.Text;
                    _dossier.Mission.Client.Representant.Telephone = tbMissionTelephoneRepresentant.Text;
                    _dossier.Mission.Client.Representant.Mail = tbMissionMailRepresentant.Text;
                    _dossier.Mission.Client.Representant.Qualite = rtbMissionQualiteRepresentant.Text;
                    _BDD.MettreAJourRepresentant(_dossier.Mission.Client.Representant);
                }
                else
                {
                    lblMissionErreurRepresentant.Text = "Le ou les champ(s) signalé(s) en rouge doit(vent) être corrigé(s)";
                    lblMissionErreurRepresentant.Show();
                }
            }
        }

        private void tbMissionNomRepresentant_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourRepresentant, pnlMissionRepresentantValiditeNom, tbMissionNomRepresentant.Text, "nom");
        }
        private void tbMissionPrenomRepresentant_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourRepresentant, pnlMissionRepresentantValiditePrenom, tbMissionPrenomRepresentant.Text, "nom");
        }
        private void tbMissionTelephoneRepresentant_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourRepresentant, pnlMissionRepresentantValiditeTelephone, tbMissionTelephoneRepresentant.Text, "telephone");
        }
        private void tbMissionMailRepresentant_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourRepresentant, pnlMissionRepresentantValiditeMail, tbMissionMailRepresentant.Text, "mail");
        }


                    // ############################ NOUVEAU CLIENT PARTICULIER ############################# \\
        private void btMissionMettreAJourClientParticulier_Click(object sender, EventArgs e)
        {
            if (lblMissionErreurNouveauClientParticulier.Visible) { lblMissionErreurNouveauClientParticulier.Hide(); }
            if (String.IsNullOrEmpty(tbMissionNomClientParticulier.Text))
            {
                lblMissionErreurNouveauClientParticulier.Text = "Le champ 'Nom' doit être rempli";
                lblMissionErreurNouveauClientParticulier.Show();
            }
            else
            {
                if (VerificationSyntaxeNom(tbMissionNomClientParticulier.Text) && VerificationSyntaxeNom(tbMissionPrenomClientParticulier.Text) && VerificationSyntaxeVille(tbMissionVilleClientParticulier.Text) && VerificationSyntaxeCodePostal(tbMissionCodePostalClientParticulier.Text) && VerificationSyntaxeTelephone(tbMissionTelephoneClientParticulier.Text) && VerificationSyntaxeMail(tbMissionMailClientParticulier.Text))
                {
                    btMissionMettreAJourClientParticulier.Hide();
                    pnlMissionNouveauClientParticulierValiditeNom.Hide();
                    pnlMissionNouveauClientParticulierValiditePrenom.Hide();
                    pnlMissionNouveauClientParticulierValiditeVille.Hide();
                    pnlMissionNouveauClientParticulierValiditeCodePostal.Hide();
                    pnlMissionNouveauClientParticulierValiditeTelephone.Hide();
                    pnlMissionNouveauClientParticulierValiditeMail.Hide();

                    _dossier.Mission.Client.Nom = tbMissionNomClientParticulier.Text;
                    _dossier.Mission.Client.Prenom = tbMissionPrenomClientParticulier.Text;
                    _dossier.Mission.Client.Adresse = tbMissionAdresseClientParticulier.Text;
                    _dossier.Mission.Client.Ville = tbMissionVilleClientParticulier.Text;
                    _dossier.Mission.Client.CodePostal = tbMissionCodePostalClientParticulier.Text;
                    _dossier.Mission.Client.Telephone = tbMissionTelephoneClientParticulier.Text;
                    _dossier.Mission.Client.Mail = tbMissionMailClientParticulier.Text;
                    _BDD.MettreAJourClient(_dossier.Mission.Client);
                }
                else
                {
                    lblMissionErreurNouveauClientParticulier.Text = "Le ou les champ(s) signalé(s) en rouge doit(vent) être corrigé(s)";
                    lblMissionErreurNouveauClientParticulier.Show();
                }
            }
        }

        private void tbMissionNomClientParticulier_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientParticulier, pnlMissionNouveauClientParticulierValiditeNom, tbMissionNomClientParticulier.Text, "nom");
        }
        private void tbMissionPrenomClientParticulier_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientParticulier, pnlMissionNouveauClientParticulierValiditePrenom, tbMissionPrenomClientParticulier.Text, "nom");
        }
        private void tbMissionVilleClientParticulier_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientParticulier, pnlMissionNouveauClientParticulierValiditeVille, tbMissionVilleClientParticulier.Text, "ville");
        }
        private void tbMissionCodePostalClientParticulier_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientParticulier, pnlMissionNouveauClientParticulierValiditeCodePostal, tbMissionCodePostalClientParticulier.Text, "codePostal");
        }
        private void tbMissionTelephoneClientParticulier_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientParticulier, pnlMissionNouveauClientParticulierValiditeTelephone, tbMissionTelephoneClientParticulier.Text, "telephone");
        }
        private void tbMissionMailClientParticulier_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientParticulier, pnlMissionNouveauClientParticulierValiditeMail, tbMissionMailClientParticulier.Text, "mail");
        }


                    // ############################ NOUVEAU CLIENT PROFESSIONNEL ########################### \\

        private void btMissionMettreAJourClientProfessionnel_Click(object sender, EventArgs e)
        {
            if (lblMissionErreurNouveauClientProfessionnel.Visible) { lblMissionErreurNouveauClientProfessionnel.Hide(); }
            if (String.IsNullOrEmpty(tbMissionRaisonSocialeClientProfessionnel.Text))
            {
                lblMissionErreurNouveauClientProfessionnel.Text = "Le champ 'Raison Sociale' doit être rempli";
                lblMissionErreurNouveauClientProfessionnel.Show();
            }
            else
            {
                if (VerificationSyntaxeRaisonSociale(tbMissionRaisonSocialeClientProfessionnel.Text) && VerificationSyntaxeVille(tbMissionVilleClientProfessionnel.Text) && VerificationSyntaxeCodePostal(tbMissionCodePostalClientProfessionnel.Text) && VerificationSyntaxeTelephone(tbMissionTelephoneClientProfessionnel.Text))
                {
                    btMissionMettreAJourClientProfessionnel.Hide();
                    pnlMissionNouveauClientProfessionnelValiditeRaisonSociale.Hide();
                    pnlMissionNouveauClientProfessionnelValiditeVille.Hide();
                    pnlMissionNouveauClientProfessionnelValiditeCodePostal.Hide();
                    pnlMissionNouveauClientProfessionnelValiditeTelephone.Hide();

                    _dossier.Mission.Client.RaisonSociale = tbMissionRaisonSocialeClientProfessionnel.Text;
                    _dossier.Mission.Client.AdresseSiegeSocial = tbMissionAdresseClientProfessionnel.Text;
                    _dossier.Mission.Client.VilleSiegeSocial = tbMissionVilleClientProfessionnel.Text;
                    _dossier.Mission.Client.CodePostalSiegeSocial = tbMissionCodePostalClientProfessionnel.Text;
                    _dossier.Mission.Client.TelephoneProfessionnel = tbMissionTelephoneClientProfessionnel.Text;
                    _BDD.MettreAJourClient(_dossier.Mission.Client);
                }
                else
                {
                    lblMissionErreurNouveauClientProfessionnel.Text = "Le ou les champ(s) signalé(s) en rouge doit(vent) être corrigé(s)";
                    lblMissionErreurNouveauClientProfessionnel.Show();
                }
            }
        }

        private void tbMissionRaisonSocialeClientProfessionnel_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientProfessionnel, pnlMissionNouveauClientProfessionnelValiditeRaisonSociale, tbMissionRaisonSocialeClientProfessionnel.Text, "raisonSociale");
        }
        private void tbMissionVilleClientProfessionnel_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientProfessionnel, pnlMissionNouveauClientProfessionnelValiditeVille, tbMissionVilleClientProfessionnel.Text, "ville");
        }
        private void tbMissionCodePostalClientProfessionnel_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientProfessionnel, pnlMissionNouveauClientProfessionnelValiditeCodePostal, tbMissionCodePostalClientProfessionnel.Text, "codePostal");
        }
        private void tbMissionTelephoneClientProfessionnel_TextChanged(object sender, EventArgs e)
        {
            GererValiditeSaisie(btMissionMettreAJourClientProfessionnel, pnlMissionNouveauClientProfessionnelValiditeTelephone, tbMissionTelephoneClientProfessionnel.Text, "telephone");
        }

                    // ############################ RECHERCHE CLIENT PARTICULIER ########################### \\


        // ############################################################################################################## \\
        //                                                 TAB CONTRAT                                                    \\
        // ############################################################################################################## \\

        // ############################################################################################################## \\
        //                                                 TAB SINISTRE                                                   \\
        // ############################################################################################################## \\

        // ############################################################################################################## \\
        //                                                 TAB INTERVENANTS                                               \\
        // ############################################################################################################## \\

        // ############################################################################################################## \\
        //                                                 TAB RISQUES                                                    \\
        // ############################################################################################################## \\

        // ############################################################################################################## \\
        //                                                 TAB DOMMAGES                                                   \\
        // ############################################################################################################## \\

        // ############################################################################################################## \\
        //                                                   PROCEDURES                                                   \\
        // ############################################################################################################## \\
        //
        //  - AjouterValeurDansComboBox(ComboBox , TextBox , Button , string ) -> Void
        //  - VerificationSyntaxeNom(string) -> Bool
        //  - VerificationSyntaxeTelephone(string) -> Bool
        //  - VerificationSyntaxeMail(string) -> Bool
        //  - VerificationSyntaxeVille(string) -> Bool
        //  - VerificationSyntaxeCodePostal(string) -> Bool
        //  - VerificationSyntaxeRaisonSociale(string) -> Bool
        //  - GererValiditeSaisie(Button , Panel , string , string ) -> Void

        private void AjouterValeurDansComboBox(ComboBox comboBox, TextBox textBox, Button button, string categorie)
        {
            if (textBox.Text == "" && textBox.Visible == false)
            {
                comboBox.Hide();
                textBox.Show();
                button.Text = "Valider";
            }
            else
            {
                if (textBox.Text != "")
                {
                    comboBox.Items.Add(textBox.Text);
                    comboBox.SelectedItem = textBox.Text;
                    _BDD.AjouterValeurDansComboBoxItems(categorie, textBox.Text);
                }
                textBox.Hide();
                comboBox.Show();
                textBox.Text = "";
                button.Text = "Ajouter";
            }
        }
        private bool VerificationSyntaxeNom(string texteAVerifier)
        {
            if(!String.IsNullOrEmpty(texteAVerifier))
            {
                return Regex.IsMatch(texteAVerifier, @"^[a-zA-Z- àèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+$");
            }
            else
            {
                return true;
            }
        }
        private bool VerificationSyntaxeTelephone(string texteAVerifier)
        {  
            if (!String.IsNullOrEmpty(texteAVerifier))
            {
                return Regex.IsMatch(texteAVerifier, @"^0[1-9][0-9]{8}$");
            }
            else
            {
                return true;
            }
        }
        private bool VerificationSyntaxeMail(string texteAVerifier)
        {
            // Regex trouvée sur : https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
            if (!String.IsNullOrEmpty(texteAVerifier))
            {
                return Regex.IsMatch(texteAVerifier, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
            }
            else
            {
                return true;
            }
        }
        private bool VerificationSyntaxeVille(string texteAVerifier)
        {
            if (!String.IsNullOrEmpty(texteAVerifier))
            {
                return Regex.IsMatch(texteAVerifier, @"^[a-zA-Z- /\\'àèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+$");
            }
            else
            {
                return true;
            }
        }
        private bool VerificationSyntaxeCodePostal(string texteAVerifier)
        {
            if (!String.IsNullOrEmpty(texteAVerifier))
            {
                return Regex.IsMatch(texteAVerifier, @"^[0-9]{5}$");
            }
            else
            {
                return true;
            }
        }
        private bool VerificationSyntaxeRaisonSociale(string texteAVerifier)
        {
            if (!String.IsNullOrEmpty(texteAVerifier))
            {
                return Regex.IsMatch(texteAVerifier, @"^[[a-zA-Z0-9][a-zA-Z0-9- àèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ.?!:]+$");
            }
            else
            {
                return true;
            }
        }

        private void GererValiditeSaisie(Button boutonDeMiseAJour, Panel panelLogoValidite, string texteAVerifier, string typeDeVerification)
        {
            bool etatVerification = false;
            if (!boutonDeMiseAJour.Visible) { boutonDeMiseAJour.Show(); }
            if (!panelLogoValidite.Visible) { panelLogoValidite.Show(); }
            if (String.IsNullOrEmpty(texteAVerifier))
            {
                panelLogoValidite.Hide();
            }
            else
            {
                if (!panelLogoValidite.Visible)
                {
                    panelLogoValidite.Show();
                }
                switch (typeDeVerification)
                {
                    case "nom":
                        etatVerification = VerificationSyntaxeNom(texteAVerifier);
                        break;
                    case "telephone":
                        etatVerification = VerificationSyntaxeTelephone(texteAVerifier);
                        break;
                    case "mail":
                        etatVerification = VerificationSyntaxeMail(texteAVerifier);
                        break;
                    case "ville":
                        etatVerification = VerificationSyntaxeVille(texteAVerifier);
                        break;
                    case "codePostal":
                        etatVerification = VerificationSyntaxeCodePostal(texteAVerifier);
                        break;
                    case "raisonSociale":
                        etatVerification = VerificationSyntaxeRaisonSociale(texteAVerifier);
                        break;
                }
                if(etatVerification) { panelLogoValidite.BackColor = Color.Green; } else { panelLogoValidite.BackColor = Color.Red; }
            }
        }


    }
}
