using PorraGirona.model;
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
    /// Lógica de interacción para IniciarSessio.xaml
    /// </summary>
    public partial class IniciarSessio : Window
    {
        public IniciarSessio()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_inicSessio_iniciSessio_Click(object sender, RoutedEventArgs e)
        {
            string dni = inp_Usuari_IniciarSessio.Text;
            string pass = inp_Contrassenya_IniciarSessio.Text;

            Sessio s=new Sessio(dni, pass);

            if(s.Valida)
            {
                //entrar a la pagina d'inici de usuari

                MessageBox.Show("ok"); //esborrar
            }
            else
            {
                //no entrar

                MessageBox.Show("no ok");//esborrar

            }

        }
    }
}
