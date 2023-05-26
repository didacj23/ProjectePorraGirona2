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

        private void btn_EditarPronostic_Click(object sender, RoutedEventArgs e)
        {
            int id_partit = Convert.ToInt32(tb_partit.Text);
            int golsA = Convert.ToInt32(tb_pronosticGolsA.Text);
            int golsB = Convert.ToInt32(tb_pronosticGolsB.Text);

            try
            {
                Pronostic po = new Pronostic(us, id_partit, golsA, golsB);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. "+ex.Message);
            }
            

            /*crear un nou objecti tipo pronostic. al constructor, mirar si ja existeix a la bd.
             si existeix, actualitzar els valors, sino afegirlo*/
        }
    }
}
