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

        private void btn_inicSessio_iniciSessio_Click(object sender, RoutedEventArgs e)
        {
            int iDpronostic = Convert.ToInt32(inp_idPartit_comprovar.Text);
            char resultatPartit = ' ';
            char resultatPronostic = ' ';

            dbPronostics pronostic = new dbPronostics();

            resultatPartit = pronostic.ObtindreEquipGuanyador(pronostic.ObtenirIdPartit(iDpronostic));

            resultatPronostic = pronostic.ObtindreEquipGuanyadorPronostic(pronostic.ObtenirIdPartit(iDpronostic));

            if(resultatPartit == resultatPronostic)
            {
                int punts = 2;
                us.ActualitzarPunts(us.Dni, punts);
            }

        }
    }
}
