using PorraGirona.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona
{
    internal class Equip
    {
        private string nom;
        private string camp;
        private string foto;
        private string categoria;
        private int totalPartitsGuanyats;
        private int totalPartitsPerduts;
        private int totalPartitsEmpatats;
        private LlistaJugadors jugadors;

        public Equip(string nom, string camp, string foto, string categoria, LlistaJugadors jugadors)
        {
            this.nom = nom;
            this.camp = camp;
            this.foto = foto;
            this.categoria = categoria;
            totalPartitsGuanyats=0;
            totalPartitsPerduts=0;
            totalPartitsEmpatats=0;
            this.jugadors=jugadors;
        }

        /*
        public Equip(string nom, string camp, string foto, string categoria, int totalPartitsGuanyats, int totalPartitsPerduts, int totalPartitsEmpatats, )
        {
            this.nom = nom;
            this.camp = camp;
            this.foto = foto;
            this.categoria = categoria;
            totalPartitsGuanyats = 0;
            totalPartitsPerduts = 0;
            totalPartitsEmpatats = 0;
            this.jugadors = jugadors;
        }*/

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Camp
        {
            get { return camp; }
            set { camp = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public int TotalPartitsGuanyats
        {
            get { return totalPartitsGuanyats;}
            set {  totalPartitsGuanyats = value; }
        }

        public int TotalPartitsPerduts
        {
            get { return totalPartitsPerduts;}
            set { totalPartitsPerduts = value;}
        }

        public int TotalPartitsEmpatats
        {
            get { return  totalPartitsEmpatats; }
            set { totalPartitsEmpatats = value; }
        }

        public LlistaJugadors Jugadors
        {
            get { return jugadors; }
            set { jugadors=value; }
        }
                

        public override string ToString()
        {
            return $"Nom: {Nom},  Camp: {Camp},  Foto: {Foto},  Categoria: {Categoria},  TotalPartitsGuanyats: {TotalPartitsGuanyats},  TotalPartitsPerduts: {TotalPartitsPerduts},  TotalPartitsEmpatats: {TotalPartitsEmpatats},  Jugadors: {Jugadors}";
        }

    }
}
