namespace ex002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string linia;
            int numero, cont = 0;

            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);
            while (linia != null && numero != 0)
            {
                numero = Convert.ToInt32(linia);
                cont++;
                linia = fitxer.ReadLine();
            }
            fitxer.Close();
            Console.WriteLine($"Hi han {cont} valors");

        }
    }
}
