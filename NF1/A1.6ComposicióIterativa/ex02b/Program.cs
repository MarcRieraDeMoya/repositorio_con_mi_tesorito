namespace ex02b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valor = 1;

            for (int cont = 1; cont < 20; valor++)
            {
                if (valor % 2 == 0)
                {
                    Console.WriteLine(valor);
                    cont++;
                }
            }
        }
    }
    }
}
