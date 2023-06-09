﻿using PorraGirona.dades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.model
{
    public class Partit
    {
        private static int contPartit=0;
        private int idPartit;
        private Equip equipA;
        private Equip equipB;
        private int golsEquipA;
        private int golsEquipB;
        private DateTime diaHora;
        private string camp;
        private string estat;

        public Partit()
        {
            idPartit = -1;          
            golsEquipA = 0;
            golsEquipB = 0;

            estat="programat";
        }
       
        public Partit(Equip equipA, Equip equipB, DateTime diaHora, string camp)
        {
            dbPartits dbp  =new dbPartits();
            idPartit=dbp.ObtenirUltimId()+1;

            this.equipA = equipA;
            this.equipB = equipB;
            golsEquipA=0;
            golsEquipB=0;
            this.diaHora=diaHora;
            this.camp=camp;
            estat="programat";
        }

        //
        /// <summary>
        /// Aquest constructor s'utilitza per Recuperar partits PROGRAMATS des de la bdd i per afegir a la llista de partits de la pantalla d'inici.
        /// </summary>
        /// <param name="idPartit">Id del partit</param>
        /// <param name="equipA">Equip A</param>
        /// <param name="equipB">Equip B</param>
        /// <param name="diaHora">Dia i Hora</param>
        /// <param name="camp">Camp</param>
        /// <param name="estat">Estat del partit</param>
        public Partit(int idPartit, Equip equipA, Equip equipB, DateTime diaHora, string camp, string estat)
        {
            this.idPartit=idPartit;
            this.equipA=equipA;
            this.equipB=equipB;
            this.diaHora=diaHora;
            this.camp=camp;
            this.estat=estat;
        }

        /// <summary>
        /// Aquest mètode s'utilitza per recuperar qualsevol partit de la base de dades.
        /// </summary>
        /// <param name="idPartit"></param>
        /// <param name="equipA"></param>
        /// <param name="equipB"></param>
        /// <param name="golsEquipA"></param>
        /// <param name="golsEquipB"></param>
        /// <param name="diaHora"></param>
        /// <param name="camp"></param>
        /// <param name="estat"></param>
        public Partit(int idPartit, Equip equipA, Equip equipB, int golsEquipA, int golsEquipB, DateTime diaHora, string camp, string estat)
        {
            this.idPartit=idPartit;
            this.equipA=equipA;
            this.equipB=equipB;
            this.golsEquipA=golsEquipA;
            this.golsEquipB=golsEquipB;
            this.diaHora=diaHora;
            this.camp=camp;
            this.estat=estat;
        }

               
        public int ContPartit
        {
            get { return contPartit;}
        }

        public int IdPartit
        {
            get { return idPartit; }
        }

        public Equip EquipA
        {
            get { return equipA; }
        }

        public Equip EquipB
        {
            get { return equipB; }
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

        public DateTime DiaHora
        {
            get { return diaHora; }
            set { diaHora = value; }
        }

        public string Camp
        {
            get { return camp; }
            set { camp=value; }
        }

        public string Estat
        {
            get { return estat; }
            set { estat=value; }
        }

        public dbPartits Connexio { get; set; }

        public string Equips
        {
            get { return $"{EquipA} vs {EquipB}"; }
        }
        public bool ProgramarPartit()
        {
            dbPartits dbp = new dbPartits();
            if(dbp.InsertarPartit(this))
            {
                return true;
            }else return false;
        }

        public void EntrarResultat(int id, int Glocal, int Gvisitant)
        {
            dbPartits partits = new dbPartits();
            partits.EntrarResultat(id, Glocal, Gvisitant);
        }



        public override string ToString()
        {
            return $"IdPartit: {IdPartit},  Equip A: {EquipA},  Equip B: {EquipB},  Gols Equip A: {GolsEquipA},  Gols Equip B: {GolsEquipB}, Dia i Hora: {DiaHora},  Camp: {Camp},  Estat: {Estat}";
        }

    }
}
