using static System.Net.Mime.MediaTypeNames;

namespace ex05a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero, numFinal = 0, cont = 1;
            Console.Write("Escriu un valor: ");
            numero = Convert.ToInt32(Console.ReadLine());

            while (cont != numero)
            {
                if (numero % cont == 0)
                {

                    numFinal = numFinal + cont;
                }

                cont++;

            }
            if (numero == numFinal)
            {
                Console.WriteLine("El numero es perfecte");
            }
            else
            {
                Console.WriteLine("El numero no es perfecte");
            }


        }
    }
}
