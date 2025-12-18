namespace ex05d
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


            while (linia != null && !perfecte)
            {
                perfecte = EsPerfecte(numero);
                linia = fitxer.ReadLine();
                numero = Convert.ToInt32(linia);
            }
            if (perfecte)
            {
                Console.WriteLine($"Hi ha numero perfecte ");
            }
            else
            {
                Console.WriteLine($"No hi ha numero perfecte");
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
