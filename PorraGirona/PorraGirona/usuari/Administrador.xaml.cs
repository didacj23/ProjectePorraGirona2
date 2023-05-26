using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        /*private void rad_eliminarUsuari_admin_Checked(object sender, RoutedEventArgs e)
        {
            /*lbl_nomUsuari_admin.Visibility = rad_eliminarUsuari_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            inp_Usuari_admin.Visibility = rad_eliminarUsuari_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            btn_eliminarUsuari_admin.Visibility = rad_eliminarUsuari_admin.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;*/
        //}

        private void rad_programarPartit_admin_Checked(object sender, RoutedEventArgs e)
        {
            lbl_EquipA_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible: Visibility.Visible;
            lbl_EquipB_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
            lbl_DataHora_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
            lbl_id_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;

            inp_EquipA_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
            inp_EquipB_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
            inp_DataHora_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
            inp_id_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;

            btn_ProgramarPartit_admin.Visibility = rad_programarPartit_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
        }

        private void rad_CrearEquip_admin_Checked(object sender, RoutedEventArgs e)
        {
            lbl_NomCamp_admin.Visibility = rad_CrearEquip_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
            lbl_NomEquip_admin.Visibility = rad_CrearEquip_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;

            inp_NomCamp_admin.Visibility = rad_CrearEquip_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
            inp_NomEquip_admin.Visibility = rad_CrearEquip_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;

            btn_PujarFoto_admin.Visibility = rad_CrearEquip_admin.IsChecked == true ? Visibility.Visible : Visibility.Visible;
        }

        private void btn_PujarFoto_admin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string UsuariPath = openFileDialog.FileName;
                string destinationDirectory = "usuari/logos";
                string NomLogo = new FileInfo(UsuariPath).Name;

                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string CarpetaLogos = System.IO.Path.Combine(projectDirectory, destinationDirectory, NomLogo);

                File.Copy(UsuariPath, CarpetaLogos, true);

            }
        }
    }
}
