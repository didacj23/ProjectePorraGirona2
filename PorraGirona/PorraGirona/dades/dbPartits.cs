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
        /// <summary>
        /// Connecta amb la base de dades i busca un registre a la taula partits on el camp id_partit
        /// coincideixi amb id del partit que es vol buscar. Quan el troba, agafa totes les dades del registre
        /// i crea una nova instància de l'objecte p de tipus partit. Al acabar es desconnecta de la base de dades
        /// </summary>
        /// <param name="id_partit">Id del partit a buscar a la base de dades.</param>
        /// <returns>Retorna l'objecte p amb les dades del partit trobat.</returns>
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

        /// <summary>
        /// Connecta amb la base de dades i busca tots els registre de la taula partits on el camp estat
        /// sigui programat i que la data programada sigui posterior a l'actual. Per cada registre que obté crea una 
        /// instància nova de l'objecte p i l'afageix a la List de tipus partit llistaPartits. Al acabar es desconnecta de la base de dades
        /// </summary>
        /// <returns>Retorna l'objecte la List de tipus partit llistaPartits amb el valors recuperats de la base de dades.</returns>
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

        /// <summary>
        /// Connecta amb la base de dades i hi inserta els valors dels altributs l'objecte usuari rebut a la taula partits. 
        /// Els parametritza per evitar atacs de SQL Injection.
        /// Al acabar es desconnecta de la base de dades.
        /// </summary>
        /// <param name="p">Partit a insertar a la base de dades</param>
        public void InsertarPartit(Partit p)
        {
            string query = $"INSERT INTO partits (id_partit, equip_A, equip_B, dia_hora, camp, estat) VALUES (@id_partit, @ea, @eb, @diaHora, @camp, @estat)";

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id_partit", p.IdPartit);
                    command.Parameters.AddWithValue("@ea", p.EquipA);
                    command.Parameters.AddWithValue("@eb", p.EquipB);
                    command.Parameters.AddWithValue("@diaHora", p.DiaHora);
                    command.Parameters.AddWithValue("@camp", p.Camp);
                    command.Parameters.AddWithValue("@estat", p.Estat);

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
               
        /// <summary>
        /// Actualitza els valors dels gols de l'equip A i B del partit passat que coincideixi amb l'ID.
        /// Es connecta amb la ACABAR
        /// </summary>
        /// <param name="id_partit"></param>
        /// <param name="gA"></param>
        /// <param name="gB"></param>
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

        public int ObtenirUltimId()
        {
            string query = "SELECT MAX(id_partit) FROM partits";
            int maxId = -1;

            try
            {
                ConnectarBD();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    maxId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. " + ex.Message);
            }
            finally
            {
                DesconnectarBD();
            }

            return maxId;
        }


    }
}
