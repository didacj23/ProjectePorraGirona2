﻿using MySqlConnector;
using PorraGirona.model;
using System;
using System.CodeDom.Compiler;
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
        public bool InsertarPartit(Partit p)
        {
            string query = $"INSERT INTO partits (id_partit, equip_A, equip_B, dia_hora, camp, estat) VALUES (@id_partit, @ea, @eb, @diaHora, @camp, @estat)";

            bool r=false;

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id_partit", p.IdPartit);
                    command.Parameters.AddWithValue("@ea", p.EquipA.Nom);
                    command.Parameters.AddWithValue("@eb", p.EquipB.Nom);
                    command.Parameters.AddWithValue("@diaHora", p.DiaHora);
                    command.Parameters.AddWithValue("@camp", p.Camp);
                    command.Parameters.AddWithValue("@estat", p.Estat);

                    command.ExecuteNonQuery();
                    r=  true;
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
            return r;
        }

        /// <summary>
        /// Actualitza els valors dels gols de l'equip A i B del partit passat que coincideixi amb l'ID.
        /// Connecta amb la base de dades i actualitza els camps de gols equip A i gols equip B amb els 
        /// valors donats del registre on el camp id_partit coincideix amb l'id del partit que es vol modificar.
        /// Canvia l'estat del partit a finalitzat. Al acabar, es desconnecta de la base de dades.
        /// </summary>
        /// <param name="id_partit">Id del partit a modificar-ne els resultats</param>
        /// <param name="gA">Gols de l'equip A al acabar el partit</param>
        /// <param name="gB">Gols de l'equip B al acabar el partit</param>
        /// 

        public void EntrarResultat(int idPartit, int golsEquipA, int golsEquipB)
        {
            string query = $"UPDATE partits SET gols_equip_A = {golsEquipA}, gols_equip_B = {golsEquipB}, estat = 'finalitzat' WHERE id_Partit = {idPartit}";

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Partit actualitzat correctament");
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
        /// Obté l'id de l'últim partit guardat a la base de dades i l'hi suma 1 per assignar al nou partit.
        /// </summary>
        /// <returns>Retorna l'id pel nou partit a crear.</returns>
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
