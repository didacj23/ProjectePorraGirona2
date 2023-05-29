using PorraGirona.dades;
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
    /// Lógica de interacción para ComprovarPronostic.xaml
    /// </summary>
    public partial class ComprovarPronostic : Window
    {

        public Usuari us = new Usuari();
        public ComprovarPronostic(Usuari us)
        {
            InitializeComponent();
            this.us = us;
        }

        private void btn_comprovar_comprovar_Click(object sender, RoutedEventArgs e)
        {
            int iDpronostic = Convert.ToInt32(inp_idPartit_comprovar.Text);

            Pronostic pr = new Pronostic(us, iDpronostic);

            if(pr.ComprovarPronostic())
            {
                MessageBox.Show("El pronostic és encertat");
            }
            else
            {
                MessageBox.Show("El pronostic és erroni");
            }

        }

        private void btn_enrere_registre_Click(object sender, RoutedEventArgs e)
        {
            
            Close();

            
        }
    }
}
