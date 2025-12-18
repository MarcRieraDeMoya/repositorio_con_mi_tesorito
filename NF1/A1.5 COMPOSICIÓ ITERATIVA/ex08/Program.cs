namespace ex08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int numero, mesGran, mesPetit;
            
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);
            mesGran = numero;
            mesPetit = numero;

            while (linia != null)
            {
                numero = Convert.ToInt32(linia);
                if (numero > mesGran)
                    mesGran = numero;
                else if (numero < mesPetit)
                    mesPetit = numero;

                linia = fitxer.ReadLine();
            }
            fitxer.Close();
            Console.Write($"El valor mes petit es {mesPetit} i el mes gran es {mesGran}");
        }
    }
}
