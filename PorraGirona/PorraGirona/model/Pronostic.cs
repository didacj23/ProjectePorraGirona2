using PorraGirona.dades;
using PorraGirona.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona
{
    public class Pronostic
    {
        private static int contPronostic = 0;
        private int idPronostic;
        private Usuari usuari;
        private Partit partit;
        private int golsEquipA;
        private int golsEquipB;

        public Pronostic(Usuari usuari, int id_partit, int golsEquipA, int golsEquipB) 
        {
            idPronostic = contPronostic;
            contPronostic++;

            this.usuari = usuari;

            dbPartits dbp = new dbPartits();
            partit = dbp.BuscarPartit(id_partit);

            this.golsEquipA=golsEquipA;
            this.golsEquipB = golsEquipB;

            dbPronostics dbpr = new dbPronostics();
            if(dbpr.BuscarPronostic(idPronostic) is null) //si no existiex el pronòstic
            {
                dbpr.InsertarPronostic(this);
            }
            else //si existeix el pronòstic. torna el pronostic
            {

            }

        }

        public Pronostic(int idPronostic, Usuari usuari, Partit partit, int golsEquipA, int golsEquipB)
        {
            this.idPronostic = idPronostic;
            this.usuari = usuari;
            this.partit = partit;
            this.golsEquipA=golsEquipA;
            this.golsEquipB=golsEquipB;
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

        public string Equips
        {
            get { return $"{Partit.EquipA.Nom} vs {Partit.EquipB.Nom}"; }
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
