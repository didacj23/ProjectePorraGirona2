using PorraGirona.dades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PorraGirona.model
{
    class Sessio
    {
        private string dni;
        private string pass;
        private bool valida;


        /// <summary>
        /// Crea un objecte de tipus Sessio amb paràmetres dni i pass introduits x usuari a pantalla
        /// de inici de sessió. Crea un objecte Connexio i passa els detalls del servidor x la connectionString
        /// El mètode ´c.IniciarSessio(this) torna true o false depenent de si amb el dni introduit,
        /// coincideix la contrasenya introduida amb la contrasenya de la base de dades on hi ha
        /// guardat l'usuari (dni+pass)
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="pass"></param>
        public Sessio(string dni, string pass)
        {
            this.dni=dni;
            this.pass=pass;

            Connexio c = new Connexio("localhost", "porragirona", "root", "");

            if(c.IniciarSessió(this))
            {
                //sessio vàlida
                valida=true;
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

        public bool Valida
        {
            get { return valida; }
            //set { valida = value; }
        }

    }
}
