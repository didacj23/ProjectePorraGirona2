using PorraGirona.dades;
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
            idPartit=dbp.ObtenirUltimId();

            this.equipA = equipA;
            this.equipB = equipB;
            golsEquipA=0;
            golsEquipB=0;
            this.diaHora=diaHora;
            this.camp=camp;
            estat="programat";
        }

        //Recuperar partits PROGRAMATS des de la bdd. (Per afegir a la llista de partits de la pantalla d'inici)
        public Partit(int idPartit, Equip equipA, Equip equipB, DateTime diaHora, string camp, string estat)
        {
            this.idPartit=idPartit;
            this.equipA=equipA;
            this.equipB=equipB;
            this.diaHora=diaHora;
            this.camp=camp;
            this.estat=estat;
        }

        //Recuperar qualsevol partit de la bdd
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
        public void ProgramarPartit()
        {
            dbPartits dbp = new dbPartits();
            dbp.InsertarPartit(this);                       
        }



        public override string ToString()
        {
            return $"IdPartit: {IdPartit},  Equip A: {EquipA},  Equip B: {EquipB},  Gols Equip A: {GolsEquipA},  Gols Equip B: {GolsEquipB}, Dia i Hora: {DiaHora},  Camp: {Camp},  Estat: {Estat}";
        }

    }
}
