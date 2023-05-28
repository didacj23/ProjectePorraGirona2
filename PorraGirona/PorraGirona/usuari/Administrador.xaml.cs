using Microsoft.Win32;

using PorraGirona.model;

using PorraGirona.dades;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Resources;
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
        private Usuari us;
        public Administrador(Usuari us)
        {
            InitializeComponent();
            this.us = us;   
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

        private void rad_eliminarUsuari_admin_Checked_1(object sender, RoutedEventArgs e)
        {
            if (rad_eliminarUsuari_admin.IsChecked == true)
            {
                lbl_IdUsuari_admin.Visibility = Visibility.Visible;
                inp_IdUsuari_admin.Visibility = Visibility.Visible;
                btn_EliminarUsuari_admin.Visibility = Visibility.Visible;
            }

            lbl_EquipA_admin.Visibility = Visibility.Collapsed;
            lbl_EquipB_admin.Visibility = Visibility.Collapsed;
            lbl_DataHora_admin.Visibility = Visibility.Collapsed;
            lbl_id_admin.Visibility = Visibility.Collapsed;

            inp_EquipA_admin.Visibility = Visibility.Collapsed;
            inp_EquipB_admin.Visibility = Visibility.Collapsed;
            inp_DataHora_admin.Visibility = Visibility.Collapsed;
            inp_id_admin.Visibility = Visibility.Collapsed;

            lbl_NomCamp_admin.Visibility = Visibility.Collapsed;
            lbl_NomEquip_admin.Visibility = Visibility.Collapsed;

            inp_NomCamp_admin.Visibility = Visibility.Collapsed;
            inp_NomEquip_admin.Visibility = Visibility.Collapsed;

            btn_PujarFoto_admin.Visibility = Visibility.Collapsed;
            btn_ProgramarPartit_admin.Visibility = Visibility.Collapsed;

            lbl_IdPartit_admin.Visibility = Visibility.Collapsed;
            inp_IdPartitResultat_admin.Visibility = Visibility.Collapsed;
            lbl_GolsVisitant_admin.Visibility = Visibility.Collapsed;
            inp_GVisitant_admin.Visibility = Visibility.Collapsed;
            lbl_GLocal_admin.Visibility = Visibility.Collapsed;
            inp_GVisitant_admin.Visibility = Visibility.Collapsed;
            btn_EntrarResultat_admin.Visibility = Visibility.Collapsed;

            lbl_NomEquipEliminar_Admin.Visibility = Visibility.Collapsed;
            inp_NomEquipEliminar_admin.Visibility = Visibility.Collapsed;
            btn_eliminarEquip_admin.Visibility = Visibility.Collapsed;

            inp_GLocal_admin.Visibility= Visibility.Collapsed;
            lbl_GVisitant_admin.Visibility = Visibility.Collapsed;
            
        }


        private void rad_programarPartit_admin_Checked(object sender, RoutedEventArgs e)
        {
            if (rad_programarPartit_admin.IsChecked == true)
            {
                
                lbl_EquipA_admin.Visibility = Visibility.Visible;
                lbl_EquipB_admin.Visibility = Visibility.Visible;
                lbl_DataHora_admin.Visibility = Visibility.Visible;
                lbl_id_admin.Visibility = Visibility.Visible;

                inp_EquipA_admin.Visibility = Visibility.Visible;
                inp_EquipB_admin.Visibility = Visibility.Visible;
                inp_DataHora_admin.Visibility = Visibility.Visible;
                inp_id_admin.Visibility = Visibility.Visible;

                btn_ProgramarPartit_admin.Visibility = Visibility.Visible;
            }

            
            lbl_NomCamp_admin.Visibility = Visibility.Collapsed;
            lbl_NomEquip_admin.Visibility = Visibility.Collapsed;

            inp_NomCamp_admin.Visibility = Visibility.Collapsed;
            inp_NomEquip_admin.Visibility = Visibility.Collapsed;

            btn_PujarFoto_admin.Visibility = Visibility.Collapsed;

            lbl_IdUsuari_admin.Visibility = Visibility.Collapsed;
            inp_IdUsuari_admin.Visibility = Visibility.Collapsed;
            btn_EliminarUsuari_admin.Visibility = Visibility.Collapsed;

            lbl_NomEquipEliminar_Admin.Visibility = Visibility.Collapsed;
            inp_NomEquipEliminar_admin.Visibility = Visibility.Collapsed;
            btn_eliminarEquip_admin.Visibility = Visibility.Collapsed;

            lbl_IdPartit_admin.Visibility = Visibility.Collapsed;
            inp_IdPartitResultat_admin.Visibility = Visibility.Collapsed;
            lbl_GVisitant_admin.Visibility = Visibility.Collapsed;
            inp_GVisitant_admin.Visibility = Visibility.Collapsed;
            lbl_GLocal_admin.Visibility = Visibility.Collapsed;
            inp_GLocal_admin.Visibility = Visibility.Collapsed;
            btn_EntrarResultat_admin.Visibility = Visibility.Collapsed;

            inp_GLocal_admin.Visibility = Visibility.Collapsed;

        }

        private void rad_CrearEquip_admin_Checked(object sender, RoutedEventArgs e)
        {
            if (rad_CrearEquip_admin.IsChecked == true)
            {
                
                lbl_NomCamp_admin.Visibility = Visibility.Visible;
                lbl_NomEquip_admin.Visibility = Visibility.Visible;

                inp_NomCamp_admin.Visibility = Visibility.Visible;
                inp_NomEquip_admin.Visibility = Visibility.Visible;

                btn_PujarFoto_admin.Visibility = Visibility.Visible;
            }


            
            lbl_EquipA_admin.Visibility = Visibility.Collapsed;
            lbl_EquipB_admin.Visibility = Visibility.Collapsed;
            lbl_DataHora_admin.Visibility = Visibility.Collapsed;
            lbl_id_admin.Visibility = Visibility.Collapsed;

            inp_EquipA_admin.Visibility = Visibility.Collapsed;
            inp_EquipB_admin.Visibility = Visibility.Collapsed;
            inp_DataHora_admin.Visibility = Visibility.Collapsed;
            inp_id_admin.Visibility = Visibility.Collapsed;

            btn_ProgramarPartit_admin.Visibility = Visibility.Collapsed;

            lbl_IdUsuari_admin.Visibility = Visibility.Collapsed;
            inp_IdUsuari_admin.Visibility = Visibility.Collapsed;
            btn_EliminarUsuari_admin.Visibility = Visibility.Collapsed;
            btn_ProgramarPartit_admin.Visibility = Visibility.Collapsed;

            lbl_NomEquipEliminar_Admin.Visibility = Visibility.Collapsed;
            inp_NomEquipEliminar_admin.Visibility = Visibility.Collapsed;
            btn_eliminarEquip_admin.Visibility = Visibility.Collapsed;

            lbl_IdPartit_admin.Visibility = Visibility.Collapsed;
            inp_IdPartitResultat_admin.Visibility = Visibility.Collapsed;
            lbl_GVisitant_admin.Visibility = Visibility.Collapsed;
            inp_GVisitant_admin.Visibility = Visibility.Collapsed;
            lbl_GLocal_admin.Visibility = Visibility.Collapsed;
            inp_GLocal_admin.Visibility = Visibility.Collapsed;
            btn_EntrarResultat_admin.Visibility = Visibility.Collapsed;


        }

        private void rad_EliminarEquip_admin_Checked(object sender, RoutedEventArgs e)
        {
            if (rad_EliminarEquip_admin.IsChecked == true)
            {
                
                lbl_NomEquipEliminar_Admin.Visibility = Visibility.Visible;
                inp_NomEquipEliminar_admin.Visibility = Visibility.Visible;
                btn_eliminarEquip_admin.Visibility = Visibility.Visible;
            }

            
            lbl_NomCamp_admin.Visibility = Visibility.Collapsed;
            lbl_NomEquip_admin.Visibility = Visibility.Collapsed;

            inp_NomCamp_admin.Visibility = Visibility.Collapsed;
            inp_NomEquip_admin.Visibility = Visibility.Collapsed;

            btn_PujarFoto_admin.Visibility = Visibility.Collapsed;

            lbl_EquipA_admin.Visibility = Visibility.Collapsed;
            lbl_EquipB_admin.Visibility = Visibility.Collapsed;
            lbl_DataHora_admin.Visibility = Visibility.Collapsed;
            lbl_id_admin.Visibility = Visibility.Collapsed;

            inp_EquipA_admin.Visibility = Visibility.Collapsed;
            inp_EquipB_admin.Visibility = Visibility.Collapsed;
            inp_DataHora_admin.Visibility = Visibility.Collapsed;
            inp_id_admin.Visibility = Visibility.Collapsed;

            btn_ProgramarPartit_admin.Visibility = Visibility.Collapsed;

            lbl_IdUsuari_admin.Visibility = Visibility.Collapsed;
            inp_IdUsuari_admin.Visibility = Visibility.Collapsed;
            btn_EliminarUsuari_admin.Visibility = Visibility.Collapsed;

            lbl_IdPartit_admin.Visibility = Visibility.Collapsed;
            inp_IdPartitResultat_admin.Visibility = Visibility.Collapsed;
            lbl_GolsVisitant_admin.Visibility = Visibility.Collapsed;
            inp_GVisitant_admin.Visibility = Visibility.Collapsed;
            lbl_GLocal_admin.Visibility = Visibility.Collapsed;
            inp_GVisitant_admin.Visibility = Visibility.Collapsed;
            btn_EntrarResultat_admin.Visibility = Visibility.Collapsed;

            inp_GLocal_admin.Visibility = Visibility.Collapsed;

            
        }

        private void rad_EntrarResultat_admin_Checked(object sender, RoutedEventArgs e)
        {
            if (rad_EntrarResultat_admin.IsChecked == true)
            {
                
                lbl_IdPartit_admin.Visibility = Visibility.Visible;
                inp_IdPartitResultat_admin.Visibility = Visibility.Visible;
                lbl_GVisitant_admin.Visibility = Visibility.Visible;
                inp_GVisitant_admin.Visibility = Visibility.Visible;
                lbl_GLocal_admin.Visibility = Visibility.Visible;
                inp_GLocal_admin.Visibility = Visibility.Visible;
                btn_EntrarResultat_admin.Visibility = Visibility.Visible;
               
            }

            
            lbl_NomCamp_admin.Visibility = Visibility.Collapsed;
            lbl_NomEquip_admin.Visibility = Visibility.Collapsed;

            inp_NomCamp_admin.Visibility = Visibility.Collapsed;
            inp_NomEquip_admin.Visibility = Visibility.Collapsed;

            btn_PujarFoto_admin.Visibility = Visibility.Collapsed;

            lbl_EquipA_admin.Visibility = Visibility.Collapsed;
            lbl_EquipB_admin.Visibility = Visibility.Collapsed;
            lbl_DataHora_admin.Visibility = Visibility.Collapsed;
            lbl_id_admin.Visibility = Visibility.Collapsed;

            inp_EquipA_admin.Visibility = Visibility.Collapsed;
            inp_EquipB_admin.Visibility = Visibility.Collapsed;
            inp_DataHora_admin.Visibility = Visibility.Collapsed;
            inp_id_admin.Visibility = Visibility.Collapsed;

            btn_ProgramarPartit_admin.Visibility = Visibility.Collapsed;

            lbl_IdUsuari_admin.Visibility = Visibility.Collapsed;
            inp_IdUsuari_admin.Visibility = Visibility.Collapsed;
            btn_EliminarUsuari_admin.Visibility = Visibility.Collapsed;

            lbl_NomEquipEliminar_Admin.Visibility = Visibility.Collapsed;
            inp_NomEquipEliminar_admin.Visibility = Visibility.Collapsed;
            btn_eliminarEquip_admin.Visibility = Visibility.Collapsed;

     

            
        }

        private void btn_enrere_registre_Click(object sender, RoutedEventArgs e)
        {
            IniciarSessio enrere = new IniciarSessio();
            Close();
            enrere.Show();
        }

        private void btn_EliminarUsuari_admin_Click(object sender, RoutedEventArgs e)
        {
            string dni = inp_IdUsuari_admin.Text;
            us.EliminarUsuari(dni);           

        }

        private void btn_ProgramarPartit_admin_Click(object sender, RoutedEventArgs e)
        {
            dbEquips dbe = new dbEquips();
            Equip ea = dbe.BuscarEquip(inp_EquipA_admin.Text);
            Equip eb = dbe.BuscarEquip(inp_EquipB_admin.Text);            
            DateTime diaIhora = Convert.ToDateTime(inp_DataHora_admin.Text);
            string camp = inp_Camp_admin.Text; //?

            //int id = Convert.ToInt32(inp_id_admin.Text);

            Partit partit = new Partit(ea, eb, diaIhora, camp);
            partit.ProgramarPartit();

            //partit.ProgramarPartit(EquipLocal, EquipVisitant, diaIhora, camp, estat, id);

        }


    }
}
