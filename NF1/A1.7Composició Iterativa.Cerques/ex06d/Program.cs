namespace ex06d
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
            esPrimer = EsPrimer(numero);


            while (linia != null && !esPrimer )
            {
                esPrimer = EsPrimer(numero);
                linia = fitxer.ReadLine();
                numero = Convert.ToInt32(linia);
            }
            if (esPrimer)
            {
                Console.WriteLine($"Hi ha un numero primer");
            }
            else
            {
                Console.WriteLine($"No hi ha cap numero primer");
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
