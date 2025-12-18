namespace ex06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Contains(GenerarTaula(10), 7));
        }


        public static bool Contains(int[] t, int valor)
        {
            int index = 0;
            bool trobat = false;
            index = IndexOf(t, valor);

            if(index != -1)
            {
                trobat = true;
            }

            return trobat;
        }
        public static int IndexOf(int[] t, int valor)
        {
            int index = 0;
            bool trobat = false;

            while (!trobat && index < t.Length)
            {
                if (t[index] == valor)
                    trobat = true;
                else
                    index++;

            }

            if (!trobat)
                index = -1;

            return index;
        }

        static int[] GenerarTaula(int num)
        {
            Random rnd = new Random();
            int[] result = new int[num];
            for (int i = 0; i < num; i++)
                result[i] = rnd.Next(-100, 101);

            return result;
        }
    }
}