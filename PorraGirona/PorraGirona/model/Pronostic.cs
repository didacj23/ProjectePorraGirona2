using PorraGirona.dades;
using PorraGirona.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona
{
    internal class Pronostic
    {
        private static int contPronostic = 0;
        private int idPronostic;
        private Usuari usuari;
        private Partit partit;
        private int golsEquipA;
        private int golsEquipB;

        public Pronostic(Partit p, int golsEquipA, int golsEquipB) 
        {
            idPronostic = contPronostic;
            contPronostic++;

            partit=p;
            this.golsEquipA=golsEquipA;
            this.golsEquipB = golsEquipB;

            //guardar pronostic a la bd
            Connexio c = new Connexio("localhost", "porragirona", "root", "");

        }


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

        public int GolsEquipA
        {
            get { return golsEquipA; }
            set { golsEquipA=value; }
        }
        public int GolsEquipB
        {
            get { return golsEquipB; }
            set { golsEquipB = value; }
        }

        public Partit Partit
        {
            get { return partit; }
            set { partit = value; }
        }

        /*
        public string ResultatPartit()
        {

        }*/

        public override string ToString()
        {
            return $"Pronostic [ID: {idPronostic}, Usuari: {usuari.Dni}, Partit: {partit.EquipA} vs {partit.EquipB}]";
        }
    }

    
}
