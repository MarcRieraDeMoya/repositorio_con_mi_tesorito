namespace ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int acumulador = 0;
            linia = fitxer.ReadLine();
            
            while (linia != null)
            {
                acumulador += Convert.ToInt32(linia);
                linia = fitxer.ReadLine();
            }

            Console.Write($"La suma de la seqüencia es: {acumulador}");
        }
    }
}
