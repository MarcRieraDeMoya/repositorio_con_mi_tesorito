using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01.MODEL
{
    class Producte
    {
        private int id;
        private string nom;
        private double preu;
        private int quantitat;
        private string categoria;

        public Producte() : this(-1, "", 0, 0, "UNDEFINED") { }

        public Producte(int id, string nom, double preu, int quantitat) :
            this(id, nom, preu, quantitat, "UNDEFINED")
        { }

        public Producte(int id, string nom, double preu, int quantitat, string categoria)
        {
            this.id = id;
            this.nom = nom;
            this.preu = preu;
            this.quantitat = quantitat;
            this.categoria = categoria;
        }

        //IMPLEMETAR PROPIETATS I MÈTODES

        /// <summary>
        /// Propietat que retorna la ID del producte.
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Propietat que retorna el nom del producte i ens permet modificarlo.
        /// </summary>
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        /// <summary>
        /// Propietat que retorna la quantitat del producte i ens permet modificarla. Si el preu es inferior a 0, retorna una excepció.
        /// </summary>
        public double Preu
        {
            get { return this.preu; }
            set
            {
                if (value < 0) throw new ArgumentException("El preu no pot ser negatiu");
                this.preu = value;
            }
        }

        /// <summary>
        /// Propietat que retorna la quantitat del producte i ens permet modificarla. Si la quantitat es inferior a 0, retorna una excepció.
        /// </summary>
        public int Quantitat
        {
            get { return this.quantitat; }
            set
            {
                if (value < 0) throw new ArgumentException("La quantitat no pot ser negativa");
                this.quantitat = value;
            }
        }

        /// <summary>
        /// Propietat que retorna la categoria del producte i ens permet modificarla.
        /// </summary>
        public string Categoria
        {
            get { return this.categoria; }
            set { this.categoria = value; }
        }

        /// <summary>
        /// Propietat que retorna el valor actual del producte.
        /// </summary>
        public double ValorActual
        {
            get { return this.quantitat * this.preu; }
        }

        /// <summary>
        /// Mètode que retorna una cadena amb la informació del producte.
        /// </summary>
        /// <returns>string amb la informació del producte</returns>
        public override string ToString()
        {
            return $"{Id};{Nom};{Preu};{Quantitat};{Categoria}";
        }   
    }
}
