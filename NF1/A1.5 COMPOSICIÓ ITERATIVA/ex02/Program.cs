namespace ex02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero, contPos = 0 , contNeg = 0;
            Console.Write("Introdueix Valors: ");
            numero = Convert.ToInt32(Console.ReadLine());

            while (numero != 0)
            {

                if (numero > 0)
                    contPos++;

                else contNeg++;

                Console.Write("Introdueix Valors: ");
                numero = Convert.ToInt32(Console.ReadLine());

            }

            Console.Write($"Has introduit {contPos} valors positius i {contNeg} valors negatius");

        }
    }
}
