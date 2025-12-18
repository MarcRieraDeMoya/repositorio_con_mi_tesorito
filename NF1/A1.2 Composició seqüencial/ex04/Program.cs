internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        double a;
        double b;
        double x;

        // Valors de entrada

        Console.Write("INTRODUEUX EL VALOR A --> ");
        a = Convert.ToInt32(Console.ReadLine());
        Console.Write("INTRODUEUX EL VALOR B --> ");
        b = Convert.ToInt32(Console.ReadLine());

        // Algorisme /calculs

        x = -b / a;

        // Valors de sortida

        Console.WriteLine("AX + B = 0 --> X = -B / A ");
        Console.Write($"EL RESULTAT FINAL ES --> {x} ");
            


        }
    }

