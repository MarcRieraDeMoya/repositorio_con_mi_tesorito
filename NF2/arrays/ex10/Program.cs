namespace ex10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] t = { 7, 4, 8, 5, 1, 6, 4, 10, 8, 1, 7 };
            

        }

        public static List<int> GetDistinctValues(int[] t)
        {
            List<int> i;
            return i;
            
        }

        public static int DistinctValues(int[] t)
        {
            int cont = 0;
            int valor = 0;

            for (int i = 0; i < t.Length; i++)
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
                    valor = t[i];

                }

            }
            return valor;


            
        }


    }
}

