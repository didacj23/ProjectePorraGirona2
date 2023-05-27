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
    /// Lógica de interacción para PronosticFinestra.xaml
    /// </summary>
    public partial class PronosticFinestra : Window
    {
        public Usuari us;
        public PronosticFinestra(Usuari us)
        {
            InitializeComponent();
            this.us = us;
        }

        private void btn_enrere_registre_Click(object sender, RoutedEventArgs e)
        {
            //IniciUsuari enrere = new IniciUsuari();
            Close();
            //enrere.Show();
        }


        
        private void btn_EditarPronostic_Click(object sender, RoutedEventArgs e)
        {
            int id_partit = Convert.ToInt32(tb_partit.Text);
            int golsA = Convert.ToInt32(tb_pronosticGolsA.Text);
            int golsB = Convert.ToInt32(tb_pronosticGolsB.Text);

            try
            {
                Pronostic po = new Pronostic(us, id_partit, golsA, golsB);
                if(po.Guardat) 
                {
                    MessageBox.Show("Pronostic guardat");
                    tb_partit.Text="";
                    tb_pronosticGolsA.Text="";
                    tb_pronosticGolsB.Text="";
                }
                else { MessageBox.Show("Pronostic NO guardat/actualitzat"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. "+ex.Message);
            }
            
        }

        private void btn_CancelarPronostic_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(tb_idPronostic.Text);

            Pronostic p = new Pronostic(id);

            p.CancelarPronostic(id);

            MessageBox.Show("Pronostic s'ha cancelat correctament");
            tb_idPronostic.Text="";
        }
    }
}
