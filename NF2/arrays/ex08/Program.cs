namespace ex08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 3, 7, 3, 4, 5, 6, 9, 2 };
            Console.Write(Contains(array , 7, 5, 7));
        }


        public static bool Contains(int[] t, int valor, int indexFrom, int IndexTo)
        {
            int index = 0;
            bool trobat = false;
            index = IndexOf(t, valor, indexFrom, IndexTo);

            if (index != -1)
            {
                trobat = true;
            }

            return trobat;
        }
        public static int IndexOf(int[] t, int valor, int IndexFrom, int IndexTo)
        {
            int index = 0;
            bool trobat = false;

            while (!trobat && index < t.Length) 
            {
                if (t[index] == valor && index >= IndexFrom && index <= IndexTo)
                    trobat = true;
                else
                    index++;

            }

            if (!trobat)
                index = -1;

            return index;
        }
    }
}
