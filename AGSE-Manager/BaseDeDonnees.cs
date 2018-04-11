using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AGSE_Manager
{
    public class BaseDeDonnees
    {
        private MySqlConnection _connexion;
        private MySqlCommand _requete;

        public BaseDeDonnees()
        {
            _connexion = ConnexionBaseDeDonnees.Connexion;
        }

        // ############################################################################################################## \\
        //                                             PROCEDURES DE CREATION                                             \\
        // ############################################################################################################## \\
        //
        //  - CreerDossier(Dossier) -> Void
        //  - CreerIntervenant(Intervenant) -> Void

        public void CreerDossier(Dossier dossier)
        {
            //
            string[] listeTablesAInsert = new string[] { "Dossier","Representant","Client","Mission","Representant","Assureur","Compagnie","Contrat","EntrepriseRdf","Sinistre","AssuranceDommageOuvrage","Risque" };
            int[] idsRetourneesParLesRequetes = new int[listeTablesAInsert.Length];
            for (int k = 0; k < listeTablesAInsert.Length; k++)
            {
                _connexion.Open();
                _requete = new MySqlCommand("INSERT INTO "+listeTablesAInsert[k]+"() VALUES()", _connexion);
                _requete.ExecuteNonQuery();
                _connexion.Close();
                idsRetourneesParLesRequetes[k] = SelectMaxId(listeTablesAInsert[k]);
            }
            dossier.Id = idsRetourneesParLesRequetes[0];
            dossier.Mission.Client.Representant.Id = idsRetourneesParLesRequetes[1];
            dossier.Mission.Client.Id = idsRetourneesParLesRequetes[2];
            dossier.Mission.Id = idsRetourneesParLesRequetes[3];
            dossier.Contrat.Assureur.Representant.Id = idsRetourneesParLesRequetes[4];
            dossier.Contrat.Assureur.Id = idsRetourneesParLesRequetes[5];
            dossier.Contrat.Compagnie.Id = idsRetourneesParLesRequetes[6];
            dossier.Contrat.Id = idsRetourneesParLesRequetes[7];
            dossier.Sinistre.EntrepriseRdf.Id = idsRetourneesParLesRequetes[8];
            dossier.Sinistre.Id = idsRetourneesParLesRequetes[9];
            dossier.Risque.AssuranceDommageOuvrage.Id = idsRetourneesParLesRequetes[10];
            dossier.Risque.Id = idsRetourneesParLesRequetes[11];

            MettreAJourSinistre(dossier.Sinistre);
            MettreAJourContrat(dossier.Contrat);
            MettreAJourClient(dossier.Mission.Client);
            MettreAJourAssureur(dossier.Contrat.Assureur);
            MettreAJourMission(dossier.Mission);
            MettreAJourRisque(dossier.Risque);
            MettreAJourAssuranceDommageOuvrage(dossier.Risque.AssuranceDommageOuvrage);
        }

        public void CreerIntervenant(Intervenant intervenant)
        {
            //
            string[] listeTablesAInsert = new string[] { "Intervenant","Compagnie","Expert","Representant","Assureur","Representant" };
            int[] idsRetourneesParLesRequetes = new int[listeTablesAInsert.Length];
            for (int k = 0; k < listeTablesAInsert.Length; k++)
            {
                _connexion.Open();
                _requete = new MySqlCommand("INSERT INTO " + listeTablesAInsert[k] + "() VALUES()", _connexion);
                _requete.ExecuteNonQuery();
                _connexion.Close();
                idsRetourneesParLesRequetes[k] = SelectMaxId(listeTablesAInsert[k]);
            }
            intervenant.Id = idsRetourneesParLesRequetes[0];
            intervenant.Compagnie.Id = idsRetourneesParLesRequetes[1];
            intervenant.Expert.Id = idsRetourneesParLesRequetes[2];
            intervenant.Representant.Id = idsRetourneesParLesRequetes[3];
            intervenant.Assureur.Id = idsRetourneesParLesRequetes[4];
            intervenant.Assureur.Representant.Id = idsRetourneesParLesRequetes[5];

            MettreAJourIntervenant(intervenant);
            MettreAJourAssureur(intervenant.Assureur);
        }

        // ############################################################################################################## \\
        //                                          PROCEDURES DE MISE A JOUR                                             \\
        // ############################################################################################################## \\
        //
        //  - MettreAJourDossier(Dossier) -> Void
        //  - MettreAJourSinistre(Sinistre) -> Void
        //  - MettreAJourMission(Mission) -> Void
        //  - MettreAJourContrat(Contrat) -> Void
        //  - MettreAJourIntervenant(Intervenant) -> Void
        //  - MettreAJourRisque(Risque) -> Void
        //  - MettreAJourRepresentant(Representant) -> Void
        //  - MettreAJourClient(Client) -> Void
        //  - MettreAJourCompagnie(Compagnie) -> Void
        //  - MettreAJourAssureur(Assureur) -> Void
        //  - MettreAJourEntrepriseRdf(EntrepriseRdf) -> Void
        //  - MettreAJourExpert(Expert) -> Void
        //  - MettreAJourAssuranceDommageOuvrage(AssuranceDommageOuvrage) -> Void

        public void MettreAJourDossier(Dossier dossier)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Dossier SET modifiable=@modifiable WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@modifiable", dossier.EstModifiable));
            _requete.Parameters.Add(new MySqlParameter("@id", dossier.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourSinistre(Sinistre sinistre)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Sinistre SET type=@type, adresse=@adresse, ville=@ville, codePostal=@codePostal, dateSurvenance=@dateSurvenance, causesEtCirconstances=@causesEtCirconstances, origine=@origine, rdf=@rdf, origineSinistre=@origineSinistre, idEntrepriseRdf=@idEntrepriseRdf WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@type", sinistre.Type));
            _requete.Parameters.Add(new MySqlParameter("@adresse", sinistre.Adresse));
            _requete.Parameters.Add(new MySqlParameter("@ville", sinistre.Ville));
            _requete.Parameters.Add(new MySqlParameter("@codePostal", sinistre.CodePostal));
            _requete.Parameters.Add(new MySqlParameter("@dateSurvenance", sinistre.DateSurvenance));
            _requete.Parameters.Add(new MySqlParameter("@causesEtCirconstances", sinistre.CausesEtCirconstances));
            _requete.Parameters.Add(new MySqlParameter("@origine", sinistre.Origine));
            _requete.Parameters.Add(new MySqlParameter("@rdf", sinistre.Rdf));
            _requete.Parameters.Add(new MySqlParameter("@origineSinistre", sinistre.OrigineSinistre));
            _requete.Parameters.Add(new MySqlParameter("@idEntrepriseRdf", sinistre.EntrepriseRdf.Id));
            _requete.Parameters.Add(new MySqlParameter("@id", sinistre.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourMission(Mission mission)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Mission SET dateReception=@dateReception, dateConfirmationReception=@dateConfirmationReception, moyenMissionnement=@moyenMissionnement, idClient=@idClient WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@dateReception", mission.DateReception));
            _requete.Parameters.Add(new MySqlParameter("@dateConfirmationReception", mission.DateConfirmationReception));
            _requete.Parameters.Add(new MySqlParameter("@moyenMissionnement", mission.MoyenMissionnement));
            _requete.Parameters.Add(new MySqlParameter("@idClient", mission.Client.Id));
            _requete.Parameters.Add(new MySqlParameter("@id", mission.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourContrat(Contrat contrat)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Contrat SET type=@type, formule=@formule, effetDu=@effetDu, numeroContrat=@numeroContrat, numeroCg=@numeroCg, intercalaire=@intercalaire, franchise=@franchise, detailFranchise=@detailFranchise, indiceSouscription=@indiceSouscription, indiceIndemnisation = @indiceIndemnisation, optionUn = @optionUn, optionDeux = @optionDeux, optionTrois = @optionTrois, detailOptionUn = @detailOptionUn, detailOptionDeux = @detailOptionDeux, detailOptionTrois = @detailOptionTrois, idCompagnie = @idCompagnie, idAssureur = @idAssureur WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@type", contrat.Type));
            _requete.Parameters.Add(new MySqlParameter("@formule", contrat.Formule));
            _requete.Parameters.Add(new MySqlParameter("@effetDu", contrat.EffetDu));
            _requete.Parameters.Add(new MySqlParameter("@numeroContrat", contrat.NumeroContrat));
            _requete.Parameters.Add(new MySqlParameter("@numeroCg", contrat.NumeroCg));
            _requete.Parameters.Add(new MySqlParameter("@intercalaire", contrat.Intercalaire));
            _requete.Parameters.Add(new MySqlParameter("@franchise", contrat.Franchise));
            _requete.Parameters.Add(new MySqlParameter("@detailFranchise", contrat.DetailFranchise));
            _requete.Parameters.Add(new MySqlParameter("@indiceSouscription", contrat.IndiceSouscription));
            _requete.Parameters.Add(new MySqlParameter("@indiceIndemnisation", contrat.IndiceIndemnisation));
            _requete.Parameters.Add(new MySqlParameter("@optionUn", contrat.OptionUn));
            _requete.Parameters.Add(new MySqlParameter("@optionDeux", contrat.OptionDeux));
            _requete.Parameters.Add(new MySqlParameter("@optionTrois", contrat.OptionTrois));
            _requete.Parameters.Add(new MySqlParameter("@detailOptionUn", contrat.DetailOptionUn));
            _requete.Parameters.Add(new MySqlParameter("@detailOptionDeux", contrat.DetailOptionDeux));
            _requete.Parameters.Add(new MySqlParameter("@detailOptionTrois", contrat.DetailOptionTrois));
            _requete.Parameters.Add(new MySqlParameter("@idCompagnie", contrat.Compagnie.Id));
            _requete.Parameters.Add(new MySqlParameter("@idAssureur", contrat.Assureur.Id));
            _requete.Parameters.Add(new MySqlParameter("@id", contrat.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourIntervenant(Intervenant intervenant)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Intervenant SET nom=@nom, prenom=@prenom, adresse=@adresse, ville=@ville, codePostal=@codePostal, telephone=@telephone, mail=@mail, statut=@statut, presence=@presence, qualite=@qualite, typeLieu=@typeLieu, utilite=@utilite, etat=@etat, etage=@etage, remarque=@remarque, numeroContrat=@numeroContrat, numeroSinistre=@numeroSinistre, idRepresentant=@idRepresentant, idCompagnie=@idCompagnie, idAssureur=@idAssureur, idExpert=@idExpert, idDossier=@idDossier WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@nom", intervenant.Nom));
            _requete.Parameters.Add(new MySqlParameter("@prenom", intervenant.Prenom));
            _requete.Parameters.Add(new MySqlParameter("@adresse", intervenant.Adresse));
            _requete.Parameters.Add(new MySqlParameter("@ville", intervenant.Ville));
            _requete.Parameters.Add(new MySqlParameter("@codePostal", intervenant.CodePostal));
            _requete.Parameters.Add(new MySqlParameter("@telephone", intervenant.Telephone));
            _requete.Parameters.Add(new MySqlParameter("@mail", intervenant.Mail));
            _requete.Parameters.Add(new MySqlParameter("@statut", intervenant.Statut));
            _requete.Parameters.Add(new MySqlParameter("@presence", intervenant.Presence));
            _requete.Parameters.Add(new MySqlParameter("@qualite", intervenant.Qualite));
            _requete.Parameters.Add(new MySqlParameter("@typeLieu", intervenant.TypeLieu));
            _requete.Parameters.Add(new MySqlParameter("@utilite", intervenant.Utilite));
            _requete.Parameters.Add(new MySqlParameter("@etat", intervenant.Etat));
            _requete.Parameters.Add(new MySqlParameter("@etage", intervenant.Etage));
            _requete.Parameters.Add(new MySqlParameter("@remarque", intervenant.Remarque));
            _requete.Parameters.Add(new MySqlParameter("@numeroContrat", intervenant.NumeroContrat));
            _requete.Parameters.Add(new MySqlParameter("@numeroSinistre", intervenant.NumeroSinistre));
            _requete.Parameters.Add(new MySqlParameter("@idRepresentant", intervenant.Representant.Id));
            _requete.Parameters.Add(new MySqlParameter("@idCompagnie", intervenant.Compagnie.Id));
            _requete.Parameters.Add(new MySqlParameter("@idAssureur", intervenant.Assureur.Id));
            _requete.Parameters.Add(new MySqlParameter("@idExpert", intervenant.Expert.Id));
            _requete.Parameters.Add(new MySqlParameter("@idDossier", intervenant.IdDossier));
            _requete.Parameters.Add(new MySqlParameter("@id", intervenant.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourRisque(Risque risque)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Risque SET type=@type, dateConstruction=@dateConstruction, anneeConstruction=@anneeConstruction, typeMur=@typeMur, anneeConstructionMur=@anneeConstructionMur, typeCouverture=@typeCouverture, anneeConstructionCouverture=@anneeConstructionCouverture, utilite=@utilite, batimentClasse=@batimentClasse, etat=@etat, piecePrincipaleAuContrat=@piecePrincipaleAuContrat, piecePrincipaleConstatee=@piecePrincialeConstatee, dependanceAuContrat=@dependanceAuContrat, dependanceConstatee=@dependanceConstatee, details=@details, conformite=@conformite, motif=@motif, amiante=@amiante, assuranceDommageOuvrage=@assuranceDommageOuvrage WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@type", risque.Type));
            _requete.Parameters.Add(new MySqlParameter("@dateConstruction", risque.DateConstruction));
            _requete.Parameters.Add(new MySqlParameter("@anneeConstruction", risque.AnneeConstruction));
            _requete.Parameters.Add(new MySqlParameter("@typeMur", risque.TypeMur));
            _requete.Parameters.Add(new MySqlParameter("@anneeConstructionMur", risque.AnneeConstructionMur));
            _requete.Parameters.Add(new MySqlParameter("@typeCouverture", risque.TypeCouverture));
            _requete.Parameters.Add(new MySqlParameter("@anneeConstructionCouverture", risque.AnneeConstructionCouverture));
            _requete.Parameters.Add(new MySqlParameter("@utilite", risque.Utilite));
            _requete.Parameters.Add(new MySqlParameter("@batimentClasse", risque.BatimentClasse));
            _requete.Parameters.Add(new MySqlParameter("@etat", risque.Etat));
            _requete.Parameters.Add(new MySqlParameter("@piecePrincipaleAuContrat", risque.PiecePrincipaleAuContrat));
            _requete.Parameters.Add(new MySqlParameter("@piecePrincialeConstatee", risque.PiecePrincipaleConstatee));
            _requete.Parameters.Add(new MySqlParameter("@dependanceAuContrat", risque.DependanceAuContrat));
            _requete.Parameters.Add(new MySqlParameter("@dependanceConstatee", risque.DependanceConstatee));
            _requete.Parameters.Add(new MySqlParameter("@details", risque.Details));
            _requete.Parameters.Add(new MySqlParameter("@conformite", risque.Conformite));
            _requete.Parameters.Add(new MySqlParameter("@motif", risque.Motif));
            _requete.Parameters.Add(new MySqlParameter("@amiante", risque.Amiante));
            _requete.Parameters.Add(new MySqlParameter("@assuranceDommageOuvrage", risque.AssuranceDommageOuvrageSouscrite));
            _requete.Parameters.Add(new MySqlParameter("@id", risque.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourRepresentant(Representant representant)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Representant SET nom=@nom, prenom=@prenom, telephone=@telephone, mail=@mail, qualite=@qualite WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@nom", representant.Nom));
            _requete.Parameters.Add(new MySqlParameter("@prenom", representant.Prenom));
            _requete.Parameters.Add(new MySqlParameter("@telephone", representant.Telephone));
            _requete.Parameters.Add(new MySqlParameter("@mail", representant.Mail));
            _requete.Parameters.Add(new MySqlParameter("@qualite", representant.Qualite));
            _requete.Parameters.Add(new MySqlParameter("@id", representant.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourClient(Client client)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Client SET nom=@nom, prenom=@prenom, adresse=@adresse, ville=@ville, codePostal=@codePostal, telephone=@telephone, mail=@mail, raisonSociale=@raisonSociale, adresseSiegeSocial=@adresseSiegeSocial, villeSiegeSocial = @villeSiegeSocial, codePostalSiegeSocial = @codePostalSiegeSocial, telephoneProfessionnel = @telephoneProfessionnel, idRepresentant = @idRepresentant WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@nom", client.Nom));
            _requete.Parameters.Add(new MySqlParameter("@prenom", client.Prenom));
            _requete.Parameters.Add(new MySqlParameter("@adresse", client.Adresse));
            _requete.Parameters.Add(new MySqlParameter("@ville", client.Ville));
            _requete.Parameters.Add(new MySqlParameter("@codePostal", client.CodePostal));
            _requete.Parameters.Add(new MySqlParameter("@telephone", client.Telephone));
            _requete.Parameters.Add(new MySqlParameter("@mail", client.Mail));
            _requete.Parameters.Add(new MySqlParameter("@raisonSociale", client.RaisonSociale));
            _requete.Parameters.Add(new MySqlParameter("@adresseSiegeSocial", client.AdresseSiegeSocial));
            _requete.Parameters.Add(new MySqlParameter("@villeSiegeSocial", client.VilleSiegeSocial));
            _requete.Parameters.Add(new MySqlParameter("@codePostalSiegeSocial", client.CodePostalSiegeSocial));
            _requete.Parameters.Add(new MySqlParameter("@telephoneProfessionnel", client.TelephoneProfessionnel));
            _requete.Parameters.Add(new MySqlParameter("@idRepresentant", client.Representant.Id));
            _requete.Parameters.Add(new MySqlParameter("@id", client.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourCompagnie(Compagnie compagnie)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Compagnie SET raisonSociale=@raisonSociale, adresse=@adresse, ville=@ville, codePostal=@codePostal WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@raisonSociale", compagnie.RaisonSociale));
            _requete.Parameters.Add(new MySqlParameter("@adresse", compagnie.Adresse));
            _requete.Parameters.Add(new MySqlParameter("@ville", compagnie.Ville));
            _requete.Parameters.Add(new MySqlParameter("@codePostal", compagnie.CodePostal));
            _requete.Parameters.Add(new MySqlParameter("@id", compagnie.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourAssureur(Assureur assureur)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Assureur SET raisonSociale=@raisonSociale, adresse=@adresse, ville=@ville, codePostal=@codePostal, telephone=@telephone, mail=@mail, idRepresentant=@idRepresentant WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@raisonSociale", assureur.RaisonSociale));
            _requete.Parameters.Add(new MySqlParameter("@adresse", assureur.Adresse));
            _requete.Parameters.Add(new MySqlParameter("@ville", assureur.Ville));
            _requete.Parameters.Add(new MySqlParameter("@codePostal", assureur.CodePostal));
            _requete.Parameters.Add(new MySqlParameter("@telephone", assureur.Telephone));
            _requete.Parameters.Add(new MySqlParameter("@mail", assureur.Mail));
            _requete.Parameters.Add(new MySqlParameter("@idRepresentant", assureur.Representant.Id));
            _requete.Parameters.Add(new MySqlParameter("@id", assureur.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourEntrepriseRdf(EntrepriseRdf entrepriseRdf)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE EntrepriseRdf SET raisonSociale=@raisonSociale, adresse=@adresse, ville=@ville, codePostal=@codePostal WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@raisonSociale", entrepriseRdf.RaisonSociale));
            _requete.Parameters.Add(new MySqlParameter("@adresse", entrepriseRdf.Adresse));
            _requete.Parameters.Add(new MySqlParameter("@ville", entrepriseRdf.Ville));
            _requete.Parameters.Add(new MySqlParameter("@codePostal", entrepriseRdf.CodePostal));
            _requete.Parameters.Add(new MySqlParameter("@id", entrepriseRdf.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourExpert(Expert expert)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE Expert SET nom=@nom, prenom=@prenom, adresse=@adresse, ville=@ville, codePostal=@codePostal, telephone=@telephone, mail=@mail, numeroDossier=@numeroDossier WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@nom", expert.Nom));
            _requete.Parameters.Add(new MySqlParameter("@prenom", expert.Prenom));
            _requete.Parameters.Add(new MySqlParameter("@adresse", expert.Adresse));
            _requete.Parameters.Add(new MySqlParameter("@ville", expert.Ville));
            _requete.Parameters.Add(new MySqlParameter("@codePostal", expert.CodePostal));
            _requete.Parameters.Add(new MySqlParameter("@telephone", expert.Telephone));
            _requete.Parameters.Add(new MySqlParameter("@mail", expert.Mail));
            _requete.Parameters.Add(new MySqlParameter("@numeroDossier", expert.NumeroDossier));
            _requete.Parameters.Add(new MySqlParameter("@id", expert.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }

        public void MettreAJourAssuranceDommageOuvrage(AssuranceDommageOuvrage assuranceDommageOuvrage)
        {
            _connexion.Open();
            _requete = new MySqlCommand("UPDATE AssuranceDommageOuvrage SET raisonSociale=@raisonSociale, adresse=@adresse, ville=@ville,  codePostal=@codePostal, numeroContrat=@numeroContrat, effetDu=@effetDu WHERE id=@id ", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@raisonSociale", assuranceDommageOuvrage.RaisonSociale));
            _requete.Parameters.Add(new MySqlParameter("@adresse", assuranceDommageOuvrage.Adresse));
            _requete.Parameters.Add(new MySqlParameter("@ville", assuranceDommageOuvrage.Ville));
            _requete.Parameters.Add(new MySqlParameter("@codePostal", assuranceDommageOuvrage.CodePostal));
            _requete.Parameters.Add(new MySqlParameter("@numeroContrat", assuranceDommageOuvrage.NumeroContrat));
            _requete.Parameters.Add(new MySqlParameter("@effetDu", assuranceDommageOuvrage.EffetDu));
            _requete.Parameters.Add(new MySqlParameter("@id", assuranceDommageOuvrage.Id));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }


        // ############################################################################################################## \\
        //                                       FONCTIONS (Resultat requete) -> Objet                                    \\
        // ############################################################################################################## \\
        //
        // Sinistre mission contrat dossier intervenant dossier
        //  - RechercherRepresentantParId(int) -> Representant
        //  -

        public Representant RechercherRepresentantParId(int id)
        {
            Representant representant;
            _connexion.Open();
            _requete = new MySqlCommand("SELECT * FROM Representant WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader dr = _requete.ExecuteReader();
            dr.Read();
            representant = new Representant(Convert.ToInt32(dr["id"]), dr["nom"].ToString() , dr["prenom"].ToString() , dr["telephone"].ToString() , dr["mail"].ToString() , dr["qualite"].ToString());

            _connexion.Close();
            return representant;
        }
        public Expert RechercherExpertParId(int id)
        {
            Expert expert;
            _connexion.Open();
            _requete = new MySqlCommand("SELECT * FROM Expert WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader dr = _requete.ExecuteReader();
            dr.Read();
            expert = new Expert(Convert.ToInt32(dr["id"]), dr["nom"].ToString(), dr["prenom"].ToString(), dr["adresse"].ToString(), dr["ville"].ToString(), dr["codePostal"].ToString(), dr["telephone"].ToString(), dr["mail"].ToString(), dr["numeroDossier"].ToString());

            _connexion.Close();
            return expert;
        }
        public EntrepriseRdf RechercherEntrepriseRdfParId(int id)
        {
            EntrepriseRdf entrepriseRdf;
            _connexion.Open();
            _requete = new MySqlCommand("SELECT * FROM EntrepriseRdf WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader dr = _requete.ExecuteReader();
            dr.Read();
            entrepriseRdf = new EntrepriseRdf(Convert.ToInt32(dr["id"]), dr["raisonSociale"].ToString(), dr["adresse"].ToString(), dr["ville"].ToString(), dr["codePostal"].ToString());

            _connexion.Close();
            return entrepriseRdf;
        }
        public AssuranceDommageOuvrage RechercherAssuranceDommageOuvrageParId(int id)
        {
            AssuranceDommageOuvrage assuranceDommageOuvrage;
            _connexion.Open();
            _requete = new MySqlCommand("SELECT * FROM AssuranceDommageOuvrage WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader dr = _requete.ExecuteReader();
            dr.Read();
            assuranceDommageOuvrage = new AssuranceDommageOuvrage(Convert.ToInt32(dr["id"]), dr["raisonSociale"].ToString(), dr["adresse"].ToString(), dr["ville"].ToString(), dr["codePostal"].ToString(), dr["numeroContrat"].ToString(), Convert.ToDateTime(dr["effetDu"]));

            _connexion.Close();
            return assuranceDommageOuvrage;
        }
        public Assureur RechercherAssureurParId(int id)
        {
            // Récupération de idRepresentant
            int idRepresentant;
            _connexion.Open();
            _requete = new MySqlCommand("SELECT idRepresentant FROM Assureur WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));
            idRepresentant = Convert.ToInt32(_requete.ExecuteScalar());
            _connexion.Close();

            // Création du représentant
            Representant representant = RechercherRepresentantParId(idRepresentant);

            // Création de l'assureur (passage du représentant en paramètre)
            Assureur assureur;
            _connexion.Open();
            _requete = new MySqlCommand("SELECT * FROM Assureur WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader dr = _requete.ExecuteReader();
            dr.Read();
            assureur = new Assureur(Convert.ToInt32(dr["id"]), dr["raisonSociale"].ToString(), dr["adresse"].ToString(), dr["ville"].ToString(), dr["codePostal"].ToString(), dr["telephone"].ToString(), dr["mail"].ToString(),representant);

            _connexion.Close();
            return assureur;
        }
        public Client RechercherClientParId(int id)
        {
            // Récupération de idClientExistant
            Client client;
            int idClientExistant;
            int idRepresentant;
            int idClient;
            _connexion.Open();
            _requete = new MySqlCommand("SELECT idClientExistant FROM Client WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));
            idClientExistant = Convert.ToInt32(_requete.ExecuteScalar());
            _connexion.Close();

            _connexion.Open();
            _requete = new MySqlCommand("SELECT idRepresentant FROM Client WHERE id=@id", _connexion);
            if (idClientExistant!=0)
            {
                // _requete.Parameters.Add(new MySqlParameter("@id", idClientExistant));
                idClient = idClientExistant;
            }
            else
            {
                // _requete.Parameters.Add(new MySqlParameter("@id", id));
                idClient = id;
            }
            _requete.Parameters.Add(new MySqlParameter("@id", idClient));
            idRepresentant = Convert.ToInt32(_requete.ExecuteScalar());
            _connexion.Close();

            Representant representant = RechercherRepresentantParId(idRepresentant);

            _connexion.Open();
            _requete = new MySqlCommand("SELECT * FROM Client WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", idClient));
            
           MySqlDataReader dr = _requete.ExecuteReader();
           dr.Read();
            client = new Client(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["idClientExistant"]), dr["nom"].ToString(), dr["prenom"].ToString(), dr["adresse"].ToString(), dr["ville"].ToString(), dr["codePostal"].ToString(), dr["telephone"].ToString(), dr["mail"].ToString(), dr["raisonSociale"].ToString(), dr["adresseSiegeSocial"].ToString(), dr["villeSiegeSocial"].ToString(), dr["codePostalSiegeSocial"].ToString(), dr["telephoneProfessionnel"].ToString(), representant);
           _connexion.Close();

            return client;
        }
        public Risque RechercherRisqueParId(int id)
        {
            Risque risque;
            AssuranceDommageOuvrage assuranceDommageOuvrage = RechercherAssuranceDommageOuvrageParId(id);
            _connexion.Open();
            _requete = new MySqlCommand("SELECT * FROM Risque WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader dr = _requete.ExecuteReader();
            dr.Read();
            risque = new Risque(Convert.ToInt32(dr["id"]), dr["type"].ToString(), dr["dateConstruction"].ToString(), Convert.ToInt32(dr["anneeConstruction"]), dr["typeMur"].ToString(), Convert.ToInt32(dr["anneeConstructionMur"]), dr["typeCouverture"].ToString(), Convert.ToInt32(dr["anneeConstructionCouverture"]), dr["utilite"].ToString(), Convert.ToBoolean(dr["batimentClasse"]), dr["etat"].ToString(), dr["piecePrincipaleAuContrat"].ToString(), dr["piecePrincipaleConstatee"].ToString(), dr["dependanceAuContrat"].ToString(), dr["dependanceConstatee"].ToString(), dr["details"].ToString(), Convert.ToBoolean(dr["conformite"]), dr["motif"].ToString(), dr["amiante"].ToString(), Convert.ToBoolean(dr["assuranceDommageOuvrage"]), assuranceDommageOuvrage);
            _connexion.Close();
            return risque;
        }
        public Compagnie RechercherCompagnieParId(int id)
        {
            Compagnie compagnie;
            _connexion.Open();
            _requete = new MySqlCommand("SELECT * FROM Compagnie WHERE id=@id", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader dr = _requete.ExecuteReader();
            dr.Read();
            compagnie = new Compagnie(Convert.ToInt32(dr["id"]), dr["raisonSociale"].ToString(), dr["adresse"].ToString(), dr["ville"].ToString(), dr["codePostal"].ToString());

            _connexion.Close();
            return compagnie;
        }

        // ############################################################################################################## \\
        //                                               PROCEDURES DIVERSES                                              \\
        // ############################################################################################################## \\
        //
        //  - SelectMaxId(string) -> int
        //  - RemplirComboBox(ComboBox , string) -> Void
        //  - AjouterValeurDansComboBoxItems(string , string) -> Void

        public int SelectMaxId(string table)
        {
            // Récupère l'ID le plus grand dans une table donnée.
            _connexion.Open();
            _requete = new MySqlCommand("SELECT MAX(id) FROM " + table, _connexion);
            int maxId = Convert.ToInt32(_requete.ExecuteScalar());
            _connexion.Close();
            return maxId;
        }

        public void RemplirComboBox(ComboBox cb, string categorie)
        {
            // Les libellés appartenants à la catégorie donnée sont ajoutés à la ComboBox passée en paramètre.
            // NB : Le bandeau déroulant de la ComboBox affiche au maximum 10 objets.
            _connexion.Open();
            _requete = new MySqlCommand("SELECT libelle FROM ComboBoxItems WHERE categorie=@categorie", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@categorie", categorie));

            cb.Items.Add("");
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.DropDownHeight = cb.ItemHeight * 10;

            MySqlDataReader dr = _requete.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr["libelle"]);
            }
            _connexion.Close();
        }

        public void AjouterValeurDansComboBoxItems(string categorie, string libelle)
        {
            _connexion.Open();
            _requete = new MySqlCommand("INSERT INTO ComboBoxItems(categorie,libelle) VALUES (@categorie,@libelle)", _connexion);
            _requete.Parameters.Add(new MySqlParameter("@categorie", categorie));
            _requete.Parameters.Add(new MySqlParameter("@libelle", libelle));
            _requete.ExecuteNonQuery();
            _connexion.Close();
        }


    }
}
