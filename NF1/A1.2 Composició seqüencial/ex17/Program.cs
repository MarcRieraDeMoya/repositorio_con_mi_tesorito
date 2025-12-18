internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        Random rand;
        int nCares;
        int dau;

        // Valors de entrada

        Console.Write("QUANTES CARES TE EL DAU --> ");
        nCares = Convert.ToInt32(Console.ReadLine());

        // Algorismes /calculs

        rand = new Random();
        dau = rand.Next(1, nCares+1);
        

        // Valors de sortida

        Console.WriteLine($"{dau}");
        }
    }

