namespace ex03b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            Console.Write("Escriu un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());
            

            while (numero != -9999 && numero % 2 != 0)
            {
                Console.Write("Escriu un numero: ");
                numero = Convert.ToInt32(Console.ReadLine());
                
            }
            if(numero == -9999)
            {
                Console.Write($"No hi ha un parell");

            }
            else
            {
                Console.Write($"Si hi ha un parell i es {numero}");
            }
        }
    }
}
