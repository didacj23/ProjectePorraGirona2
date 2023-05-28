using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.dades
{
    public class dbConnexio
    {
        private string connectionString = $"Server=localhost;Database=porragirona;Uid=root;Pwd=''";

        protected MySqlConnection conn;

        /// <summary>
        /// Crea una instància de l'objecte conn de la classe MySqlConnection i obre la connexio amb la base de dades amb la connectionString.
        /// </summary>
        protected void ConnectarBD()
        {
            conn = new MySqlConnection(connectionString);

            conn.Open();
        }

        /// <summary>
        /// Tanca la connexió amb la base de dades.
        /// </summary>
        protected void DesconnectarBD()
        {
            conn.Close();
        }
    }
}
