using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Sinistre
    {
        private int _id;
        private string _type;
        private string _adresse;
        private string _ville;
        private string _codePostal;
        private DateTime _dateSurvenance;
        private string _causesEtCirconstances;
        private string _origine;
        private string _rdf;
        private string _origineSinistre;
        private EntrepriseRdf _entrepriseRdf;

        public Sinistre()
        {
            this._id = 0;
            this._type = "";
            this._adresse = "";
            this._ville = "";
            this._codePostal = "";
            //
            this._causesEtCirconstances = "";
            this._origine = "";
            this._rdf = "";
            this._origineSinistre = "";
            this._entrepriseRdf = new EntrepriseRdf();
        }

        public Sinistre(int id, string type, string adresse, string ville, string codePostal, DateTime dateSurvenance, string causesEtCirconstances, string origine, string rdf, string origineSinistre, EntrepriseRdf entrepriseRdf)
        {
            this._id = id;
            this._type = type;
            this._adresse = adresse;
            this._ville = ville;
            this._codePostal = codePostal;
            this._dateSurvenance = dateSurvenance;
            this._causesEtCirconstances = causesEtCirconstances;
            this._origine = origine;
            this._rdf = rdf;
            this._origineSinistre = origine;
            this._entrepriseRdf = entrepriseRdf;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Type { get { return this._type; } set { this._type = value; } }
        public string Adresse { get { return this._adresse; } set { this._adresse = value; } }
        public string Ville { get { return this._ville; } set { this._ville = value; } }
        public string CodePostal { get { return this._codePostal; } set { this._codePostal = value; } }
        public DateTime DateSurvenance { get { return this._dateSurvenance; } set { this._dateSurvenance = value; } }
        public string CausesEtCirconstances { get { return this._causesEtCirconstances; } set { this._causesEtCirconstances = value; } }
        public string Origine { get { return this._origine; } set { this._origine = value; } }
        public string Rdf { get { return this._rdf; } set { this._rdf = value; } }
        public string OrigineSinistre { get { return this._origineSinistre; } set { this._origineSinistre = value; } }
        public EntrepriseRdf EntrepriseRdf { get { return this._entrepriseRdf; } set { this._entrepriseRdf = value; } }

    }
}
