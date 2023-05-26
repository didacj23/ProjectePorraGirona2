using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.model
{
    internal class Administrador:Usuari
    {
        public Administrador(string dni, string pass, string nom, string cognom):base(dni, pass, nom, cognom) { }

        public Administrador(string dni, string pass, string nom, string cognom, int puntsAcumulats, LlistaPronostics lpr) : base(dni, pass, nom, cognom, puntsAcumulats, lpr) { }





    }
}
