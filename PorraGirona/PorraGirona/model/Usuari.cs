using MySql.Data.MySqlClient;
using PorraGirona.dades;
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
        private string contrasenya;
        private string nom;
        private string cognom;
        private int puntsAcumulats;

        public Usuari()
        {
            dni = string.Empty;
            contrasenya="";
            nom = string.Empty;
            cognom = string.Empty;            
            puntsAcumulats = 0;            
        }

        public Usuari(string dni, string contrasenya, string nom, string cognom)
        {
            this.dni = dni;
            this.contrasenya= contrasenya;
            this.nom = nom;
            this.cognom = cognom;            
            puntsAcumulats = 0;


            //Conectar amb base d dades x guardar usuari        

            Connexio c = new Connexio("localhost", "porragirona", "root", "");
            c.InsertarUsuari(this);
        }

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

        public string Contrasenya
        {
            get { return contrasenya; }
        }


        /*public bool Pronosticar(Partit partit, int golsA, int golsB)
        {
            
        }*/

        public override string ToString()
        {
            return $"Usuari [DNI: {dni}, Nom: {nom}, Cognom: {cognom}, Punts acumulats: {puntsAcumulats}]";
        }
    }
}