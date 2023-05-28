using MySqlConnector;
using PorraGirona.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PorraGirona.dades
{
    public class dbUsuaris:dbConnexio
    {
        /// <summary>
        /// Comprova que l'usuari i la contrasenya de la sessió coincideixin amb algun usuari registrat a la base de dades.
        /// Primer obre la connexió, fa la comprovació i finalment la tanca.
        /// </summary>
        /// <param name="s">L'objecte sessió conté els atributs de dni i contrasenya.</param>
        /// <returns>Retorna true si hi ha algun usuari registrar i concideix amb DNI i contrasenya, retorna false si l'usuari no està registrar o la contrasenya és incorrecte.</returns>
        public bool IniciarSessió(Sessio s)
        {
            string query = $"SELECT dni, contrasenya FROM usuaris WHERE dni='{s.Dni}'";

            bool r = false; //return

            try
            {
                ConnectarBD();

                using(MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string contrasenyaCorrecta = reader.GetString("contrasenya");

                            if (contrasenyaCorrecta == s.Pass) //si la contrasenya es correcta
                            {
                                r = true;
                            }
                            
                        }
                        
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ ex.Message);
            }
            finally
            {
                DesconnectarBD();
            }

            return r;

        }

        /// <summary>
        /// Connecta amb la base de dades i analitza la llista que es torna amb la select on coincideixin els dni. Agafa tots els valors i crea un objecte Usuari.
        /// Si el camp administrador es 0 crea un usuari, si es un altre numero crea un administrador. Al acabar es desconnecta de la base de dades.
        /// </summary>
        /// <param name="dni_usuari">Dni de l'usuari a buscar a la base de dades</param>
        /// <returns>Retorna l'objecte usuari creat amb les dades recuperades de la base de dades.</returns>
        public Usuari BuscarUsuari(string dni_usuari)
        {
            string query = $"SELECT * FROM usuaris WHERE dni='{dni_usuari}'";

            Usuari u = null; //return

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dni = reader.GetString("dni");
                            string contrasenya = reader.GetString("contrasenya");
                            string nom = reader.GetString("nom");
                            string cognom = reader.GetString("cognom");
                            int puntsAcumulats = reader.GetInt32("puntsAcumulats");
                            int administrador = reader.GetInt32("administrador");
                            
                            dbPronostics dbp = new dbPronostics();                            
                            LlistaPronostics lpr = dbp.RecuperarPronostics(dni_usuari);

                            if (administrador == 0)
                            {
                                u = new Usuari(dni, contrasenya, nom, cognom, puntsAcumulats, lpr);
                            }
                            else
                            {
                                u = new Administrador(dni, contrasenya, nom, cognom, puntsAcumulats, lpr);
                            }

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

            return u;

        }

        /// <summary>
        /// Connecta amb la base de dades i elimina els registres que tinguin com a DNI el dni que se li ha passat. Al acabar es desconnecta de la base de dades.
        /// </summary>
        /// <param name="dni_usuari">Dni de l'usuari a eliminar de la base de dades</param>
        public void EliminarUsuari(string dni_usuari)
        {
            string query = $"DELETE FROM usuaris WHERE dni='{dni_usuari}'";

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
        /// Connecta amb la base de dades i hi inserta els valors dels altributs l'objecte usuari rebut a la taula usuaris. 
        /// Els parametritza per evitar atacs de SQL Injection.
        /// Al acabar es desconnecta de la base de dades.
        /// </summary>
        /// <param name="u">Objecte de tipus usuari que s'ha de guardar a la base de dades.</param>
        public void InsertarUsuari(Usuari u)
        {
            string query = $"INSERT INTO usuaris(dni, constrasenya, nom, cognom, puntsAcumulats, administrador) values (@dni, @contrasenya, @nom, @cognom, @puntsAcumulats, @administrador)";

            try
            {
                ConnectarBD();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@dni", u.Dni);
                    command.Parameters.AddWithValue("@contrasenya", u.Contrasenya);
                    command.Parameters.AddWithValue("@nom", u.Nom);
                    command.Parameters.AddWithValue("@cognom", u.Cognom);
                    command.Parameters.AddWithValue("@puntsAcumulats", u.PuntsAcumulats);

                    int a =0;
                    if(u is Administrador) a=1;
                        
                    command.Parameters.AddWithValue("@administrador", a);
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
