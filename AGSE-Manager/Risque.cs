using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Risque
    {
        private int _id;
        private string _type;
        private string _dateConstruction;
        private int _anneeConstruction;
        private string _typeMur;
        private int _anneeConstructionMur;
        private string _typeCouverture;
        private int _anneeConstructionCouverture;
        private string _utilite;
        private bool _batimentClasse;
        private string _etat;
        private string _piecePrincipaleAuContrat;
        private string _piecePrincipaleConstatee;
        private string _dependanceAuContrat;
        private string _dependanceConstatee;
        private string _details;
        private bool _conformite;
        private string _motif;
        private string _amiante;
        private bool _assuranceDommageOuvrageSouscrite;
        private AssuranceDommageOuvrage _assuranceDommageOuvrage;

        public Risque()
        {
            this._id = 0;
            this._type = "";
            this._dateConstruction = "";
            this._anneeConstruction = 0;
            this._typeMur = "";
            this._anneeConstructionMur = 0;
            this._typeCouverture = "";
            this._anneeConstructionCouverture = 0;
            this._utilite = "";
            this._batimentClasse = true;
            this._etat = "";
            this._piecePrincipaleAuContrat = "";
            this._piecePrincipaleConstatee = "";
            this._dependanceAuContrat = "";
            this._dependanceConstatee = "";
            this._details = "";
            this._conformite = true;
            this._motif = "";
            this._amiante = "";
            this._assuranceDommageOuvrageSouscrite = true;
            this._assuranceDommageOuvrage = new AssuranceDommageOuvrage();
        }

        public Risque(int id, string type, string dateConstruction, int anneeConstruction, string typeMur, int anneeConstructionMur, string typeCouverture, int anneeConstructionCouverture, string utilite, bool batimentClasse, string etat, string piecePrincipaleAuContrat, string piecePrincipaleConstatee, string dependanceAuContrat, string dependanceConstatee, string details, bool conformite, string motif, string amiante, bool assuranceDommageOuvrageSouscrite, AssuranceDommageOuvrage assuranceDommageOuvrage)
        {
            this._id = id;
            this._type = type;
            this._dateConstruction = dateConstruction;
            this._anneeConstruction = anneeConstruction;
            this._typeMur = typeMur;
            this._anneeConstructionMur = anneeConstructionMur;
            this._typeCouverture = typeCouverture;
            this._anneeConstructionCouverture = anneeConstructionCouverture;
            this._utilite = utilite;
            this._batimentClasse = batimentClasse;
            this._etat = etat;
            this._piecePrincipaleAuContrat = piecePrincipaleAuContrat;
            this._piecePrincipaleConstatee = piecePrincipaleConstatee;
            this._dependanceAuContrat = dependanceAuContrat;
            this._dependanceConstatee = dependanceConstatee;
            this._details = details;
            this._conformite = conformite;
            this._motif = motif;
            this._amiante = amiante;
            this._assuranceDommageOuvrageSouscrite = assuranceDommageOuvrageSouscrite;
            this._assuranceDommageOuvrage = assuranceDommageOuvrage;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Type { get { return this._type; } set { this._type = value; } }
        public string DateConstruction { get { return this._dateConstruction; } set { this._dateConstruction = value; } }
        public int AnneeConstruction { get { return this._anneeConstruction; } set { this._anneeConstruction = value; } }

        public string TypeMur { get { return this._typeMur; } set { this._typeMur = value; } }
        public int AnneeConstructionMur { get { return this._anneeConstructionMur; } set { this._anneeConstructionMur = value; } }
        public string TypeCouverture { get { return this._typeCouverture; } set { this._typeCouverture = value; } }
        public int AnneeConstructionCouverture { get { return this._anneeConstructionCouverture; } set { this._anneeConstructionCouverture = value; } }

        public string Utilite { get { return this._utilite; } set { this._utilite = value; } }
        public bool BatimentClasse { get { return this._batimentClasse; } set { this._batimentClasse = value; } }
        public string Etat { get { return this._etat; } set { this._etat = value; } }
        public string PiecePrincipaleAuContrat { get { return this._piecePrincipaleAuContrat; } set { this._piecePrincipaleAuContrat = value; } }
        public string PiecePrincipaleConstatee { get { return this._piecePrincipaleConstatee; } set { this._piecePrincipaleConstatee = value; } }
        public string DependanceAuContrat { get { return this._dependanceAuContrat; } set { this._dependanceAuContrat = value; } }
        public string DependanceConstatee { get { return this._dependanceConstatee; } set { this._dependanceConstatee = value; } }
        public string Details { get { return this._details; } set { this._details = value; } }
        public bool Conformite { get { return this._conformite; } set { this._conformite = value; } }
        public string Motif { get { return this._motif; } set { this._motif = value; } }
        public string Amiante { get { return this._amiante; } set { this._amiante = value; } }
        public bool AssuranceDommageOuvrageSouscrite { get { return this._assuranceDommageOuvrageSouscrite; } set { this._assuranceDommageOuvrageSouscrite = value; } }
        public AssuranceDommageOuvrage AssuranceDommageOuvrage { get { return this._assuranceDommageOuvrage; } set { this._assuranceDommageOuvrage = value; } }

        public override string ToString()
        {
            return "ID : " + _id + "\nType : " + _type + "\nDateConstruction : " + _dateConstruction + "\nAnneeConstruction : " + _anneeConstruction
                + "\nTypeMur : " + _typeMur + "\nAnneeConstructionMur : " + _anneeConstructionMur + "\nTypeCouverture : " + _typeCouverture
                + "\nAnneeConstructionCouverture : " + _anneeConstructionCouverture + "\nUtilite : " + _utilite + "\nBatimentClasse : " + _batimentClasse
                + "\nEtat : " + _etat + "\nPiecePrincipaleAuContrat : " + _piecePrincipaleAuContrat + "\nPiecePrincipaleConstatee : "+ _piecePrincipaleConstatee
                + "\nDependanceAuContrat : " + _dependanceAuContrat + "\nDependanceConstatee : " + _dependanceConstatee
                +"\nDetails : " + _details + "\nConformite : " + _conformite + "\nMotif : " + _motif + "\nAmiante : " + _amiante
                + "\nAssuranceDommageOuvrageSouscrite : " + _assuranceDommageOuvrageSouscrite + "\nAssuranceDommageOuvrageID : " + _assuranceDommageOuvrage.Id;
        }
    }
}
