using System.Diagnostics.CodeAnalysis;

namespace ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i , valor;

            Console.Write("Introdueix valors: ");
            valor = Convert.ToInt32(Console.ReadLine());
            i = 0;

            while (valor != 0)
            {
                i++;
                Console.Write("Introdueix valors: ");
                valor = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write($"Has indtroduit {i} valors");

            

        }
    }
}
