namespace ex06c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("ALGUNSPRIMERS.txt");
            string linia;
            int numero;
            bool esPrimer;

            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);
            
            while ( linia != null)
            {
                esPrimer = EsPrimer(numero);

                if (esPrimer)
                {
                    Console.WriteLine($"El numero {numero} és primer");
                }
                else
                {
                    Console.WriteLine($"El numero {numero} no és primer");
                }

                linia = fitxer.ReadLine();
                numero = Convert.ToInt32(linia);
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
