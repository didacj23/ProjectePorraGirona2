using System;
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
        public IniciUsuari()
        {
            btn
            InitializeComponent();

            
        }

        private void dg_Pronostics_usuari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_regstre_registre_Click(object sender, RoutedEventArgs e)
        {
            Administrador admin = new Administrador();
            Close();
            admin.Show();
        }
    }
}
