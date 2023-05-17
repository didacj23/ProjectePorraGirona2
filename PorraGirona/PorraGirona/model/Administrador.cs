using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.model
{
    internal class Administrador:Usuari
    {
        public Administrador(string nom, string cognom, string dni):base(nom, cognom, dni) { }

        public bool CrearJugador(string dni, string nom, string cognom, Equip equip, string posicio, int numero)
        {
            
            Jugador j = new Jugador(dni, nom, cognom, equip, posicio, numero);

            return true;
        }
    }
}
