using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSE_Manager
{
    public class Mission
    {
        private int _id;
        private DateTime _dateReception;
        private DateTime _dateConfirmationReception;
        private string _moyenMissionnement;
        private Client _client;
        // private Representant _representant;

        public Mission()
        {
            this._id = 0;
            this._moyenMissionnement = "";
            //
            this._client = new Client();
            // this._representant = new Representant();
        }

        public Mission(int id, DateTime dateReception, DateTime dateConfirmationReception, string moyenMissionnement, Client client)
        {
            this._id = id;
            this._moyenMissionnement = moyenMissionnement;
            this._dateReception = dateReception;
            this._dateConfirmationReception = dateConfirmationReception;
            this._client = client;
            // this._representant = representant;
        }


        public int Id { get { return this._id; } set { this._id = value; } }
        public string MoyenMissionnement { get { return this._moyenMissionnement; } set { this._moyenMissionnement = value; } }
        public DateTime DateReception { get { return this._dateReception; } set { this._dateReception = value; } }
        public DateTime DateConfirmationReception { get { return this._dateConfirmationReception; } set { this._dateConfirmationReception = value; } }
        public Client Client { get { return this._client; } set { this._client = value; } }
        // public Representant Representant { get { return this._representant; } set { this._representant = value; } }
    }
}
