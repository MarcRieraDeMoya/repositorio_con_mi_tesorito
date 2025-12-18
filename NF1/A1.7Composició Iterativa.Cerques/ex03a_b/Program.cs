namespace ex03a_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS2.TXT");
            string linia;
            int numero;
            bool noParell = false;
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);


            while (!noParell && numero % 2 != 0)
            {
                noParell = numero % 2 != 0;
                numero = Convert.ToInt32(linia);
                linia = fitxer.ReadLine();
            }

            if (noParell)
            {
                Console.Write($"No hi ha un parell ");
            }
            else
            {
                Console.Write($"Si hi ha un parell i es {numero}");
            }
        }
    }
}
