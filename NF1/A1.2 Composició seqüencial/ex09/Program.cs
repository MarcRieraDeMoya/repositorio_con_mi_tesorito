internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        double polzades;
        double metres;

        // Valors de entrada

        Console.Write("QUANTES POLZADES VOLS CONVERTIR? ");
        polzades = Convert.ToDouble(Console.ReadLine());

        // Algorismes /calculs

        metres = (polzades * 2.54) / 100;

        // Valors de sortida

        Console.Write($"CONVERTIT EN METRES SERIEN {metres} M ");
        

        }
    }

