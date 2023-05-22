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
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void rad_CrearAdmin_admin_Checked(object sender, RoutedEventArgs e)
        {
            lbl_nomUsuari_admin.Visibility = rad_CrearAdmin_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            inp_Usuari_admin.Visibility = rad_CrearAdmin_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            btn_Crear_admin.Visibility = rad_CrearAdmin_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;

        }

        private void rad_eliminarUsuari_admin_Checked(object sender, RoutedEventArgs e)
        {
            lbl_nomUsuari_admin.Visibility = rad_eliminarUsuari_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            inp_Usuari_admin.Visibility = rad_eliminarUsuari_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            btn_eliminarUsuari_admin.Visibility = rad_eliminarUsuari_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btn_Crear_admin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rad_programarPartit_admin_Checked(object sender, RoutedEventArgs e)
        {
            lbl_EquipA_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible: Visibility.Collapsed;
            lbl_EquipB_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            lbl_DataHora_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            lbl_id_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;

            inp_EquipA_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            inp_EquipB_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            inp_DataHora_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            inp_id_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;

            btn_ProgramarPartit_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
