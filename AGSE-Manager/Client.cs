using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Client
    {
        private int _id;
        private int _idClientExistant;
        private string _nom;
        private string _prenom;
        private string _adresse;
        private string _ville;
        private string _codePostal;
        private string _telephone;
        private string _mail;

        private string _raisonSociale;
        private string _adresseSiegeSocial;
        private string _villeSiegeSocial;
        private string _codePostalSiegeSocial;
        private string _telephoneProfessionnel;
        private Representant _representant;

        public Client()
        {
            this._id = 0;
            this._idClientExistant = 0;
            this._nom = "";
            this._prenom = "";
            this._adresse = "";
            this._ville = "";
            this._codePostal = "";
            this._telephone = "";
            this._mail = "";
            this._raisonSociale = "";
            this._adresseSiegeSocial = "";
            this._villeSiegeSocial = "";
            this._codePostalSiegeSocial = "";
            this._telephoneProfessionnel = "";
            this._representant = new Representant();
        }

        public Client(int id, int idClientExistant, string nom, string prenom, string adresse, string ville, string codePostal, string telephone, string mail, string raisonSociale, string adresseSiegeSocial, string villeSiegeSocial, string codePostalSiegeSocial, string telephoneClientPro, Representant representant)
        {
            this._id = id;
            this._idClientExistant = idClientExistant;
            this._nom = nom;
            this._prenom = prenom;
            this._adresse = adresse;
            this._ville = ville;
            this._codePostal = codePostal;
            this._telephone = telephone;
            this._mail = mail;
            this._raisonSociale = raisonSociale;
            this._adresseSiegeSocial = adresseSiegeSocial;
            this._villeSiegeSocial = villeSiegeSocial;
            this._codePostalSiegeSocial = codePostalSiegeSocial;
            this._telephoneProfessionnel = telephoneClientPro;
            this._representant = representant;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public int IdClientExistant { get { return _idClientExistant; } set { _idClientExistant = value; } }
        public string Nom { get { return _nom; } set { _nom = value; } }
        public string Prenom { get { return _prenom; } set { _prenom = value; } }
        public string Adresse { get { return _adresse; } set { _adresse = value; } }
        public string Ville { get { return _ville; } set { _ville = value; } }
        public string CodePostal { get { return _codePostal; } set { _codePostal = value; } }
        public string Telephone { get { return _telephone; } set { _telephone = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public string RaisonSociale { get { return _raisonSociale; } set { _raisonSociale = value; } }
        public string AdresseSiegeSocial { get { return _adresseSiegeSocial; } set { _adresseSiegeSocial = value; } }
        public string VilleSiegeSocial { get { return _villeSiegeSocial; } set { _villeSiegeSocial = value; } }
        public string CodePostalSiegeSocial { get { return _codePostalSiegeSocial; } set { _codePostalSiegeSocial = value; } }
        public string TelephoneProfessionnel { get { return _telephoneProfessionnel; } set { _telephoneProfessionnel = value; } }
        public Representant Representant { get { return _representant; } set { _representant = value; } }

        public override string ToString()
        {
            return "ID : "+_id+"\nID Client existant : "+_idClientExistant+"\nNom : "+_nom+"\nPrenom : "+_prenom+"\nAdresse : "+_adresse+"\nVille : "+_ville+"\nCodePostal : "+_codePostal+"\nTelephone : "+_telephone+"\nMail : "+_mail+"\nRaisonSociale : "+_raisonSociale+"\nAdresse SS : "+_adresseSiegeSocial+"\nVille SS : "+_villeSiegeSocial+"\nCodePostal SS : "+_codePostalSiegeSocial+"\nTelephonePro : "+_telephoneProfessionnel+"\nID Representant : "+_representant.Id;
        }

    }
}