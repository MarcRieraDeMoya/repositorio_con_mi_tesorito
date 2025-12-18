namespace ex16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());

            for (int cont = 1; cont <= numero; cont++)
            {
                for (int cont2 = 0; cont2 < cont; cont2++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
