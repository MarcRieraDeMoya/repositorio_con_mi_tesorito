namespace ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int n;
            int[] ints;

            Console.Write("introdueix el valor de n --> ");
            n = Convert.ToInt32(Console.ReadLine());

            ints= new int[n];

            for(int i = 0; i<n; i++)
            {
                ints[i] = rand.Next(-100, 101);

                Console.WriteLine($" index {i} --> {ints[i]}");
            }

        }
    }
}
