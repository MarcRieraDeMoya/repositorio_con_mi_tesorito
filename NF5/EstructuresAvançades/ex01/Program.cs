using System.Net.Http.Headers;

namespace ex01
{
    internal class Programa
    {
        static void Main(string[] args)
        {
            HashSet<School> escoles1 = CarregarEscoles("SCHOOLS1.csv");
            HashSet<School> escoles2 = CarregarEscoles("SCHOOLS2.csv");

            Console.WriteLine("Centres només al primer fitxer:");
            HashSet<School> nomésPrimer = new HashSet<School>(escoles1);
            nomésPrimer.ExceptWith(escoles2);
            ImprimirEscoles(nomésPrimer);

            Console.WriteLine("Centres només al segon fitxer:");
            HashSet<School> nomésSegon = new HashSet<School>(escoles2);
            nomésSegon.ExceptWith(escoles1);
            ImprimirEscoles(nomésSegon);

            Console.WriteLine("Centres a tots dos fitxers:");
            HashSet<School> aTotsDos = new HashSet<School>(escoles1);
            aTotsDos.IntersectWith(escoles2);
            ImprimirEscoles(aTotsDos);

            Console.WriteLine("Centres a algun dels dos fitxers:");
            HashSet<School> aAlgun = new HashSet<School>(escoles1);
            aAlgun.UnionWith(escoles2);
            ImprimirEscoles(aAlgun);

            Console.WriteLine("Centres exclusivament al primer o al segon fitxer:");
            HashSet<School> exclusius = new HashSet<School>(escoles1);
            exclusius.SymmetricExceptWith(escoles2);
            ImprimirEscoles(exclusius);
        }

        static HashSet<School> CarregarEscoles(string rutaFitxer)
        {
            HashSet<School> escoles = new HashSet<School>();
            foreach (string linia in File.ReadLines(rutaFitxer))
            {
                string[] camps = linia.Split(',');
                if (camps.Length >= 4)
                {
                    escoles.Add(new School(camps[0], camps[1], camps[2], camps[3]));
                }
            }
            return escoles;
        }

        static void ImprimirEscoles(HashSet<School> escoles)
        {
            foreach (School escola in escoles)
            {
                Console.WriteLine(escola);
            }
            Console.WriteLine($"Total: {escoles.Count}\n");
        }
    }

    public class School
    {
        private string codi;
        private string nom;
        private string cp;
        private string municipi;

        public School()
        {
            codi = "";
            nom = "";
            cp = "";
            municipi = "";
        }

        public School(string codi, string nom, string codiPostal, string municipi)
        {
            this.codi = codi;
            this.nom = nom;
            this.cp = codiPostal;
            this.municipi = municipi;
        }

        public string Codi => codi;
        public string Nom => nom;
        public string CodiPostal => cp;
        public string Municipi => municipi;

        public override bool Equals(object obj)
        {
            if (obj is School altraEscola)
            {
                return this.codi == altraEscola.codi;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return codi.GetHashCode();
        }

        public override string ToString()
        {
            return $"{codi}, {nom}, {cp}, {municipi}";
        }
    }



}
