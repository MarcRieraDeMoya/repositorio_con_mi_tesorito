internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        char minuscula;
        int conversor;
        char mayuscula;

        // Valors de entrada

        Console.Write("ESCRIU UNA LLETRA MINUSCULA --> ");
        minuscula = Convert.ToChar(Console.ReadLine());

        // Algorisme /calculs

        conversor = (int) (minuscula - 32);
        mayuscula = (char) conversor;

        // Valors de sortida

        Console.Write($"LA LLETRA PASADA A MAYUSCULA --> {mayuscula}");

        }
    }

