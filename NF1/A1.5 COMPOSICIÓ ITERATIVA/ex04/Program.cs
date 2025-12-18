using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ex04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int contPos = 0, contNeg = 0, numero;

            linia = fitxer.ReadLine();

            while (linia != null )
            {
                numero = Convert.ToInt32(linia);

                if (numero > 0)
                    contPos++;

                else contNeg++;
                linia = fitxer.ReadLine();
            }
            fitxer.Close();

            Console.Write($"Hi han {contPos} valors positius i {contNeg} valors negatius");
        }
    }
}
