using PorraGirona.dades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.model
{
    internal class LlistaPronostics
    {
        private List<Pronostic> pronostics;

        public List<Pronostic> Pronostics
        {
            get { return pronostics; }
        }

        public LlistaPronostics()
        {
            pronostics = new List<Pronostic>();
        }

        public bool AfegirPronostic(Pronostic pr)
        {
            if (pronostics.Contains(pr)) return false;
            else
            {
                pronostics.Add(pr);
                return true;
            }
        }

        public bool EliminarPronostic(Pronostic pr)
        {
            if (pronostics.Contains(pr))
            {
                pronostics.Remove(pr);
                return true;
            }
            else
            {
                return false;
            }
        }

        

    }
}
