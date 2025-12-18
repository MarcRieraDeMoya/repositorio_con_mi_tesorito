namespace ex05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numero, cont = 0, mitjana ,numTotal = 0;

            Console.Write("Introduiex numeros: ");
            numero = Convert.ToDouble(Console.ReadLine());
            

            while (numero != 0)
            {
                cont++;
                numTotal = numTotal + numero;

                Console.Write("Introduiex numeros: ");
                numero = Convert.ToDouble(Console.ReadLine());
            }
            mitjana = numTotal/cont ;
            Console.WriteLine($"La mitjana dels valors que has introduit es {mitjana}");

        }
    }
}
