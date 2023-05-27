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
    /// Lógica de interacción para Pronostic.xaml
    /// </summary>
    public partial class Pronostic : Window
    {
        public Usuari us;
        public Pronostic(Usuari us)
        {            
            InitializeComponent();
            this.us = us;
        }

        private void btn_enrere_registre_Click(object sender, RoutedEventArgs e)
        {
            IniciUsuari enrere = new IniciUsuari();
            enrere.Show();

        }

        /*
        private void btn_EditarPronostic_Click(object sender, RoutedEventArgs e)
        {
            int id_partit = Convert.ToInt32(tb_partit.Text);
            int golsA = Convert.ToInt32(tb_pronosticGolsA.Text);
            int golsB = Convert.ToInt32(tb_pronosticGolsB.Text);

            Pronostic po = new Pronostic(us, id_partit, golsA, golsB);


        }
        */
    }
}
