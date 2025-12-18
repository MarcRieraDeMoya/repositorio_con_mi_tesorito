using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters;
using static System.Net.Mime.MediaTypeNames;

namespace ex17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total;
            for ( int cont = 0; cont <= 10; cont++)
            {
                for (int cont2 = 0; cont2 <= 10; cont2++)
                {
                    total = cont * cont2;
                    Console.WriteLine($"{cont} x {cont2} = {total}");
                }
                Console.WriteLine();
                
            }
       
            
        }


       
    }
}
