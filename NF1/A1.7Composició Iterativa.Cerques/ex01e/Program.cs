namespace ex01e
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int numero, cont = 0;
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);

            while (linia != null)
            {
                numero = Convert.ToInt32(linia);
                if (numero == 17)
                {
                    cont++;
                }

                linia = fitxer.ReadLine();
            }
            Console.Write($"El numero 17 ha sortit {cont} vegades");
        }
    }
}
