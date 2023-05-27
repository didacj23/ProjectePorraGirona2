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
    internal class dbUsuaris:dbConnexio
    {

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

    }

}

/*
public void InsertarUsuari(Usuari u)
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
}*/



/*
    using (MySqlConnection conn = new MySqlConnection(connectionString))
    {
        conn.Open();

        string query = "INSERT INTO usuaris(dni, contrasenya, nom, cognom, puntsAcumulats, administrador) values (@dni, @contrasenya, @nom, @cognom, @puntsAcumulats, @administrador)";

        using (MySqlCommand command = new MySqlCommand(query, conn))
        {
            command.Parameters.AddWithValue("@dni", u.Dni);
            command.Parameters.AddWithValue("@contrasenya", u.Contrasenya);
            command.Parameters.AddWithValue("@nom", u.Nom);
            command.Parameters.AddWithValue("@cognom", u.Cognom);
            command.Parameters.AddWithValue("@puntsAcumulats", u.PuntsAcumulats);

            //si es usuari, admin=0, si es admin, admin=1
            int admin = 0;
            if (u is Administrador) admin = 1;

            command.Parameters.AddWithValue("@administrador", admin);


            command.ExecuteNonQuery();

        }

        conn.Close(); //el using la tanca automaticament xo wno
    }
}


*/

