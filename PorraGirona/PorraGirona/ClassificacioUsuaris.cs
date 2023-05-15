using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona
{
    internal class ClassificacioUsuaris
    {
        private List<Usuari> usuari;

        public ClassificacioUsuaris()
        {
            usuari = new List<Usuari>();
        }

        public List<Usuari> Usuari
        {
            get { return usuari; }
            set { usuari = value; }
        }

        public override string ToString()
        {
            string result = "Classificacio Usuari:\n";

            foreach (Usuari usuari in usuari)
            {
                result += usuari.ToString() + "\n";
            }

            return result;
        }
    }
}
