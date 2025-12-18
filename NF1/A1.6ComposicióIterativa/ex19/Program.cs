using static System.Net.Mime.MediaTypeNames;

namespace ex19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0, numero;
            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());


            for (int cont = 1; cont <= numero; cont++ )
            {
                for (int cont2 = 1; cont2 <= cont; cont2++)
                {

                    if (cont2 != cont)
                    {
                        Console.Write($"{cont2} + ");
                    }
                    else if (cont2 == cont)
                    {
                        Console.Write($"{cont2} = ");
                    }
                }
                total += cont;
                Console.Write(total);
                Console.WriteLine();
            }
            

        }
    }
}
