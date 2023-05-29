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

        /// <summary>
        /// Connecta amb la base de dades i busca tots els registre de la taula pronostics on el camp dni_usuari
        /// coincideixi amb el dni passat. Per cada registre que obté crea una instància nova de l'objecte 
        /// lpr i l'afageix a l'objecte lpr de tipus LlistaPronostics. Al acabar es desconnecta de la base de dades
        /// </summary>
        /// <param name="dni">Dni de l'usuari a buscar els pronostics</param>
        /// <returns></returns>
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

        /// <summary>
        /// Connecta amb la base de dades i hi inserta els valors dels atributs l'objecte pronostic rebut a la taula pronostics. 
        /// Els parametritza per evitar atacs de SQL Injection.
        /// Al acabar es desconnecta de la base de dades.
        /// </summary>
        /// <param name="pr">Pronostic a guardar a la base de dades</param>
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

        /// <summary>
        ///  Connecta amb la base de dades i hi actualitza els valors dels atributs l'objecte pronostic rebut a la taula pronostics
        ///  on l'id del pronostic que vol modificar amb el que està a la base de dades coincideixi,
        /// Els parametritza per evitar atacs de SQL Injection.
        /// </summary>
        /// <param name="pr"></param>
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

        /// <summary>
        /// Connecta amb la base de dades. Elimina el registre de la taula pronostics on l'id coincideixi amb el passat.
        /// Al acabar tanca la connexió amb la base de dades.
        /// </summary>
        /// <param name="id"></param>
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

        public int ObtenirIdPartit(int idPronostic)
        {
            int idPartit = -1; // Valor per defecte en cas de no trobar coincidències

            string consulta = $"SELECT id_partit FROM pronostics WHERE id_pronostic = {idPronostic}";

            try
            {
                ConnectarBD();

                using (MySqlCommand comanda = new MySqlCommand(consulta, conn))
                {
                    object resultat = comanda.ExecuteScalar();

                    if (resultat != null && resultat != DBNull.Value)
                    {
                        idPartit = Convert.ToInt32(resultat);
                    }
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

            return idPartit;
        }

        public char ObtindreEquipGuanyador(int idPartit)
        {
            char equipGuanyador = 'b'; // Valor per defecte si els gols de l'equip B són majors o en cas d'error

            string consulta = $"SELECT gols_equip_A, gols_equip_B, estat FROM partits WHERE id_partit = {idPartit}";

            try
            {
                ConnectarBD();

                using (MySqlCommand comanda = new MySqlCommand(consulta, conn))
                {
                    using (MySqlDataReader lector = comanda.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            int golsEquipA = lector.GetInt32("gols_equip_A");
                            int golsEquipB = lector.GetInt32("gols_equip_B");
                            string estatPartit = lector.GetString("estat");

                            if (estatPartit == "finalitzat")
                            {
                                if (golsEquipA > golsEquipB)
                                {
                                    equipGuanyador = 'a';
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error: El partit no està finalitzat.");
                            }
                        }
                    }
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

            return equipGuanyador;
        }

        public char ObtindreEquipGuanyadorPronostic(int idPronostic)
        {
            char equipGuanyador = 'b'; // Valor per defecte si els gols de l'equip B són majors o en cas d'error

            string consulta = $"SELECT gols_equip_a, gols_equip_b FROM pronostics WHERE id_pronostic = {idPronostic}";

            try
            {
                ConnectarBD();

                using (MySqlCommand comanda = new MySqlCommand(consulta, conn))
                {
                    using (MySqlDataReader lector = comanda.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            int golsEquipA = lector.GetInt32(0);
                            int golsEquipB = lector.GetInt32(1);

                            if (golsEquipA > golsEquipB)
                            {
                                equipGuanyador = 'a';
                            }
                        }
                    }
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

            return equipGuanyador;
        }





    }
}
