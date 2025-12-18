namespace ex10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cont4 = 0;

            for ( int cont = 0; cont <= 300; cont++)
            {
                if (cont % 4 == 0)
                {
                    Console.WriteLine(cont);
                    cont4++;
                }
                if (cont4 % 20 == 0)
                {
                    Console.ReadKey();
                    cont4++;
                }
                    
            }
        }
    }
}
