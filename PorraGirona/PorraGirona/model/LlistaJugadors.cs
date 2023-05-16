using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.model
{
    internal class LlistaJugadors
    {
        private List<Jugador> listJugador;

        public List<Jugador> ListJugador
        {
            get { return listJugador; }
            set { listJugador=value; }
        }

        public LlistaJugadors()
        {
            listJugador=new List<Jugador>();
        }


        public bool AfegirJugador(Jugador j)
        {
            if(listJugador.Contains(j))return false;
            else
            {
                listJugador.Add(j);
                return true;
            }
        }

        public bool EliminarJugador(Jugador j)
        {
            if (listJugador.Contains(j))
            {
                listJugador.Remove(j);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string s = "";

            foreach (Jugador j in listJugador)
            {
                s += j.Nom + ", ";
            }

            return s;
        }
    }
}
