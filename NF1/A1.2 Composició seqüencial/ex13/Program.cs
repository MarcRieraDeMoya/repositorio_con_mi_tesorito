    internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        int anys;
        int digit1;
        int digit2;
        int digit3;
        int digit4;

        // Valors de entrada

        Console.Write("ESCRIU UN ANY AMB ELS SEUS 4 DIGITS --> ");
        anys = Convert.ToInt32(Console.ReadLine());

        // Algorismes /calculs

        digit1 = anys / 1000;
        digit2 = (anys % 1000) / 100;
        digit3 = (anys % 100) /10;
        digit4 = anys % 10;

        // Valors de sortida

        Console.Write($"HAS INTRODUIT L'ANY {anys} I ELS SEUS 4 DIGITS SON {digit1} {digit2} {digit3} {digit4}  ");

        }
    }

