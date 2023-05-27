using PorraGirona.dades;
using PorraGirona.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PorraGirona
{
    public class Pronostic
    {
        //private static int contPronostic = 0;
        private int idPronostic;
        private Usuari usuari;
        private Partit partit;
        private int golsEquipA;
        private int golsEquipB;
        private bool guardat;

        public Pronostic(Usuari usuari, int id_partit, int golsEquipA, int golsEquipB)
        {
            //idPronostic = contPronostic;
            //contPronostic++;
            dbPronostics dbpr = new dbPronostics();

            idPronostic = dbpr.ObtenirUltimId()+1;

            this.usuari = usuari;

            dbPartits dbp = new dbPartits();
            partit = dbp.BuscarPartit(id_partit);

            //comprovar que el resultat no sigui negatiu
            if (golsEquipA>=0 && golsEquipB >= 0) 
            {
                this.golsEquipA = golsEquipA;
                this.golsEquipB = golsEquipB;
            }
            else
            {
                throw new Exception("Els gols pronosticats no poden ser negatius.");
            }
               

            if(partit.Estat=="programat") //si el partit NO ha començat
            {
                
                if (dbpr.BuscarPronostic(usuari, partit.IdPartit) is null) //si no existiex el pronòstic
                {                
                    dbpr.InsertarPronostic(this);
                    guardat=true;
                }
                else //si existeix el pronòstic
                {
                    dbpr.ActualitzarPronostic(this);
                    guardat = true;
                }
            }else if(partit.Estat == "iniciat")
            {
                throw new Exception("El partit ja ha començat");
            }
            else
            {
                throw new Exception("El partit ja ha finalitzat");

            }


        }

        public Pronostic(int id) //es fa servir x cancelar un pronostic
        {
            idPronostic=id;
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

        public bool Guardat
        {
            get { return  guardat; }
        }

        /*
        public string ResultatPartit()
        {

        }*/

        public void CancelarPronostic(int idPronostic)
        {
            dbPronostics dbpr = new dbPronostics();
            dbpr.CancelarPronostic(idPronostic);
        }

        public override string ToString()
        {
            return $"Pronostic [ID: {idPronostic}, Usuari: {usuari.Dni}, Partit: {partit.EquipA} vs {partit.EquipB}]";
        }
    }

    
}
