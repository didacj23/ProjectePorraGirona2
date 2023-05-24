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

        public bool IniciarSessió(Sessio s)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT dni, contrasenya FROM usuaris WHERE dni='{s.Dni}'";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
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

        public void InsertarUsuari(Usuari u)
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

                    //si es usuari, admin=0, si es admin, admin=1
                    int admin = 0;
                    if(u is Administrador) admin=1;

                    command.Parameters.AddWithValue("@administrador", admin);


                    command.ExecuteNonQuery();

                }              
                                
                conn.Close(); //el using la tanca automaticament xo wno
            }
        }        

        public Usuari BuscarUsuari(Usuari u1)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT dni FROM usuaris WHERE dni='{u1.Dni}'";

                Usuari u2 = new Usuari();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        
                        if (reader.Read())
                        {
                            int administrador = reader.GetInt32("administrador");

                            string dni = reader.GetString("dni");
                            string nom = reader.GetString("nom");
                            string cognom = reader.GetString("cognom");
                            string contrasenya = reader.GetString("contrasenya");
                            int puntsAcumulats = reader.GetInt32("puntsAcumulats");
                                                        
                            if (administrador == 0)
                            {
                                u2 = new Usuari(dni, contrasenya, nom, cognom, puntsAcumulats);
                            }
                            else
                            {
                                u2 = new Administrador(dni, contrasenya, nom, cognom, puntsAcumulats);
                            }

                        }

                        
                    }
                }
                return u2;

                conn.Close();
            }
        }

        //public bool EliminarUsuari(string dni)

        public void InsertarEquip(Equip e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO equips(nom_equip, camp, foto, categoria, total_partits_guanyats, total_partits_perduts, total_partits_empatats) values (@nom_equip, @camp, @foto, @categoria, @total_partits_guanyats, @total_partits_perduts, @total_partits_empatats)";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@nom_equip",e.Nom);
                    command.Parameters.AddWithValue("@camp", e.Camp);
                    command.Parameters.AddWithValue("@foto", e.Foto);
                    command.Parameters.AddWithValue("@total_partits_guanyats", e.TotalPartitsGuanyats);
                    command.Parameters.AddWithValue("@total_partits_perduts", e.TotalPartitsPerduts);
                    command.Parameters.AddWithValue("@total_partits_empatats", e.TotalPartitsEmpatats);

                    command.ExecuteNonQuery();

                }

                conn.Close(); //el using la tanca automaticament xo wno
            }
        }

        //public bool EliminarEquip(string nom_equip)

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
        public Equip ObtenirEquip(string nom_equip)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT * FROM EQUIPS WHERE nom_equip = {nom_equip}";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Equip e = new Equip();
                        if(reader.Read())
                        {
                            string nom_equip_bd = reader.GetString("nom_equip");
                            string camp = reader.GetString("camp");
                            string foto = reader.GetString("foto");
                            int total_partits_guanyats = reader.GetInt32("total_partits_guanyats");
                            int total_partits_perduts = reader.GetInt32("total_partits_perduts");
                            int total_partits_empatats = reader.GetInt32("total_partits_empatats");

                            e.Nom=nom_equip_bd;
                            e.Camp=camp;
                            e.Foto=foto;
                            e.TotalPartitsGuanyats = total_partits_guanyats;
                            e.TotalPartitsPerduts=total_partits_perduts;
                            e.TotalPartitsEmpatats = total_partits_empatats;
                        }

                        return e;                        

                    }
                }

                conn.Close();

            }
        }           
        
        public void InsertarPartit(Partit p)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO partits(id_partit, equip_A, equip_B, gols_equip_A, gols_equip_B, dia_hora, temporada, camp, estat) values (@id_partit, @equip_A, @equip_B, @gols_equip_A, @gols_equip_B, @dia_hora, @temporada, @camp, @estat)";


                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id_partit", p.IdPartit);
                    command.Parameters.AddWithValue("@equip_A", p.EquipA.Nom);
                    command.Parameters.AddWithValue("@equip_A", p.EquipB.Nom);
                    command.Parameters.AddWithValue("@gols_equip_A", p.GolsEquipA);
                    command.Parameters.AddWithValue("@gols_equip_B", p.GolsEquipB);
                    command.Parameters.AddWithValue("@dia_hora", p.DiaHora);
                    command.Parameters.AddWithValue("@camp", p.Camp);
                    command.Parameters.AddWithValue("@estat", p.Estat);

                    command.ExecuteNonQuery();

                }

                conn.Close(); //el using la tanca automaticament xo wno
            }
        }

        public void InsertarPronostic(Pronostic pr)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO pronostics(id_pronostic, dni_usuari, id_partit, gols_equip_a, gols_equip_b) values (@id_pronostic, @dni_usuari, @id_partit, @gols_equip_A, @gols_equip_B)";


                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id_pronostic", pr.IdPronostic);
                    command.Parameters.AddWithValue("@dni_usuari", pr.Usuari.Dni);
                    command.Parameters.AddWithValue("@id_partit", pr.Partit.IdPartit);
                    command.Parameters.AddWithValue("@gols_equip_a", pr.GolsEquipA);
                    command.Parameters.AddWithValue("@gols_equip_b", pr.GolsEquipB);

                    command.ExecuteNonQuery();

                }

                conn.Close(); //el using la tanca automaticament xo wno
            }
        }

        //public void CancelarPronostic(Pronostic pr)

    }
}
