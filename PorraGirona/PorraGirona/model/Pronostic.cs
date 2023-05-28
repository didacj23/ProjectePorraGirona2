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
        private int idPronostic;
        private Usuari usuari;
        private Partit partit;
        private int golsEquipA;
        private int golsEquipB;
        private bool guardat;

        /// <summary>
        /// S'utilitza per crear i guardar un pronostic a la base de dades. Crea un objecte dbPronostic per
        /// buscar l'id de l'últim pronòstic guardat i així evitar problemes amb els id. Després, busca el partit
        /// pel que es vol fer el pronostic. Es comprova que el resultat del partit no sigui negatiu i que el partit 
        /// estigui programat i no iniciat i que el pronostic per aquest partit i usuari no existeixi i si és així,
        /// el guarda a la taula pronostics. Al acabar tanca la connexió de la base de dades.
        /// </summary>
        /// <param name="usuari">Usuari que vol fer el pronostic</param>
        /// <param name="id_partit">Id del partit al que es vol fer el pronostic</param>
        /// <param name="golsEquipA">Gols pronosticats per l'equip A</param>
        /// <param name="golsEquipB">Gols pronosticats per l'equip B</param>
        /// <exception cref="Exception"></exception>
        public Pronostic(Usuari usuari, int id_partit, int golsEquipA, int golsEquipB)
        {
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

        /// <summary>
        /// Aquest constructor s'utilitza per quan s'ha de cancel·lar un pronostic
        /// </summary>
        /// <param name="id"></param>
        public Pronostic(int id)
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
