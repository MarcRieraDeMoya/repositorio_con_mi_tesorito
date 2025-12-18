namespace ex06e
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero, cont = 1, contPrimers = 0;
            //REVISAR NO ESTA BIEN
           
            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());

            while (contPrimers < numero)
            {
                if (EsPrimer(cont))
                {
                    Console.WriteLine(cont);
                    contPrimers++;
                }
                cont++;
            }
        }
        static bool EsPrimer(int num)
        {
            int cont = 2;
            bool esPrimer = true;
            while (cont <= num  && esPrimer)
            {
                if (num % cont == 0)
                    esPrimer = false;
                cont++;
            }
            return esPrimer && num > 1;
        }
    }
}
