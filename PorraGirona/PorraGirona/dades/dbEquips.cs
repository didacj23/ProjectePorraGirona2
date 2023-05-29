using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PorraGirona.dades
{
    public class dbEquips:dbConnexio
    {
        /// <summary>
        /// Connecta amb la base de dades i busca un registre a la taula equips on el camp nom_equip
        /// coincideixi amb el nom de l'equip que es vol buscar. Si el troba, agafa totes les dades i crea una
        /// nova instància de l'objecte de tipus equip. Al acabar es desconnecta de la base de dades.
        /// </summary>
        /// <param name="nom_equip">Nom de l'equip a buscar a la base de dades.</param>
        /// <returns>Retorn l'objecte de tipus equip amb les dades de l'equip trobat.</returns>
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

        /// <summary>
        /// Connecta amb la base de dades i esborra el registre on el camp nom_equip coincideix amb
        /// el nom de l'equip que es vol eliminar. Al acabar es desconnecta de la base de dades.
        /// </summary>
        /// <param name="nom_equip">Nom de l'equip a eliminar de la base de dades.</param>
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

        //Crear Equip

        public void CrearEquip(string nom_equip, string camp)
        {
            string query = $"INSERT INTO equips (nom_equip, camp) VALUES ('{nom_equip}', '{camp}')";

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
