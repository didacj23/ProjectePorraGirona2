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

        public bool AfegirPartit(Partit p)
        {
            if (partits.Contains(p)) return false;
            else
            {
                partits.Add(p);
                return true;
            }
        }

        public bool EliminarPartit(Partit p)
        {
            if (partits.Contains(p))
            {
                partits.Remove(p);
                return true;
            }
            else
            {
                return false;
            }
        }


    } 

}
