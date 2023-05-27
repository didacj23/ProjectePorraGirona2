using PorraGirona.dades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PorraGirona.model
{
    public class Sessio
    {
        private string dni;
        private string pass;
        private bool valida;
        private Usuari usuari;
        public bool admin;


        /// <summary>
        /// Crea un objecte de tipus Sessio amb paràmetres dni i pass introduits x usuari a pantalla
        /// de inici de sessió. Crea un objecte dbUsuaris i executa el mètode de IniciarSessió, que retorn true
        /// o false si la contrasenya es correcta o no. Si és correcta, l'atribut valida es posa a true i 
        /// es recupera l'usuari amb el mètode BuscarUsuari. Si l'usuari és administrador, posa en true l'atribut admin
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="pass"></param>
        public Sessio(string dni, string pass)
        {
            this.dni=dni;
            this.pass=pass;

            dbUsuaris c = new dbUsuaris();

            if(c.IniciarSessió(this))
            {
                //sessio vàlida
                valida=true;
                usuari=c.BuscarUsuari(dni);
                if (usuari is Administrador) admin = true;
                else admin = false;
            }
            else
            {
                //sessio NO valida
                valida=false;
            }

        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Pass
        { 
            get { return pass; } 
            set { pass = value; }
        }

        public Usuari Usuari
        {
            get { return usuari; }
        }

        public bool Admin
        {
            get{ return admin; }
        }

        public bool Valida
        {
            get { return valida; }
            //set { valida = value; }
        }

        

    }
}
