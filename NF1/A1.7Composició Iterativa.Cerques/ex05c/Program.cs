namespace ex05c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("PERFECTES.TXT");
            string linia;
            int numero;
            bool noTrobat = false, perfecte;
           
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);
            perfecte = EsPerfecte(numero);

            while ( linia != null )
            {
                perfecte = EsPerfecte(numero);
                if (perfecte)
                {
                    Console.WriteLine($"El numero {numero} es perfecte");
                }
                else
                {
                    Console.WriteLine($"El numero {numero} no es perfecte");
                }
                linia = fitxer.ReadLine();
                numero = Convert.ToInt32(linia);
            }
        }

        static bool EsPerfecte(int n)
        {
            int nFinal = 0, cont = 1;

            while (cont != n)
            {
                if (n % cont == 0)
                {
                    nFinal = nFinal + cont;
                }
                cont++;

            }

            if (n == nFinal)
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
