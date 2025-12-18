namespace ex06a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int numero, cont = 2;
            bool esPrimer = true;

            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());

            while (cont <= numero /2 && esPrimer)
            {
                if (numero % cont == 0)
                {
                    esPrimer = false;
                }
                cont++;
            }

            if (esPrimer)
            {
                Console.WriteLine($"El numero {numero} és primer");
            }
            else
            {
                Console.WriteLine($"El numero {numero} no és primer");
            }
        }
    }
}
