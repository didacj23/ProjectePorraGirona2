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

        private void btn_inicSessio_iniciSessio_Click(object sender, RoutedEventArgs e)
        {
            lbl_Contrassenya_iniciSessio.Visibility = Visibility.Collapsed;
            lbl_titol_iniciarSessio.Visibility = Visibility.Collapsed;
            lbl_usuari_IniciSessio.Visibility = Visibility.Collapsed;

            btn_enrere_iniciarSessio.Visibility = Visibility.Collapsed;
            btn_inicSessio_iniciSessio.Visibility = Visibility.Collapsed;
            
            inp_Usuari_IniciarSessio.Visibility = Visibility.Collapsed;
            pas_contrassenya_iniciarSessio.Visibility = Visibility.Collapsed;

            lbl_carregant_iniciSessio.Visibility = Visibility.Visible;

            string dni = inp_Usuari_IniciarSessio.Text;
            string pass = pas_contrassenya_iniciarSessio.Password;

            Sessio s=new Sessio(dni, pass);

            if(s.Valida)
            {                

                LlistaPartits lps = new LlistaPartits();
                lps.Emplenar();
                

                //entrar a la pagina d'inici de usuari. Passa els atributs usuari i admin de la sessió iniciada
                IniciUsuari iniciUsuari = new IniciUsuari(s.Usuari, s.Admin, s.Usuari.Pronostics, lps);
                Close();
                iniciUsuari.Show();                

            }
            else
            {
                //no entrar
                mainWindow main = new mainWindow();
                Close();
                main.Show();
                MessageBox.Show("DNI o contrasenya invàlids");
            }

        }

        private void btn_enrere_registre_Click(object sender, RoutedEventArgs e)
        {
            mainWindow mainWindow = new mainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
