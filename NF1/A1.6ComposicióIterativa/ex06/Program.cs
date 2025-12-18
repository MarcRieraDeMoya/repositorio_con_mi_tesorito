namespace ex06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cont, numero, contPos = 0, contNeg = 0, cont0 = 0;


            for (cont = 0; cont < 10; cont++)
            {
                Console.Write("Introdueix numeros: ");
                numero = Convert.ToInt32(Console.ReadLine());

                if ( numero > 0 )
                {
                    contPos++;
                }
                else if (numero < 0)
                {
                    contNeg++;
                }
                else if (numero == 0)
                {
                    cont0++;
                }
            }
            Console.WriteLine($"Dels 10 numeros introduits {contPos} son positius {contNeg} son negatius i {cont0} son '0' ");
        }
    }
}
