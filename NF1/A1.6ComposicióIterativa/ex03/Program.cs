namespace ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cont, valor1, valor2;

            Console.Write("escriu el valor 1: ");
            valor1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("escriu el valor 2: ");
            valor2 = Convert.ToInt32(Console.ReadLine());

            for (cont = valor1; cont<=valor2; cont++)
            {
                Console.WriteLine(cont);
            }
            
        }
    
    }
}
