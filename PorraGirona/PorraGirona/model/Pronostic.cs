using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona
{
    internal class Pronostic
    {
        private int idPronostic;
        private Usuari usuari;
        private Partit partit;
        private string resultat;

        public int IdPronostic
        {
            get { return idPronostic; }
            set { idPronostic = value; }
        }

        public Usuari Usuari
        {
            get { return  usuari; }
            set { usuari = value; }
        }

        public string Resultat
        {
            get { return resultat; }
            set { resultat = value; }
        }

        public Partit Partit
        {
            get { return partit; }
            set { partit = value; }
        }
    

    }
}
