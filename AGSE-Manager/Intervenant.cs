using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Intervenant
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _adresse;
        private string _ville;
        private string _codePostal;
        private string _telephone;
        private string _mail;
        private bool _statut;
        private bool _presence;
        private string _qualite;
        private string _typeLieu;
        private string _utilite;
        private string _etat;
        private string _etage;
        private string _remarque;
        private string _numeroContrat;
        private string _numeroSinistre;
        private Representant _representant;
        private Compagnie _compagnie;
        private Assureur _assureur;
        private Expert _expert;
        private int _idDossier;

        public Intervenant()
        {
            this._id = 0;
            this._nom = "";
            this._prenom = "";
            this._adresse = "";
            this._ville = "";
            this._codePostal = "";
            this._telephone = "";
            this._mail = "";
            this._statut = true;
            this._presence = true;
            this._qualite = "";
            this._typeLieu = "";
            this._utilite = "";
            this._etat = "";
            this._etage = "";
            this._remarque = "";
            this._numeroContrat = "";
            this._numeroSinistre = "";
            this._representant = new Representant();
            this._compagnie = new Compagnie();
            this._assureur = new Assureur();
            this._expert = new Expert();
            // this._idDossier = 0;
        }

        public Intervenant(int id, Dossier dossier, string nom, string prenom, string adresse, string ville, string codePostal, string telephone, string mail, bool statut, bool presence, string qualite, string typeLieu, string utilite, string etat, string etage, string remarque, string numeroContrat, string numeroSinistre, Representant representant, Compagnie compagnie, Assureur assureur, Expert expert, int idDossier)
        {
            this._id = id;
            this._nom = nom;
            this._prenom = prenom;
            this._adresse = adresse;
            this._ville = ville;
            this._codePostal = codePostal;
            this._telephone = telephone;
            this._mail = mail;
            this._statut = statut;
            this._presence = presence;
            this._qualite = qualite;
            this._typeLieu = typeLieu;
            this._utilite = utilite;
            this._etat = etat;
            this._etage = etage;
            this._remarque = remarque;
            this._numeroContrat = numeroContrat;
            this._numeroSinistre = numeroSinistre;
            this._representant = representant;
            this._compagnie = compagnie;
            this._assureur = assureur;
            this._expert = expert;
            this._idDossier = idDossier;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nom { get { return this._nom; } set { this._nom = value; } }
        public string Prenom { get { return this._prenom; } set { this._prenom = value; } }
        public string Adresse { get { return this._adresse; } set { this._adresse = value; } }
        public string Ville { get { return this._ville; } set { this._ville = value; } }
        public string CodePostal { get { return this._codePostal; } set { this._codePostal = value; } }
        public string Telephone { get { return this._telephone; } set { this._telephone = value; } }
        public string Mail { get { return this._mail; } set { this._mail = value; } }
        public bool Statut { get { return this._statut; } set { this._statut = value; } }
        public bool Presence { get { return this._presence; } set { this._presence = value; } }
        public string Qualite { get { return this._qualite; } set { this._qualite = value; } }
        public string TypeLieu { get { return this._typeLieu; } set { this._typeLieu = value; } }
        public string Utilite { get { return this._utilite; } set { this._utilite = value; } }
        public string Etat { get { return this._etat; } set { this._etat = value; } }
        public string Etage { get { return this._etage; } set { this._etage = value; } }
        public string Remarque { get { return this._remarque; } set { this._remarque = value; } }
        public string NumeroContrat { get { return this._numeroContrat; } set { this._numeroContrat = value; } }
        public string NumeroSinistre { get { return this._numeroSinistre; } set { this._numeroSinistre = value; } }

        public Representant Representant { get { return this._representant; } set { this._representant = value; } }
        public Compagnie Compagnie { get { return this._compagnie; } set { this._compagnie = value; } }
        public Assureur Assureur { get { return this._assureur; } set { this._assureur = value; } }
        public Expert Expert { get { return this._expert; } set { this._expert = value; } }
        public int IdDossier { get { return this._idDossier; } set { this._idDossier = value; } }
    }
}
