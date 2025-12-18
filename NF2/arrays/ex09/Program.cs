namespace ex09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resultat;
            int[] array = { 2, 7, 4, 5, 6, 2, 4, 9, 6, 8, 7 };
            resultat = DistinctValues(array);
            Console.Write($"El numero de valors diferents es --> {resultat}");

        }

        public static int DistinctValues(int[] t)
        {
            int cont = 0;

            for(int i = 0; i < t.Length; i++)
            {
                bool repetit = false;

                for (int j = 0; j < i; j++)
                {
                    if (t[i] == t[j])
                    {
                        repetit = true;
                    }
                }

                if (!repetit)
                {
                    cont++;
                }

            }

            return cont;
        }

       
    }
}
