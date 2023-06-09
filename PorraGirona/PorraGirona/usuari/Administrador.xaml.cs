﻿using Microsoft.Win32;

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
            lbl_camp_admin.Visibility = Visibility.Collapsed;
            lbl_estat_admin.Visibility = Visibility.Collapsed;
            inp_Camp_admin.Visibility = Visibility.Collapsed;
            inp_estat_admin.Visibility = Visibility.Collapsed;

            btn_CrearEquip_admin.Visibility = Visibility.Collapsed;
        }


        private void rad_programarPartit_admin_Checked(object sender, RoutedEventArgs e)
        {
            if (rad_programarPartit_admin.IsChecked == true)
            {
                
                lbl_EquipA_admin.Visibility = Visibility.Visible;
                lbl_EquipB_admin.Visibility = Visibility.Visible;
                lbl_DataHora_admin.Visibility = Visibility.Visible;
                //lbl_id_admin.Visibility = Visibility.Visible;

                inp_EquipA_admin.Visibility = Visibility.Visible;
                inp_EquipB_admin.Visibility = Visibility.Visible;
                inp_DataHora_admin.Visibility = Visibility.Visible;
                //inp_id_admin.Visibility = Visibility.Visible;

                lbl_camp_admin.Visibility = Visibility.Visible;
                //lbl_estat_admin.Visibility = Visibility.Visible;
                inp_Camp_admin.Visibility = Visibility.Visible;
                //inp_estat_admin.Visibility = Visibility.Visible;

                btn_ProgramarPartit_admin.Visibility = Visibility.Visible;
            }

            
            lbl_NomCamp_admin.Visibility = Visibility.Collapsed;
            lbl_NomEquip_admin.Visibility = Visibility.Collapsed;

            inp_NomCamp_admin.Visibility = Visibility.Collapsed;
            inp_NomEquip_admin.Visibility = Visibility.Collapsed;

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

            btn_CrearEquip_admin.Visibility = Visibility.Collapsed;


        }

        private void rad_CrearEquip_admin_Checked(object sender, RoutedEventArgs e)
        {
            if (rad_CrearEquip_admin.IsChecked == true)
            {
                
                lbl_NomCamp_admin.Visibility = Visibility.Visible;
                lbl_NomEquip_admin.Visibility = Visibility.Visible;

                inp_NomCamp_admin.Visibility = Visibility.Visible;
                inp_NomEquip_admin.Visibility = Visibility.Visible;

                btn_CrearEquip_admin.Visibility = Visibility.Visible;

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
            lbl_camp_admin.Visibility = Visibility.Collapsed;
            lbl_estat_admin.Visibility = Visibility.Collapsed;
            inp_Camp_admin.Visibility = Visibility.Collapsed;
            inp_estat_admin.Visibility = Visibility.Collapsed;


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

            lbl_camp_admin.Visibility = Visibility.Collapsed;
            lbl_estat_admin.Visibility = Visibility.Collapsed;
            inp_Camp_admin.Visibility = Visibility.Collapsed;
            inp_estat_admin.Visibility = Visibility.Collapsed;
            btn_CrearEquip_admin.Visibility = Visibility.Collapsed;


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
                lbl_camp_admin.Visibility = Visibility.Visible;
                lbl_estat_admin.Visibility = Visibility.Visible;
                inp_Camp_admin.Visibility = Visibility.Visible;
                inp_estat_admin.Visibility = Visibility.Visible;
               
            }

            
            lbl_NomCamp_admin.Visibility = Visibility.Collapsed;
            lbl_NomEquip_admin.Visibility = Visibility.Collapsed;

            inp_NomCamp_admin.Visibility = Visibility.Collapsed;
            inp_NomEquip_admin.Visibility = Visibility.Collapsed;

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

            lbl_camp_admin.Visibility = Visibility.Collapsed;
            lbl_estat_admin.Visibility = Visibility.Collapsed;
            inp_Camp_admin.Visibility = Visibility.Collapsed;
            inp_estat_admin.Visibility = Visibility.Collapsed;
            btn_CrearEquip_admin.Visibility = Visibility.Collapsed;





        }

        private void btn_enrere_registre_Click(object sender, RoutedEventArgs e)
        {
            //IniciarSessio enrere = new IniciarSessio();
            Close();
            //enrere.Show();
        }

        private void btn_EliminarUsuari_admin_Click(object sender, RoutedEventArgs e)
        {
            string dni = inp_IdUsuari_admin.Text;
            us.EliminarUsuari(dni);           

        }

        private void btn_ProgramarPartit_admin_Click(object sender, RoutedEventArgs e)
        {
            Equip a = new Equip();
            a=a.BuscarEquip(inp_EquipA_admin.Text);

            Equip b = new Equip();
            b = b.BuscarEquip(inp_EquipB_admin.Text);

            DateTime diaIhora = Convert.ToDateTime(inp_DataHora_admin.Text);
            string camp = inp_Camp_admin.Text; //?

            Partit partit = new Partit(a, b, diaIhora, camp);
            if(partit.ProgramarPartit())
            {
                MessageBox.Show("Partit programat correctament");
                inp_EquipA_admin.Text="";
                inp_EquipB_admin.Text="";
                inp_DataHora_admin.Text="";
                inp_Camp_admin.Text="";
            }
            else MessageBox.Show("El partit no s'ha pogut programar correctament");
        }

        private void btn_CrearEquip_admin_Click(object sender, RoutedEventArgs e)
        {
            string NomEquip = inp_NomEquip_admin.Text;
            string NomCamp = inp_NomCamp_admin.Text;

            Equip equip = new Equip();

            if(equip.CrearEquip(NomEquip, NomCamp))
            {   
                MessageBox.Show("Equip creat correctament.");
                inp_NomEquip_admin.Text="";
                inp_NomCamp_admin.Text="";
            }
            else 
                MessageBox.Show("El partit no s'ha pogut crear correctament.");


        }

        private void btn_EntrarResultat_admin_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(inp_IdPartitResultat_admin.Text);
            int Glocal = Convert.ToInt32(inp_GLocal_admin.Text);
            int Gvisitant = Convert.ToInt32(inp_GVisitant_admin.Text);

            Partit partit = new Partit();
            partit.EntrarResultat(id, Glocal, Gvisitant);
        }

        private void btn_eliminarEquip_admin_Click(object sender, RoutedEventArgs e)
        {
            string nom_equip=inp_NomEquip_admin.Text;
            Equip ep = new Equip();
            ep.EliminarEquip(nom_equip);
        }
    }
}
