namespace ex05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] resultat = { 2, 4, 5, 6, 3 };
            double final;

            final = Average(resultat);
            Console.Write(final);

        }


        static double Average(int[] t)
        {
            int valor = 0, valor2 = 0, valorFinal;
           
            for(int i = 0; i < t.Length; i++)
            {
                t[i] = valor;
                valor2 += valor;
            }

            valorFinal = valor2 / t.Length;

            return valorFinal;
        }
    }
}
