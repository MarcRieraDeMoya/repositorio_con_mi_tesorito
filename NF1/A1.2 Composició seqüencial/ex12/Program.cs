internal class Program
    {
    /// <summary>
    /// Basicament el que fa aquest pograma es repetir els numeros que hem introduit pero invertint el ordre d'aquest
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            int a, b, c;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = a;
            a = b;
            b = c;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }

