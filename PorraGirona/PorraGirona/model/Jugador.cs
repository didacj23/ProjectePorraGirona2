using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona.model
{
    internal class Jugador
    {
        private string dni;
        private string nom;
        private string cognom;
        private Equip equip;
        private string posicio;
        private int numero;

        public Jugador(string dni, string nom, string cognom, Equip equip, string posicio, int numero)
        {
            this.dni = dni;
            this.nom = nom;
            this.cognom = cognom;
            this.equip = equip;
            this.posicio = posicio;
            this.numero = numero;
        }

        public string DNI
        {
            get { return dni; }
        }

        public string Nom
        {
            get { return nom; }
        }

        public string Cognom
        {
            get { return cognom; }
        }

        public Equip Equip
        {
            get { return equip; }
            set { equip=value; }
        }

        public string Posicio
        {
            get { return posicio; }
            set { posicio = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public override string ToString()
        {
            return $"Dni: {DNI},  Nom: {Nom},  Cognom: {Cognom},  Equip: {Equip},  Posicio: {Posicio},  Numero: {Numero}";
        }
    }
}
