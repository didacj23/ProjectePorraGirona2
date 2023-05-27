/*using MySqlConnector;
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


        //USUARI
      

       


        //public bool EliminarUsuari(string dni)




        //EQUIP
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



        //PARTIT        
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

        public Partit BuscarPartit(int idPartit)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT * FROM partits where id_partit = {idPartit}";

                Partit p = new Partit();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nomEquipA = reader.GetString("equip_A");
                            Equip equipA = ObtenirEquip(nomEquipA);

                            string nomEquipB = reader.GetString("equip_B");
                            Equip equipB = ObtenirEquip(nomEquipA);

                            int golsEquipA = reader.GetInt32("gols_equip_A");
                            int golsEquipB = reader.GetInt32("gols_equip_B");
                            DateTime diaHora = reader.GetDateTime("dia_hora");
                            string camp = reader.GetString("camp");
                            string estat = reader.GetString("estat");

                            p = new Partit(idPartit, equipA, equipB, golsEquipA, golsEquipB, diaHora, camp, estat);

                        }
                        else { } //Partit no trobat x aquest id

                    }
                }

                conn.Close();
                return p;

            }
        }

        public LlistaPartits RecuperarLlistaPartits()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT * FROM partits";

                LlistaPartits lp = new LlistaPartits();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idPartit = reader.GetInt32("id_partit");

                            string nomEquipA = reader.GetString("equip_A");
                            Equip equipA = ObtenirEquip(nomEquipA);

                            string nomEquipB = reader.GetString("equip_B");
                            Equip equipB = ObtenirEquip(nomEquipA);

                            int golsEquipA = reader.GetInt32("gols_equip_A");
                            int golsEquipB = reader.GetInt32("gols_equip_B");
                            DateTime diaHora = reader.GetDateTime("dia_hora");
                            string temporada = reader.GetString("temporada");
                            string camp = reader.GetString("camp");
                            string estat = reader.GetString("estat");

                            Partit p = new Partit(idPartit, equipA, equipB, golsEquipA, golsEquipB, diaHora, camp, estat);

                            lp.AfegirPartit(p);

                        }

                    }
                }

                conn.Close();
                return lp;

            }
        }

        public LlistaPartits RecuperarLlistaPartitsNoIniciats()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT * FROM partits where estat = 'programat' and dia_hora > NOW()";

                LlistaPartits lp = new LlistaPartits();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idPartit = reader.GetInt32("id_partit");

                            string nomEquipA = reader.GetString("equip_A");
                            Equip equipA = ObtenirEquip(nomEquipA);

                            string nomEquipB = reader.GetString("equip_B");
                            Equip equipB = ObtenirEquip(nomEquipA);

                            int golsEquipA = reader.GetInt32("gols_equip_A");
                            int golsEquipB = reader.GetInt32("gols_equip_B");
                            DateTime diaHora = reader.GetDateTime("dia_hora");
                            string temporada = reader.GetString("temporada");
                            string camp = reader.GetString("camp");
                            string estat = reader.GetString("estat");

                            Partit p = new Partit(idPartit, equipA, equipB, golsEquipA, golsEquipB, diaHora, camp, "programat");

                            lp.AfegirPartit(p);

                        }

                    }
                }

                conn.Close();
                return lp;

            }
        }



        //PRONOSTIC
        

        //public void CancelarPronostic(Pronostic pr)
        
        
        public LlistaPronostics RecuperarPronostics(Usuari u)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $"SELECT * FROM pronostics where dni_usuari='{u.Dni}'";

                LlistaPronostics lpr = new LlistaPronostics();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idPronostic = reader.GetInt32("id_pronostic");

                            int idPartit = reader.GetInt32("id_partit");
                            Partit p = BuscarPartit(idPartit);

                            int golsA = reader.GetInt32("gols_equip_a");
                            int golsB = reader.GetInt32("gols_equip_b");

                            Pronostic pr = new Pronostic(idPronostic, u, p, golsA, golsB);

                            lpr.AfegirPronostic(pr);

                        }

                    }

                }

                conn.Close();
                return lpr;

            }
        }
        
    }
}
*/