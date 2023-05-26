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
    internal class dbPartits:dbConnexio
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


    }
}
