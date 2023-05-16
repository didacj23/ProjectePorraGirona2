using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.model
{
    internal class LlistaPartits
    {
        private List<Partit> partits;

        public List<Partit> Partits
        {
            get { return partits; }
        }

        public LlistaPartits()
        {
            partits = new List<Partit>();
        }

        public override string ToString()
        {
            string result = "Classificacio Usuari:\n";

            foreach (Partit partit in partits)
            {
                result += partit.ToString() + "\n";
            }

            return result;
        }
    }
    






}
