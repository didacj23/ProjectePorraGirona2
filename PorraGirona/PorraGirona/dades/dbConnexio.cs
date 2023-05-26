using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.dades
{
    internal class dbConnexio
    {
        private string connectionString = $"Server=localhost;Database=porragirona;Uid=root;Pwd=''";

        protected MySqlConnection conn;

        protected void ConnectarBD()
        {
            conn = new MySqlConnection(connectionString);

            conn.Open();
        }

        protected void DesconnectarBD()
        {
            conn.Close();
        }
    }
}
