namespace ex01
{
    internal class Equips : IComparable<Equips>
    {
        private string nom;
        private int golsF;
        private int golsC;
        private int punts;


        public Equips(string nomb, int golfav, int golscont, int pun)
        {
            nom = nomb;
            golsF = golfav;
            golsC = golscont;
            punts = pun;
        }

        public Equips(string csv)
        {
            string[] elements = csv.Split(";");
            if (elements.Length == 4)
            {
                nom = elements[0];
                golsF = Convert.ToInt32(elements[1]);
                golsC = Convert.ToInt32(elements[2]);
                punts = Convert.ToInt32(elements[3]);
            }


        }

        public string Nom
        {
            get { return nom; }

            set { nom = value; }
        }

        public int GolsAFavor
        {
            get { return golsF; }

            set
            {
                golsF = value;
            }
        }

        public int GolsEnContra
        {
            get { return golsC; }

            set { golsC = value; }
        }

        public int Punts
        {
            get { return punts; }

            set { punts = value; }
        }



        public override string ToString()
        {
            return $"{nom};{golsF};{golsC};{punts}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Equips))
                return false;

            Equips other = (Equips)obj;

            return this.Equals(other);

        }

        public int CompareTo(Equips? other)
        {
            int result;

            if (other == null)
            {
                result = 1;
            }
            else
            {
                result = this.nom.CompareTo(other.nom);
            }

            return result;

        }


        public class ComparadorGolsF : IComparer<Equips>
        {
            public int Compare(Equips? golsF1, Equips? golsF2)
            {
                int result;

                if (golsF1 == null && golsF2 == null)
                {
                    result = 0;
                }
                else if (golsF1 == null)
                {
                    result = -1;
                }
                else if (golsF2 == null)
                {
                    result = 1;
                }
                else
                {
                    result = golsF1.golsF.CompareTo(golsF2.golsF);
                }

                return result;
            }
        }

        public class ComparadorGolsC : IComparer<Equips>
        {
            public int Compare(Equips? golsC1, Equips? golsC2)
            {
                int result;

                if (golsC1 == null && golsC2 == null)
                {
                    result = 0;
                }
                else if (golsC1 == null)
                {
                    result = -1;
                }
                else if (golsC2 == null)
                {
                    result = 1;
                }
                else
                {
                    result = golsC1.golsC.CompareTo(golsC2.golsC);
                }

                return result;
            }
        }


        public class ComparadorPunts : IComparer<Equips>
        {
            public int Compare(Equips? Punts1, Equips? Punts2)
            {
                int result;

                if (Punts1 == null && Punts2 == null)
                {
                    result = 0;
                }
                else if (Punts1 == null)
                {
                    result = -1;
                }
                else if (Punts2 == null)
                {
                    result = 1;
                }
                else
                {
                    result = Punts1.punts.CompareTo(Punts2.punts);
                }

                return result;
            }
        }

    }
}
