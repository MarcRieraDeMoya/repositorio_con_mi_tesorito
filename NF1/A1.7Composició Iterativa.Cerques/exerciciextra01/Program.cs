namespace exerciciextra01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m,nFac, mFac;
            double total = 0;
            Console.Write("Introdueix el valor 'n': ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introdueix el valor 'm': ");
            m = Convert.ToInt32(Console.ReadLine());

            
            if (n > m && n > 0 && m > 0)
            {
                nFac = Factorial(n);
                mFac = Factorial(m);
                total =(double) nFac / (mFac * Factorial(n - m));
            }
            else
            {
                Console.Write("error");
            }
            Console.Write($"El resultat de la formula es {total}");
        }


        static int Factorial(int numero)
        {
            int acumulador = 1;
            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());

            for (int cont = 1; cont <= numero; cont++)
            {
                acumulador *= cont;
            }
            return acumulador;
        }
    }
}
