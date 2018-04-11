using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Contrat
    {
        private int _id;
        private string _type;
        private string _formule;
        private DateTime _effetDu;
        private string _numeroContrat;
        private string _numeroCg;
        private string _intercalaire;
        private double _franchise;
        private string _detailFranchise;
        private double _indiceSouscription;
        private double _indiceIndemnisation;
        private string _optionUn;
        private string _optionDeux;
        private string _optionTrois;
        private string _detailOptionUn;
        private string _detailOptionDeux;
        private string _detailOptionTrois;
        private Compagnie _compagnie;
        private Assureur _assureur;
        // private Representant _representant;

        public Contrat()
        {
            this._id = 0;
            this._type = "";
            this._formule = "";
            //
            this._numeroContrat = "";
            this._numeroCg = "";
            this._intercalaire = "";
            // this._franchise = 0.0;
            this._detailFranchise = "";
            // this._indiceSouscription = 0.0;
            // this._indiceIndemnisation = 0.0;
            this._optionUn = "";
            this._optionDeux = "";
            this._optionTrois = "";
            this._detailOptionUn = "";
            this._detailOptionDeux = "";
            this._detailOptionTrois = "";
            this._compagnie = new Compagnie();
            this._assureur = new Assureur();
           //  this._representant = new Representant();
        }

        // public Contrat(int id, string type, string formule, DateTime effetDu, string numeroContrat, string numeroCg, string intercalaire, double franchise, string detailFranchise, double indiceSouscription, double indiceIndemnisation, string optionUn, string optionDeux, string optionTrois, string detailOptionUn, string detailOptionDeux, string detailOptionTrois, Compagnie compagnie, Assureur assureur, Representant representant)
        public Contrat(int id, string type, string formule, DateTime effetDu, string numeroContrat, string numeroCg, string intercalaire, double franchise, string detailFranchise, double indiceSouscription, double indiceIndemnisation, string optionUn, string optionDeux, string optionTrois, string detailOptionUn, string detailOptionDeux, string detailOptionTrois, Compagnie compagnie, Assureur assureur)
        {
            this._id = id;
            this._type = type;
            this._formule = formule;
            this._effetDu = effetDu;
            this._numeroContrat = numeroContrat;
            this._numeroCg = numeroCg;
            this._intercalaire = intercalaire;
            this._franchise = franchise;
            this._detailFranchise = detailFranchise;
            this._indiceSouscription = indiceSouscription;
            this._indiceIndemnisation = indiceIndemnisation;
            this._optionUn = optionUn;
            this._optionDeux = optionDeux;
            this._optionTrois = optionTrois;
            this._detailOptionUn = detailOptionUn;
            this._detailOptionDeux = detailOptionDeux;
            this._detailOptionTrois = detailOptionTrois;
            this._compagnie = compagnie;
            this._assureur = assureur;
            // this._representant = representant;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Type { get { return this._type; } set { this._type = value; } }
        public string Formule { get { return this._formule; } set { this._formule = value; } }
        public DateTime EffetDu { get { return this._effetDu; } set { this._effetDu = value; } }
        public string NumeroContrat { get { return this._numeroContrat; } set { this._numeroContrat = value; } }
        public string NumeroCg { get { return this._numeroCg; } set { this._numeroCg = value; } }
        public string Intercalaire { get { return this._intercalaire; } set { this._intercalaire = value; } }
        public double Franchise { get { return this._franchise; } set { this._franchise = value; } }
        public string DetailFranchise { get { return this._detailFranchise; } set { this._detailFranchise = value; } }
        public double IndiceSouscription { get { return this._indiceSouscription; } set { this._indiceSouscription = value; } }
        public double IndiceIndemnisation { get { return this._indiceIndemnisation; } set { this._indiceIndemnisation = value; } }
        public string OptionUn { get { return this._optionUn; } set { this._optionUn = value; } }
        public string OptionDeux { get { return this._optionDeux; } set { this._optionDeux = value; } }
        public string OptionTrois { get { return this._optionTrois; } set { this._optionTrois = value; } }
        public string DetailOptionUn { get { return this._detailOptionUn; } set { this._detailOptionUn = value; } }
        public string DetailOptionDeux { get { return this._detailOptionDeux; } set { this._detailOptionDeux = value; } }
        public string DetailOptionTrois { get { return this._detailOptionTrois; } set { this._detailOptionTrois = value; } }
        public Compagnie Compagnie { get { return this._compagnie; } set { this._compagnie = value; } }
        public Assureur Assureur { get { return this._assureur; } set { this._assureur = value; } }
        //public Representant Representant { get { return this._representant; } set { this._representant = value; } }
    }
}
