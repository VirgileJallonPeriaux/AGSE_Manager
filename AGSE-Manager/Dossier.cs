using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Dossier
    {
        private int _id;
        private bool _estModifiable;
        private Mission _mission;
        private Contrat _contrat;
        private Sinistre _sinistre;
        private Risque _risque;
        private List<Intervenant> _listeIntervenants;

        public Dossier()
        {
            this._id = 0;
            this._estModifiable = true;
            this._mission = new Mission();
            this._contrat = new Contrat();
            this._sinistre = new Sinistre();
            this._risque = new Risque();
            this._listeIntervenants = new List<Intervenant>();
        }

        public Dossier(int id, Mission mission, Contrat contrat, Sinistre sinistre, Risque risque, bool estModifiable)
        {
            this._id = id;
            this._estModifiable = estModifiable;
            this._mission = mission;
            this._contrat = contrat;
            this._sinistre = sinistre;
            this._risque = risque;
        }

        public int Id { get { return this._id; } set { this._id = value; } }
        public bool EstModifiable { get { return this._estModifiable; } set { this._estModifiable = value; } }
        public Mission Mission { get { return this._mission; } set { this._mission = value; } }
        public Contrat Contrat { get { return this._contrat; } set { this._contrat = value; } }
        public Sinistre Sinistre { get { return this._sinistre; } set { this._sinistre = value; } }
        public Risque Risque { get { return this._risque; } set { this._risque = value; } }
        public List<Intervenant> ListeIntervenants { get { return this._listeIntervenants; } set { this._listeIntervenants = value; } }
    }
}
