internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        char tecla;
        int ascii;

        // Valors de entrada

        Console.Write("PULSA UNA TECLA PER VEURE EL SEU NUMERO ASCII  --> ");
        tecla = Convert.ToChar(Console.ReadLine());

        // Algorisme /calculs

        ascii = (int)(tecla);

        // Valors de sortida

        Console.Write($"EL RESULTAT FINAL ES --> {ascii} ");
        }
    }

