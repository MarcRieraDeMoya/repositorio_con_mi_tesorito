namespace ex10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dau , cont1 = 0, cont6 = 0, cont = 0;
            Random rand = new Random();


            dau = rand.Next(1, 7);

            while(cont1 != cont6 || cont1 == 0 || cont6 == 0)
            {
                if (dau == 1)
                    cont1++;
                else if (dau == 6)
                    cont6++;
                else
                    cont++;

                dau = rand.Next(1, 7);
            }

            cont = cont + cont1 + cont6;

            Console.Write($"Has tirat el dau {cont} vegades i el numero de vegades que ha sigut 6 es {cont6}");
        }
    }
}
