namespace ex05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            bool perfecte;
            Console.Write("Escriu un valor: ");
            numero = Convert.ToInt32(Console.ReadLine());
            perfecte = EsPerfecte(numero);

            if (perfecte)
            {
                Console.WriteLine($"El numero {numero} es perfecte");
            }
            else
            {
                Console.WriteLine($"El numero {numero} no es perfecte");
            }
        }

        static bool EsPerfecte(int n)
        {
            int nFinal = 0 , cont = 1;
           
            while (cont != n)
            {
                if (n % cont == 0)
                {
                    nFinal = nFinal + cont ;
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
