using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AGSE_Manager
{
    static class ConnexionBaseDeDonnees
    {
        static private string _connexionString;
        static private MySqlConnection _connexion;

        static ConnexionBaseDeDonnees()
        {
            try
            {
                _connexionString = "user=root;password=root;database=agse_manager;host=localhost;port=3307";
                _connexion = new MySqlConnection(_connexionString);
            }
            catch (Exception error)
            {
                // Console.WriteLine(error.ToString());
            }
        }

        static public MySqlConnection Connexion
        {
            get { return _connexion; }
        }

        static public string ConnexionString
        {
            get { return _connexionString; }
        }
    }
}
