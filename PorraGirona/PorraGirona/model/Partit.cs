using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona
{
    internal class Partit
    {
        private static int contPartit=0;
        private int idPartit;
        private Equip equipA;
        private Equip equipB;
        private int golsEquipA;
        private int golsEquipB;
        private DateTime diaHora;
        private string temporada;
        private string camp;
        private string estat;

        public Partit(Equip equipA, Equip equipB, DateTime diaHora, string temporada, string camp)
        {
            idPartit=contPartit;
            contPartit++;

            this.equipA = equipA;
            this.equipB = equipB;
            golsEquipA=0;
            golsEquipB=0;
            this.diaHora=diaHora;
            this.temporada=temporada;
            this.camp=camp;
            estat="programat";
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

        public string Temporada
        {
            get { return temporada; }
            set { temporada=value; }
        }

        public string Camp
        {
            get { return camp; }
            set { camp=value; }
        }

        public string Estat
        {
            get { return estat; }
            set { estat=value; }}
        }

        /*public override string ToString()
        {
            return
        }*/

    }
}
