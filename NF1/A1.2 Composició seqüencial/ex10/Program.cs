internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        double peus;
        double polzades;
        double metres;

        // Valors de entrada

        Console.Write("QUANTES PEUS VOLS CONVERTIR? ");
        peus = Convert.ToDouble(Console.ReadLine());

        // Algorismes /calculs

        polzades = peus * 12;
        metres = (polzades * 2.54) / 100;

        // Valors de sortida

        Console.Write($"CONVERTIT EN METRES SERIEN {metres} M ");
        }
    }

