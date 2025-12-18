namespace ex05
{
    internal class Programa
    {
        static void Main()
        {
            Player[] equip = {
            new Player("WESTERMAN", "BASE", 1.98),
            new Player("CALATHES", "BASE", 1.95),
            new Player("ABRINES", "ALER", 2.01),
            new Player("KURIC", "ALER", 1.95),
            new Player("BOUMARO", "ALER", 1.98),
            new Player("PAU GASOL", "PIVOT", 2.16),
            new Player("MIROTIC", "PIVOT", 2.10),
            new Player("DAVIES", "PIVOT", 2.08)
        };

            HashSet<Player> jugadorsUnics = new HashSet<Player>();

            foreach (Player jugador in equip)
            {
                jugadorsUnics.Add(jugador);
            }

            foreach (Player jugador in jugadorsUnics)
            {
                Console.WriteLine(jugador);
            }
        }
    }

    public class Player : IComparable<Player>
    {
        private string nom;
        private string posicio;
        private double alcada;

        public Player(string nom, string posicio, double alcada)
        {
            this.nom = nom;
            this.posicio = posicio;
            this.alcada = alcada;
        }

        public int CompareTo(Player altre)
        {
            int comparacioAlcada = this.alcada.CompareTo(altre.alcada);
            if (comparacioAlcada != 0)
                return comparacioAlcada;

            return this.nom.CompareTo(altre.nom);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Player altre = (Player)obj;
            return nom == altre.nom && posicio == altre.posicio && alcada == altre.alcada;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nom, posicio, alcada);
        }

        public override string ToString()
        {
            return $"{nom}, {posicio}, {alcada} m";
        }
    }
}
