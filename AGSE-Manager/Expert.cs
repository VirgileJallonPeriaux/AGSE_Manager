using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Expert
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _adresse;
        private string _ville;
        private string _codePostal;
        private string _telephone;
        private string _mail;
        private string _numeroDossier;

        public Expert()
        {
            this._id = 0;
            this._nom = "";
            this._prenom = "";
            this._adresse = "";
            this._ville = "";
            this._codePostal = "";
            this._telephone = "";
            this._mail = "";
            this._numeroDossier = "";
        }


        public Expert(int id, string nom, string prenom, string adresse, string ville, string codePostal, string telephone, string mail, string numeroDossier)
        {
            this._id = id;
            this._nom = nom;
            this._prenom = prenom;
            this._adresse = adresse;
            this._ville = ville;
            this._codePostal = codePostal;
            this._telephone = telephone;
            this._mail = mail;
            this._numeroDossier = numeroDossier;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nom { get { return this._nom; } set { this._nom = value; } }
        public string Prenom { get { return this._prenom; } set { this._prenom = value; } }
        public string Adresse { get { return this._adresse; } set { this._adresse = value; } }
        public string Ville { get { return this._ville; } set { this._ville = value; } }
        public string CodePostal { get { return this._codePostal; } set { this._codePostal = value; } }
        public string Telephone { get { return this._telephone; } set { this._telephone = value; } }
        public string Mail { get { return this._mail; } set { this._mail = value; } }
        public string NumeroDossier { get { return this._numeroDossier; } set { this._numeroDossier = value; } }
        public override string ToString()
        {
            return "ID : "+_id + "\nNom : " + _nom + "\nPrenom : " + _prenom + "\nAdresse : " + _adresse + "\nVille : " + _ville + "\nCodePostal : " + _codePostal + "\nTelephone : " + _telephone + "\nMail : " + _mail + "\nNumeroDossier : " + _numeroDossier;
        }

    }
}
