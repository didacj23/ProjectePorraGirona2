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
    internal class dbPronostics:dbConnexio
    {
        public Pronostic BuscarPronostic(int id_pronostic)
        {
            string query = $"SELECT * FROM pronostics WHERE id_pronostic='{id_pronostic}'";

            Pronostic pr = null;

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        string dni_usuari = reader.GetString("dni_usuari");

                        dbUsuaris dbUser = new dbUsuaris();
                        Usuari u = dbUser.BuscarUsuari(dni_usuari);

                        int id_partit = reader.GetInt32("id_partit");
                        //buscar partit enviant la id
                        
                        dbPartits dbPart = new dbPartits();
                        Partit partit = dbPart.BuscarPartit(id_partit);                        

                        int gols_equip_a = reader.GetInt32("gols_equip_a");
                        int gols_equip_b = reader.GetInt32("gols_equip_b");

                        pr = new Pronostic(id_pronostic, u, partit, gols_equip_a, gols_equip_b);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                DesconnectarBD();
            }

            return pr;

        }



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
                        while(reader.Read())
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
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ex.Message);
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
    }

    /*
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
    }*/






}
