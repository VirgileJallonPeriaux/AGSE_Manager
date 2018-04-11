using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Assureur
    {
        private int _id;
        private string _raisonSociale;
        private string _adresse;
        private string _ville;
        private string _codePostal;
        private string _telephone;
        private string _mail;
        private Representant _representant;

        public Assureur()
        {
            this._id = 0;
            this._raisonSociale = "";
            this._adresse = "";
            this._ville = "";
            this._codePostal = "";
            this._telephone = "";
            this._mail = "";
            this._representant = new Representant();
        }

        public Assureur(int id, string raisonSociale, string adresse, string ville, string codePostal, string telephone, string mail, Representant representant)
        {
            this._id = id;
            this._raisonSociale = raisonSociale;
            this._adresse = adresse;
            this._ville = ville;
            this._codePostal = codePostal;
            this._telephone = telephone;
            this._mail = mail;
            this._representant = representant;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string RaisonSociale { get { return this._raisonSociale; } set { this._raisonSociale = value; } }
        public string Adresse { get { return this._adresse; } set { this._adresse = value; } }
        public string Ville { get { return this._ville; } set { this._ville = value; } }
        public string CodePostal { get { return this._codePostal; } set { this._codePostal = value; } }
        public string Telephone { get { return this._telephone; } set { this._telephone = value; } }
        public string Mail { get { return this._mail; } set { this._mail = value; } }
        public Representant Representant { get { return this._representant; } set { this._representant = value; } }

        public override string ToString()
        {
            return "ID : " + _id + "\nRaisonSociale : " + _raisonSociale + "\nAdresse : " + _adresse + "\nVille : " + _ville + "\nCodePostal : " + _codePostal + "\nTelephone : " + _telephone + "\nMail : " + _mail+"\nID Representant : "+_representant.Id;
           
        }
    }
}
