using PorraGirona.dades;
using PorraGirona.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PorraGirona.usuari
{
    /// <summary>
    /// Lógica de interacción para IniciUsuari.xaml
    /// </summary>
    public partial class IniciUsuari : Window
    {
        public Usuari us;

        public IniciUsuari(Usuari us, bool admin, LlistaPronostics lpr, LlistaPartits lps)
        {
            InitializeComponent();
            this.us=us;

            if(admin) 
            {
                btn_admin_iniciUsuari.Visibility = Visibility.Visible;
            }
            else
            {
                btn_admin_iniciUsuari.Visibility = Visibility.Collapsed;
            }

            lbl_nomUsuari_usuari.Content = "hola, " + us.Nom + " " + us.Cognom;

            lbl_puntuacio_usuari.Content = us.PuntsAcumulats;
                            

            dg_Pronostics_usuari.ItemsSource = lpr.Pronostics;
            dg_PropersPartits_usuari.ItemsSource = lps.Partits;
            
            


        }

        public IniciUsuari()
        {
        }

        private void dg_Pronostics_usuari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_admin_iniciUsuari_Click(object sender, RoutedEventArgs e)
        {
            Administrador admin = new Administrador(us);
            Close();
            admin.Show();
        }

        private void btn_TancarSessio_iniciUsuari_Click(object sender, RoutedEventArgs e)
        {
            mainWindow mainWindow = new mainWindow();
            mainWindow.Show();
            Close();
        }

        private void btn_CrearPronostic_iniciUsuari_Click(object sender, RoutedEventArgs e)
        {
            PronosticFinestra pronostic = new PronosticFinestra(us);
            //Close();
            pronostic.Show();
        }

        /*private void btn_ModPronostic_iniciaUsuari_Click(object sender, RoutedEventArgs e)
        {
            Modificar modificar = new Modificar();
            Close();
            modificar.Show();
        }*/
    }
}
