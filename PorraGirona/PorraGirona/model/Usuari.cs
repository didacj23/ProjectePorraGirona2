using MySql.Data.MySqlClient;
using PorraGirona.dades;
using PorraGirona.model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PorraGirona
{
    public class Usuari
    {
        private string dni;
        private string contrasenya;
        private string nom;
        private string cognom;
        private int puntsAcumulats;
        private LlistaPronostics lpr;
        

        public Usuari()
        {
            dni = "";
            contrasenya="";
            nom = "";
            cognom = "";            
            puntsAcumulats = 0;  
            
            
        }

        //guarda a la base de dades
        public Usuari(string dni, string contrasenya, string nom, string cognom)
        {
            this.dni = dni;
            this.contrasenya= contrasenya;
            this.nom = nom;
            this.cognom = cognom;            
            puntsAcumulats = 0;
            LlistaPronostics lpr;

            dbUsuaris dbu = new dbUsuaris();
            
            if(dbu.BuscarUsuari(dni)== null) //si l'usuari que s'esta creant no existeix, el guarda
            {
                dbu.InsertarUsuari(this);
            }
            else
            {
                throw new Exception("Aquest DNI ja està registrat");
            }
           
        }

        //no guarda a la base de dades. es fa servir per obtenir un usuari de la base de dades
        public Usuari(string dni, string contrasenya, string nom, string cognom, int puntsAcumulats, LlistaPronostics lpr)
        {
            this.dni = dni;
            this.contrasenya = contrasenya;
            this.nom = nom;
            this.cognom = cognom;
            this.puntsAcumulats = puntsAcumulats;
            this.lpr=lpr;
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
            set { contrasenya = value;}
        }

        public LlistaPronostics Pronostics
        {
            get { return  lpr; }
        }

        /*
        public int Pronosticar(Partit partit, int golsA, int golsB)
        {
            int r=-1;

            if(partit.Estat=="programat")
            {
                Pronostic pr = new Pronostic(partit, golsA, golsB);
                r=0;
            }else if (partit.Estat=="encurs") r=1;
            else if(partit.Estat=="finalitzat") r=2;      
            
            return r;
        }*/

        public override string ToString()
        {
            return $"Usuari [DNI: {dni}, Nom: {nom}, Cognom: {cognom}, Punts acumulats: {puntsAcumulats}]";
        }
    }
}