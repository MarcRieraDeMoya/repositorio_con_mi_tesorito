namespace ex02b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero, primerNumero, cont = 1;
            Console.Write("Escriu un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());
            primerNumero = numero;
            Console.Write("Escriu un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());

            while (numero != -9999 && cont != 2)
            {
                if (numero == primerNumero)
                {
                    cont++;
                }
                Console.Write("Escriu un numero: ");
                numero = Convert.ToInt32(Console.ReadLine());

            }
            if (numero == -9999)
            {
                Console.Write($"No es repeteix el primer numero ");

            }
            else
            {
                Console.Write($"Si es repeteix el primer numero que es el numero {primerNumero}");
            }
        }
    }
}
