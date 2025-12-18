internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        Random rand;
        char lletra;
        int conversor;

        // Valors de entrada

        // Algorismes /calculs

        rand = new Random();
        conversor = rand.Next(65, 90);
        lletra = (char)conversor;

        // Valors de sortida

        Console.WriteLine($"{lletra}");
            
        }
    }

