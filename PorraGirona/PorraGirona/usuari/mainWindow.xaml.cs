using PorraGirona.usuari;
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

namespace PorraGirona
{
    /// <summary>
    /// Lógica de interacción para mainWindow.xaml
    /// </summary>
    public partial class mainWindow : Window
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void btn_iniciarSessio_inici_Click(object sender, RoutedEventArgs e)
        {
            IniciarSessio iniciarSessio = new IniciarSessio();
            Close();
            iniciarSessio.Show();

        }
    }
}
