namespace ex09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero, total;
            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());

            for (int cont = 0; cont <= 10; cont++)
            {
                total = numero * cont;
                Console.WriteLine($"{numero} x {cont} = {total}");
            }
        }
    }
}
