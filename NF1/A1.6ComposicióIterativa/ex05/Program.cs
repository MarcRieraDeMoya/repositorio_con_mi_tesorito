using System.Runtime.Serialization.Formatters;

namespace ex05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cont, numero, total = 0;
            
            for (cont = 0; cont < 10; cont++)
            {
                Console.Write("Introdueix numeros: ");
                numero = Convert.ToInt32(Console.ReadLine());
                total = total + numero;
               
            }
            Console.WriteLine($"La suma dels 10 numeros introduits es {total}");
            
        }
    }
}
