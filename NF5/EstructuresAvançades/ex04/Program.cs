namespace ex04
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, School> escoles = new Dictionary<string, School>();

            // Carregar automàticament des dels fitxers CSV
            CarregarDesDeCSV(escoles, "schools1.csv");
            CarregarDesDeCSV(escoles, "schools2.csv");

            bool sortir = false;

            while (!sortir)
            {
                Console.WriteLine("\nMenú CRUD per a centres escolars:");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Actualitzar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Consultar (un)");
                Console.WriteLine("5. Consultar (tots)");
                Console.WriteLine("6. Consultar (molts per lletra inicial)");
                Console.WriteLine("7. Sortir");
                Console.Write("Selecciona una opció: ");

                string opcio = Console.ReadLine();
                switch (opcio)
                {
                    case "1":
                        Crear(escoles);
                        break;
                    case "2":
                        Actualitzar(escoles);
                        break;
                    case "3":
                        Eliminar(escoles);
                        break;
                    case "4":
                        ConsultarUn(escoles);
                        break;
                    case "5":
                        ConsultarTots(escoles);
                        break;
                    case "6":
                        ConsultarMolts(escoles);
                        break;
                    case "7":
                        sortir = true;
                        break;
                    default:
                        Console.WriteLine("Opció no vàlida. Torna-ho a intentar.");
                        break;
                }
            }
        }

        static void CarregarDesDeCSV(Dictionary<string, School> escoles, string rutaFitxer)
        {
            if (!File.Exists(rutaFitxer))
                return;

            foreach (string linia in File.ReadLines(rutaFitxer))
            {
                string[] parts = linia.Split(';'); // Canvia a ',' si el fitxer usa comes
                if (parts.Length >= 4)
                {
                    string codi = parts[0].Trim();
                    string nom = parts[1].Trim();
                    string cp = parts[2].Trim();
                    string municipi = parts[3].Trim();

                    if (!escoles.ContainsKey(codi))
                    {
                        escoles[codi] = new School(codi, nom, cp, municipi);
                    }
                }
            }
        }

        static void Crear(Dictionary<string, School> escoles)
        {
            Console.Write("Introdueix el codi del centre: ");
            string codi = Console.ReadLine();

            if (escoles.ContainsKey(codi))
            {
                Console.WriteLine("El centre ja existeix.");
                return;
            }

            Console.Write("Nom del centre: ");
            string nom = Console.ReadLine();
            Console.Write("Codi postal: ");
            string cp = Console.ReadLine();
            Console.Write("Municipi: ");
            string municipi = Console.ReadLine();

            escoles[codi] = new School(codi, nom, cp, municipi);
            Console.WriteLine("Centre creat correctament.");
        }

        static void Actualitzar(Dictionary<string, School> escoles)
        {
            Console.Write("Codi del centre a actualitzar: ");
            string codi = Console.ReadLine();

            if (!escoles.TryGetValue(codi, out School centre))
            {
                Console.WriteLine("El centre no existeix.");
                return;
            }

            Console.WriteLine($"Centre actual: {centre}");
            Console.Write("Nou nom del centre: ");
            string nom = Console.ReadLine();
            Console.Write("Nou codi postal: ");
            string cp = Console.ReadLine();
            Console.Write("Nou municipi: ");
            string municipi = Console.ReadLine();

            escoles[codi] = new School(codi, nom, cp, municipi);
            Console.WriteLine("Centre actualitzat correctament.");
        }

        static void Eliminar(Dictionary<string, School> escoles)
        {
            Console.Write("Codi del centre a eliminar: ");
            string codi = Console.ReadLine();

            if (escoles.TryGetValue(codi, out School centre))
            {
                Console.WriteLine($"Eliminant centre: {centre}");
                escoles.Remove(codi);
                Console.WriteLine("Centre eliminat correctament.");
            }
            else
            {
                Console.WriteLine("El centre no existeix.");
            }
        }

        static void ConsultarUn(Dictionary<string, School> escoles)
        {
            Console.Write("Codi del centre a consultar: ");
            string codi = Console.ReadLine();

            if (escoles.TryGetValue(codi, out School centre))
            {
                Console.WriteLine($"Informació del centre: {centre}");
            }
            else
            {
                Console.WriteLine("El centre no existeix.");
            }
        }

        static void ConsultarTots(Dictionary<string, School> escoles)
        {
            Console.WriteLine("\nTots els centres:");
            foreach (var parell in escoles)
            {
                Console.WriteLine(parell.Value);
            }
        }

        static void ConsultarMolts(Dictionary<string, School> escoles)
        {
            Console.Write("Introdueix la lletra inicial: ");
            char lletra = Console.ReadLine().ToUpper()[0];

            Console.WriteLine("\nCentres amb aquesta lletra inicial:");
            foreach (var parell in escoles)
            {
                if (parell.Value.Nom.ToUpper().StartsWith(lletra))
                {
                    Console.WriteLine(parell.Value);
                }
            }
        }
    }

    public class School
    {
        private string codi;
        private string nom;
        private string cp;
        private string municipi;

        public School(string codi, string nom, string cp, string municipi)
        {
            this.codi = codi;
            this.nom = nom;
            this.cp = cp;
            this.municipi = municipi;
        }

        public string Codi => codi;
        public string Nom => nom;
        public string CP => cp;
        public string Municipi => municipi;

        public override bool Equals(object obj)
        {
            return obj is School other && codi == other.codi;
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
