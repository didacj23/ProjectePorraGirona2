using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PorraGirona
{
    internal class Usuari
    {
        private string dni;
        private string nom;
        private string cognom;
        private int puntsAcumulats;

        public string Dni
        {
            get { return dni; }
            set
            {
                
                if (Regex.IsMatch(value, @"^\d{8}[a-zA-Z]$"))
                {
                    dni = value;
                }
                else
                {
                    throw new ArgumentException("El dni no es correcte");
                }
            }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Cognom
        {
            get { return cognom; }
            set { cognom = value; }
        }

        public int PuntsAcumulats
        {
            get { return puntsAcumulats; }
            set{ puntsAcumulats = value; }
        }

        public Usuari ()
        {
            nom = string.Empty;
            cognom = string.Empty;
            dni = string.Empty;
            puntsAcumulats = 0;
        }

        public Usuari(string nom, string cognom, string dni, int puntsAcumulats)
        {
            this.nom = nom;
            this.cognom = cognom;
            this.dni = dni;
            this.puntsAcumulats = 0;

        }

        



    }
}
