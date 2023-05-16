using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona
{
    internal class ClassificacioUsuaris
    {
        private List<Usuari> usuaris;

        public ClassificacioUsuaris()
        {
            usuaris = new List<Usuari>();
        }

        public List<Usuari> Usuaris
        {
            get { return usuaris; }
            set { usuaris = value; }
        }

        public override string ToString()
        {
            string result = "Classificacio Usuari:\n";

            foreach (Usuari usuari in usuaris)
            {
                result += usuari.ToString() + "\n";
            }

            return result;
        }
    }
}
