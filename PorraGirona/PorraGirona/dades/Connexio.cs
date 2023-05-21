using MySqlConnector;
using PorraGirona.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PorraGirona.dades
{
    class Connexio
    {
        private string connectionString;
        
        public Connexio(string servidor, string basedades, string usuari, string contrasenya)
        {
            connectionString=$"Server={servidor};Database={basedades};Uid={usuari};Pwd={contrasenya}";
        }

        public void InsertarUsuari(Usuari u/*string dni, string contrasenya, string nom, string cognom, int puntsAcumulats*/)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO usuaris(dni, contrasenya, nom, cognom, puntsAcumulats, administrador) values (@dni, @contrasenya, @nom, @cognom, @puntsAcumulats, @administrador)";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@dni", u.Dni);
                    command.Parameters.AddWithValue("@contrasenya", u.Contrasenya);
                    command.Parameters.AddWithValue("@nom", u.Nom);
                    command.Parameters.AddWithValue("@cognom", u.Cognom);
                    command.Parameters.AddWithValue("@puntsAcumulats", u.PuntsAcumulats);

                    //command.Parameters.AddWithValue("@administrador", administrador);

                    command.ExecuteNonQuery();

                }              
                                
                conn.Close(); //el using la tanca automaticament xo wno
            }
        }

        public bool IniciarSessió(Sessio s)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT dni, contrasenya FROM usuaris WHERE dni='{s.Dni}'";

                using (MySqlCommand command = new MySqlCommand( query, conn))
                {
                    using (MySqlDataReader reader  = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            string contrasenyaCorrecta = reader.GetString("contrasenya");

                            if (contrasenyaCorrecta == s.Pass) //si la contrasenya es correcta
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            conn.Close();
                            return false;
                        }

                        
                    }
                }
            }

        }

        public Usuari BuscarUsuari(Usuari u1)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT dni FROM usuaris WHERE dni='{u1.Dni}'";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Usuari u2 = new Usuari();
                        if (reader.Read())
                        {
                            //obtenir dades de la bd
                            string dni = reader.GetString("dni");
                            string nom = reader.GetString("nom");
                            string cognom = reader.GetString("cognom");
                            string contrasenya = reader.GetString("contrasenya");
                            int puntsAcumulats = reader.GetInt32("puntsAcumulats");

                            u2.Nom=nom;
                            u2.Cognom=cognom;
                            u2.Dni=dni;
                            u2.Contrasenya=contrasenya;
                            u2.PuntsAcumulats=puntsAcumulats;                               
                           
                        }
                        
                        return u2;
                    }
                }
        }

        /*
        public void Connectar()
        {
            MySqlConnection c = null;

            try
            {
                c = new MySqlConnection(connectionString);
                c.Open();
                MessageBox.Show("Connexió OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obrir la base de dades. \n"+ex.Message);
            }
            //finally

        }*/

        /*
        public LlistaPartits ObtenirPartits()
        {
            LlistaPartits ls = new LlistaPartits();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM PARTITS";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int id_partit = reader.GetInt32("id_partit");
                    string equip_A = reader.GetString("equip_A");
                    string equip_B = reader.GetString("equip_B");
                    int gols_equip_A = reader.GetInt32("gols_equip_A");
                    int gols_equip_B = reader.GetInt32("gols_equip_B");
                    DateTime dia_hora = reader.GetDateTime("dia_hora");
                    string temporada = reader.GetString("temporada");
                    string camp = reader.GetString("camp");
                    string estat = reader.GetString("estat");

                    Partit p = new Partit(equip_A, equip_B, dia_hora, temporada, camp, estat);
                }
            }

            
        }*/

        /*
        public Equip ObtenirEquip(string nom_equip)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = $"SELECT * FROM EQUIPS WHERE nom_equip = {nom_equip}";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {                    
                    string nom_equip = reader.GetString("nom_equip");
                    string camp = reader.GetString("camp");
                    string foto = reader.GetString("foto");
                    string categoria = reader.GetString("categoria");
                    int total_partits = reader.GetInt32("total_partits");
                    int total_partits_guanyats = reader.GetInt32("total_partits_guanyats");
                    int total_partits_perduts = reader.GetInt32("total_partits_perduts");
                    int total_partits_empatats = reader.GetInt32("total_partits_empatats");

                    Equip e = new Equip(nom_equip, camp, foto, categoria,)
                }

            }
        }      */
        
        /*
        public Jugador ObtenirJugador(string dni_entrant)
        {
            using (MySqlConnection  conn = new MySqlConnection(connectionString))
            {
                string query = $"SELECT * FROM JUGADORS WHERE dni = {dni_entrant}";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string dni = reader.GetString("dni");
                    string nom = reader.GetString("nom");
                    string cognom = reader.GetString("cognom");
                    string nom_equip = reader.GetString("nom_equip");
                    string posicio = reader.GetString("posicio");
                    int numero = reader.GetInt32("numero");

                    Jugador j = new Jugador(dni, nom, cognom, )
                }
            }
        }*/

    }
}
