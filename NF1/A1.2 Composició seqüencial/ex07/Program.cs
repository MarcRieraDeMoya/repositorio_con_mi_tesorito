internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        int numerador;
        int denominador;
        int divisio;
        int residu;

        // Valors de entrada

        Console.Write("ESCRIU NUMERO NUMERADOR --> ");
        numerador = Convert.ToInt32(Console.ReadLine());
        Console.Write("ESCRIU NUMERO DENOMINADOR --> ");
        denominador = Convert.ToInt32(Console.ReadLine());

        // Algorisme /calculs

        divisio = numerador / denominador;
        residu = numerador % denominador;

        // Valors de sortida

        Console.WriteLine($"EL RESULTAT DE LA DIVISIO ES --> {divisio}");
        Console.Write($"EL RESIDU DE LA DIVISIO ES --> {residu}");
        }
    }

