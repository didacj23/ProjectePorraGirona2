using MySqlConnector;
using PorraGirona.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PorraGirona.dades
{
    public class dbPartits:dbConnexio
    {
        public Partit BuscarPartit(int id_partit)
        {            
            string query = $"SELECT * FROM partits WHERE id_partit='{id_partit}'";

            Partit p = null;

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dbEquips dbTeam = new dbEquips();
                            
                            string nom_equip_a=reader.GetString("equip_A");                            
                            Equip equipA = dbTeam.BuscarEquip(nom_equip_a);

                            string nom_equip_b = reader.GetString("equip_B");
                            Equip equipB = dbTeam.BuscarEquip(nom_equip_b);

                            int gols_a = reader.GetInt32("gols_equip_A");
                            int gols_b = reader.GetInt32("gols_equip_B");

                            DateTime diaHora = reader.GetDateTime("dia_hora");
                            string camp = reader.GetString("camp");
                            string estat = reader.GetString("estat");

                            p = new Partit(id_partit, equipA, equipB, diaHora, camp, estat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                DesconnectarBD();
            }

            return p;
            
        }

        public List<Partit> RecuperarLlistaPartitsProgramats()
        {
            string query = $"SELECT * FROM partits WHERE estat='programat' and dia_hora > NOW()";

            //LlistaPartits lp = new LlistaPartits();

            List<Partit> llistaPartits = new List<Partit>();

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {                            

                            int id_partit = reader.GetInt32("id_partit");
                                
                            dbEquips dbTeam = new dbEquips();

                            string nom_equip_a = reader.GetString("equip_A");
                            Equip equipA = dbTeam.BuscarEquip(nom_equip_a);

                            string nom_equip_b = reader.GetString("equip_B");
                            Equip equipB = dbTeam.BuscarEquip(nom_equip_b);

                            int gols_a = reader.GetInt32("gols_equip_A");
                            int gols_b = reader.GetInt32("gols_equip_B");

                            DateTime diaHora = reader.GetDateTime("dia_hora");
                            string camp = reader.GetString("camp");
                            string estat = reader.GetString("estat");

                            Partit p = new Partit(id_partit, equipA, equipB, diaHora, camp, estat);

                            llistaPartits.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                DesconnectarBD();
            }

            return llistaPartits;

        }
        public void InsertarPartit(int id_partit, string equipA, string equipB, DateTime dia_hora, string camp, string estat)
        {
            string query = $"INSERT INTO partits (id_partit, equip_A, equip_B, dia_hora, camp, estat) VALUES ({id_partit}, '{equipA}', '{equipB}', '{dia_hora.ToString("yyyy-MM-dd HH:mm:ss")}', '{camp}', '{estat}')";

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                DesconnectarBD();
            }
        }






        
        public void EntrarResultat(int id_partit, int gA, int gB)
        {
            string query = $"UPDATE partit SET gols_equip_A = @golsA, gols_equip_B=@golsB where id_partit={id_partit}";

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {                   
                    command.Parameters.AddWithValue("@golsA", gA);
                    command.Parameters.AddWithValue("@golsB", gB);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                DesconnectarBD();
            }

        }


    }
}
