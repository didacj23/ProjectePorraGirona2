using Google.Protobuf.WellKnownTypes;
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
    public class dbPronostics : dbConnexio
    {
        /// <summary>
        /// Connecta amb la base de dades i busca un registre a la taula pronostics on el camp dni_usuari
        /// coincideixi amb l'atribut de l'objecte usuari passat i que l'id del partit del pronostic a buscar 
        /// coincideixi amb el donat. Quan el troba, agafa totes les dades del registre i crea una nova 
        /// instància de l'objecte pr de tipus pronostic. Al acabar es desconnecta de la base de dades
        /// </summary>
        /// <param name="u">Usuari que ha fet el pronostic que es vol buscar amb els seus atributs.</param>
        /// <param name="id_partit">Id del partit a buscar el pronostic</param>
        /// <returns></returns>
        public Pronostic BuscarPronostic(Usuari u, int id_partit)
        {
            string query = $"SELECT * FROM pronostics WHERE dni_usuari='{u.Dni}' and id_partit='{id_partit}'";

            Pronostic pr = null;

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if(reader.Read())
                        {
                            string dni_usuari = reader.GetString("dni_usuari");

                            dbUsuaris dbUser = new dbUsuaris();
                            u = dbUser.BuscarUsuari(dni_usuari);

                            id_partit = reader.GetInt32("id_partit");
                            //buscar partit enviant la id

                            dbPartits dbPart = new dbPartits();
                            Partit partit = dbPart.BuscarPartit(id_partit);

                            int gols_equip_a = reader.GetInt32("gols_equip_a");
                            int gols_equip_b = reader.GetInt32("gols_equip_b");

                            pr = new Pronostic(u, id_partit, gols_equip_a, gols_equip_b);
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

            return pr;

        }

        /// <summary>
        /// Connecta amb la base de dades i busca tots els registre de la taula pronostics on el camp dni_usuari
        /// coincideixi amb l'atribut de l'objecte usuari passat. Per cada registre que obté crea una instància nova de l'objecte 
        /// lpr i l'afageix a l'objecte lpr de tipus LlistaPronostics. Al acabar es desconnecta de la base de dades
        /// </summary>
        /// <param name="u">Usuari que ha fet el pronostic que es vol buscar amb els seus atributs.</param>
        /// <returns>Retorna l'objecte lpr de tipus LlistaPronostics amb els pronostics recuperats de la base de dades.</returns>
        public LlistaPronostics RecuperarPronostics(Usuari u)
        {
            string query = $"SELECT * FROM pronostics WHERE dni_usuari='{u.Dni}'";

            LlistaPronostics lpr = null;

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_pronostic = reader.GetInt32("id_pronostic");
                            int id_partit = reader.GetInt32("id_partit");
                            dbPartits dbp = new dbPartits();
                            Partit p = dbp.BuscarPartit(id_partit);

                            int golsA = reader.GetInt32("gols_equip_a");
                            int golsB = reader.GetInt32("gols_equip_b");

                            Pronostic pr = new Pronostic(id_pronostic, u, p, golsA, golsB);

                            lpr.AfegirPronostic(pr);
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

            return lpr;
        }

        public LlistaPronostics RecuperarPronostics(string dni)
        {
            string query = $"SELECT * FROM pronostics WHERE dni_usuari='{dni}'";

            LlistaPronostics lpr = new LlistaPronostics();

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_pronostic = reader.GetInt32("id_pronostic");
                            int id_partit = reader.GetInt32("id_partit");
                            dbPartits dbp = new dbPartits();
                            Partit p = dbp.BuscarPartit(id_partit);

                            dbUsuaris dbu = new dbUsuaris();
                            Usuari u = dbu.BuscarUsuari(dni);

                            int golsA = reader.GetInt32("gols_equip_a");
                            int golsB = reader.GetInt32("gols_equip_b");

                            Pronostic pr = new Pronostic(id_pronostic, u, p, golsA, golsB);

                            lpr.AfegirPronostic(pr);
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

            return lpr;
        }

        public void InsertarPronostic(Pronostic pr)
        {
            string query = $"INSERT INTO pronostics(id_pronostic, dni_usuari, id_partit, gols_equip_a, gols_equip_b) values (@id_pronostic, @dni_usuari, @id_partit, @gols_equip_a, @gols_equip_b)";

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id_pronostic", pr.IdPronostic);
                    command.Parameters.AddWithValue("@dni_usuari", pr.Usuari.Dni);
                    command.Parameters.AddWithValue("@id_partit", pr.Partit.IdPartit);
                    command.Parameters.AddWithValue("@gols_equip_a", pr.GolsEquipA);
                    command.Parameters.AddWithValue("@gols_equip_B", pr.GolsEquipB);

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

        public void ActualitzarPronostic(Pronostic pr)
        {            
            string query = $"UPDATE pronostics SET id_pronostic = @id_pronostic, dni_usuari=@dni_usuari, id_partit=@id_partit, gols_equip_a=@gols_equip_a, @gols_equip_b=gols_equip_b where id_pronostic={pr.IdPronostic}";

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@gols_equip_a", pr.GolsEquipA);
                    command.Parameters.AddWithValue("@gols_equip_B", pr.GolsEquipB);

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

        public void CancelarPronostic(int id)
        {
            string query = $"DELETE FROM pronostics WHERE id_pronostic='{id}'";

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

        /// <summary>
        ///Obté l'id de l'últim partit guardat a la base de dades i l'hi suma 1 per assignar al nou partit.
        /// </summary>
        /// <returns>Retorna l'id pel nou partit a crear.</returns>
        public int ObtenirUltimId()
        {
            string query = "SELECT MAX(id_pronostic) FROM pronostics";
            int maxId=-1;

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
                MessageBox.Show("Error. "+ex.Message);
            }
            finally
            {
                DesconnectarBD();
            }

            return maxId;
        }
    } 
}
