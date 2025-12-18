namespace ex01d
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int numero;
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);

            while (linia != null)
            {
                numero = Convert.ToInt32(linia);
                if (numero % 2 == 0)
                {
                    Console.WriteLine(numero);
                }

                linia = fitxer.ReadLine();
            }
        }
    }
}
