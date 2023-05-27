using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PorraGirona.dades
{
    internal class dbEquips:dbConnexio
    {
        public Equip BuscarEquip(string nom_equip)
        {
            string query = $"SELECT * FROM equips WHERE nom_equip='{nom_equip}'";

            Equip e = null;

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string camp = reader.GetString("camp");
                            string foto = reader.GetString("foto");
                            int guanyats = reader.GetInt32("total_partits_guanyats");
                            int perduts = reader.GetInt32("total_partits_perduts");
                            int empatats = reader.GetInt32("total_partits_empatats");

                            e = new Equip(nom_equip, camp, foto, guanyats, perduts, empatats);
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

            return e;

        }

        public void EliminarEquip(string nom_equip)
        {
            string query = $"DELETE FROM equips WHERE nom_equip='{nom_equip}'";

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

    }
}
