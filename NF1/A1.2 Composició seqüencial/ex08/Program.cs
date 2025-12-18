internal class Program
    {
        static void Main(string[] args)
        {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        // Declaració de variables

        double valorEuros;
        double nEuros;
        double nDolars;

        // Valors de entrada

        Console.Write("QUANTS EUROS VAL UN DOLAR ? ");
        valorEuros = Convert.ToDouble(Console.ReadLine());
        Console.Write("QUANTS DOLARS VOLEM CONVERTIR ? ");
        nDolars = Convert.ToDouble(Console.ReadLine());

        // Algorismes /calculs

        nEuros = valorEuros * nDolars;

        // Valors de sortida

        Console.Write($"{nDolars} $ SON {nEuros} € ");
            
        }
    }

