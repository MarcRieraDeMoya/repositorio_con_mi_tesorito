namespace ex18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());
            
            for(int cont = 1; cont <=numero; cont++)
            {
                for(int cont2 = 1; cont2 < numero - cont + 1; cont2++)
                {
                    Console.Write(' ');
                }
                for (int cont3 = 1; cont3 <= cont; cont3++)
                {
                    Console.Write(cont3);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
