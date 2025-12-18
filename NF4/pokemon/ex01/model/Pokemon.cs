using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01.model
{
    internal class Pokemon : ICloneable, IComparable
    {
        private string nom;
        private double atac;
        private double defensa;
        private double velocitat;


        public Pokemon()
        {
            nom = "";
            atac = 0;
            defensa = 0;
            velocitat = 0;
        }

        public Pokemon(string nom, double atac, double defensa , double velocitat)
        {
            this.nom = nom;
            this.atac = atac;
            this.defensa = defensa;
            this.velocitat = velocitat;
        }


        public string Nom { get { return nom; } set { nom = value; }  }

        public double Atac { get { return atac; } set { atac = value; } }

        public double Defensa { get { return defensa; } set { defensa = value; } }

        public double Velocitat { get { return velocitat; } set { velocitat = value; } }

        


        public override string ToString()
        {
            return $"{nom}, {atac}, {defensa}, {velocitat}";
        }


        public override bool Equals(object? obj)
        {
            bool iguals = false;
            Pokemon p;
            if(obj == null)
            {
                iguals = false;
            }
            else
            {
                if(obj is Pokemon)
                {
                    p = (Pokemon)obj;

                    if(p.Nom == nom && p.Atac == atac && p.Defensa == defensa && p.Velocitat == velocitat)
                    {
                        iguals = true;
                    }
                }
                else
                {
                    iguals = false;
                }
            }

            return iguals;
        }

        public object Clone()
        {
            return Clonar() ;
        }

        public Pokemon Clonar()
        {
            Pokemon copia = new Pokemon();

            copia.nom = nom;
            copia.atac = atac;
            copia.defensa = defensa;
            copia.velocitat = velocitat;

            return copia;

        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }




    }
}
