using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Representant
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _telephone;
        private string _mail;
        private string _qualite;

        public Representant()
        {
            this._id = 0;
            this._nom = "";
            this._prenom = "";
            this._telephone = "";
            this._mail = "";
            this._qualite = "";
        }

        public Representant(int id, string nom, string prenom, string telephone, string mail, string qualite)
        {
            this._id = id;
            this._nom = nom;
            this._prenom = prenom;
            this._telephone = telephone;
            this._mail = mail;
            this._qualite = qualite;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nom { get { return this._nom; } set { this._nom = value; } }
        public string Prenom { get { return this._prenom; } set { this._prenom = value; } }
        public string Telephone { get { return this._telephone; } set { this._telephone = value; } }
        public string Mail { get { return this._mail; } set { this._mail = value; } }
        public string Qualite { get { return this._qualite; } set { this._qualite = value; } }
        public override string ToString()
        {
            return "ID : "+_id + "\nNom : " + _nom + "\nPrenom : " + _prenom + "\nTelephone : " + _telephone + "\nMail : " + _mail + "\nQualite : " + _qualite;
        }
    }
}
