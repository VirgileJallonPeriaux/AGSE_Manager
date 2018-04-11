using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class AssuranceDommageOuvrage
    {
        private int _id;
        private string _raisonSociale;
        private string _adresse;
        private string _ville;
        private string _codePostal;
        private string _numeroContrat;
        private DateTime _effetDu;

        public AssuranceDommageOuvrage()
        {
            this._id = 0;
            this._raisonSociale = "";
            this._adresse = "";
            this._ville = "";
            this._codePostal = "";
            this._numeroContrat = "";
        }

        public AssuranceDommageOuvrage(int id, string raisonSociale, string adresse, string ville, string codePostal, string numeroContrat, DateTime effetDu)
        {
            this._id = id;
            this._raisonSociale = raisonSociale;
            this._adresse = adresse;
            this._ville = ville;
            this._codePostal = codePostal;
            this._numeroContrat = numeroContrat;
            this._effetDu = effetDu;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string RaisonSociale { get { return this._raisonSociale; } set { this._raisonSociale = value; } }
        public string Adresse { get { return this._adresse; } set { this._adresse = value; } }
        public string Ville { get { return this._ville; } set { this._ville = value; } }
        public string CodePostal { get { return this._codePostal; } set { this._codePostal = value; } }
        public string NumeroContrat { get { return this._numeroContrat; } set { this._numeroContrat = value; } }
        public DateTime EffetDu { get { return this._effetDu; } set { this._effetDu = value; } }
        public override string ToString()
        {
            return "ID : " + _id + "\nRaisonSociale : " + _raisonSociale + "\nAdresse : " + _adresse + "\nVille : " + _ville + "\nCodePostal : " + _codePostal + "\nNumeroContrat : " + _numeroContrat + "\nEffetDu : " + _effetDu;
        }
    }
}
