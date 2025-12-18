using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ex06b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            bool esPrimer;

            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());
            esPrimer = EsPrimer(numero);

            if (esPrimer)
            {
                Console.WriteLine($"El numero {numero} és primer");
            }
            else
            {
                Console.WriteLine($"El numero {numero} no és primer");
            }
        }

        static bool EsPrimer(int n)
        {
            int cont = 2;
            bool esPrimer = true;

            while (cont <= n / 2 && esPrimer)
            {
                if (n % cont == 0)
                {
                    esPrimer = false;
                }
                cont++;
            }
            if (esPrimer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
