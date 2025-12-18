internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        Random rand;
        int girona;
        int paris;

        // Valors de entrada

        // Algorismes /calculs

        rand = new Random();
        girona = rand.Next(7);
        paris = rand.Next(7);

        // Valors de sortida

        Console.WriteLine("EL RESULTAT DEL PARTIT ENTRE EL GIRONA I EL PARIS SANT GERMAIN HA SIGUT ");
        Console.WriteLine($"GIR {girona} PSG {paris}");
        }
    }

