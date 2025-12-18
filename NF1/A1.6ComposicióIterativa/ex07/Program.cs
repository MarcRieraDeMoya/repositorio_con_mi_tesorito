namespace ex07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero , acumulador = 0;
            Console.Write("Introdueix un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());

            for (int cont = 1; cont <= numero; cont++)
            {
                acumulador += cont;
            }
            Console.WriteLine($"la suma del numero introduit es {acumulador}");

        }
    }
}
