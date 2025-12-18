namespace ex15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());

            for (int cont = 0; cont < numero; cont++)
            {
                for (int cont2 = 0; cont2 < numero; cont2++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
