using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICOMPARABLE_RECTANGLES
{
    public class Rectangle : IComparable<Rectangle>
    {
        private string nom;
        private double x;
        private double y;
        private double amplada;
        private double alçada;

        public Rectangle(string nom, double x, double y, double amplada, double alçada)
        {
            this.nom = nom;
            this.x = x;
            this.y = y;
            this.amplada = amplada;
            this.alçada = alçada;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Amplada
        {
            get { return amplada; }
            set { amplada = value; }
        }

        public double Alçada
        {
            get { return alçada; }
            set { alçada = value; }
        }

        public double Area
        {
            get
            {
                return amplada * alçada;
            }
        }

        public override string ToString()
        {
            return $"{nom};{x};{y};{amplada};{alçada};{this.Area}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Rectangle))
                return false;

            Rectangle other = (Rectangle)obj;
            return this.Area.Equals(other.Area);
        }

        public int CompareTo(Rectangle other)
        {
            int result = 0;

            //ordena nom 
            if (other == null)
            {
                result = 1;
            }
            else
            {
                this.nom.CompareTo(other.nom);
            }

            return result;

        }

        public class ComparadorX : IComparer<Rectangle>
        {

            public int Compare(Rectangle x1, Rectangle x2)
            {
                int result = 0;

                if(x1 == null && x2 == null)
                {
                    result = 0;
                }
                else if (x1 == null)
                {
                    result = -1;
                }
                else if (x2 == null)
                {
                    result = 1;
                }
                else
                {
                    result = x1.x.CompareTo(x2.x);
                }

                return result;
            }
        }

        public class ComparadorAmplada : IComparer<Rectangle>
        {

            public int Compare(Rectangle amplada1, Rectangle amplada2)
            {
                int result = 0;

                if (amplada1 == null && amplada2 == null)
                {
                    result = 0;
                }
                else if (amplada1 == null)
                {
                    result = -1;
                }
                else if (amplada2 == null)
                {
                    result = 1;
                }
                else
                {
                    result = amplada1.amplada.CompareTo(amplada2.amplada);
                }

                return result;
            }
        }

        public class ComparadorAlçada: IComparer<Rectangle>
        {

            public int Compare(Rectangle alçada1, Rectangle alçada2)
            {
                int result = 0;

                if (alçada1 == null && alçada2 == null)
                {
                    result = 0;
                }
                else if (alçada1 == null)
                {
                    result = -1;
                }
                else if (alçada2 == null)
                {
                    result = 1;
                }
                else
                {
                    result = alçada1.alçada.CompareTo(alçada2.alçada);
                }

                return result;
            }
        }

        public class ComparadorArea : IComparer<Rectangle>
        {

            public int Compare(Rectangle Area1, Rectangle Area2)
            {
                int result = 0;

                if (Area1 == null && Area2 == null)
                {
                    result = 0;
                }
                else if (Area1 == null)
                {
                    result = -1;
                }
                else if (Area2 == null)
                {
                    result = 1;
                }
                else
                {
                    result = Area1.Area.CompareTo(Area2.Area);
                }

                return result;
            }
        }
    }
}
