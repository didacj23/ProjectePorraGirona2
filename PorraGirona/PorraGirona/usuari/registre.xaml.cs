using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para registre.xaml
    /// </summary>
    public partial class registre : Window
    {
        public registre()
        {
            InitializeComponent();
        }

        private void btn_regstre_registre_Click(object sender, RoutedEventArgs e)
        {
            string nom= inp_Nom_registre.Text;
            string cognom= inp_cognom_registre.Text;
            string dni = inp_dni_registre.Text;
            string pass = pas_contrassenya_registre.Password;

            Usuari u = new Usuari(dni, pass, nom, cognom);

            IniciarSessio iniciarSessio = new IniciarSessio();
            Close();
            iniciarSessio.Show();


        }

        private void btn_enrere_registre_Click(object sender, RoutedEventArgs e)
        {
            mainWindow mainWindow = new mainWindow(); 
            mainWindow.Show();
            Close(); 
        }
    }
}
