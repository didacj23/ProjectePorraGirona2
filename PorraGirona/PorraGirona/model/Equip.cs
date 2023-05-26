using PorraGirona.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona
{
    public class Equip
    {
        private string nom;
        private string camp;
        private string foto;
        private int totalPartitsGuanyats;
        private int totalPartitsPerduts;
        private int totalPartitsEmpatats;

        public Equip()
        {
            nom="";
            camp="";
            foto="";
            totalPartitsGuanyats=0;
            totalPartitsPerduts=0;
            totalPartitsEmpatats=0;
        }

        public Equip(string nom, string camp, string foto)
        {
            this.nom = nom;
            this.camp = camp;
            this.foto = foto;
            totalPartitsGuanyats=0;
            totalPartitsPerduts=0;
            totalPartitsEmpatats=0;
        }

        
        public Equip(string nom, string camp, string foto, int totalPartitsGuanyats, int totalPartitsPerduts, int totalPartitsEmpatats)
        {
            this.nom = nom;
            this.camp = camp;
            this.foto = foto;
            this.totalPartitsGuanyats = 0;
            this.totalPartitsPerduts = 0;
            this.totalPartitsEmpatats = 0;
        }

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
                

        public override string ToString()
        {
            return $"Nom: {Nom},  Camp: {Camp},  Foto: {Foto},  TotalPartitsGuanyats: {TotalPartitsGuanyats},  TotalPartitsPerduts: {TotalPartitsPerduts},  TotalPartitsEmpatats: {TotalPartitsEmpatats}";
        }

    }
}
