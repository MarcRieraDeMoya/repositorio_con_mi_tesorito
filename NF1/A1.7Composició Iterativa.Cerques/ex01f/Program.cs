namespace ex01f
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int numero;
            bool hihamajorde17 = false;
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);

            while (!hihamajorde17 && numero < 17) 
            {
                numero = Convert.ToInt32(linia);
                linia = fitxer.ReadLine();
            }
            if (hihamajorde17)
            {
                Console.Write($"No hi ha un de mes gran");
            }
            else
            {
                Console.Write($"Si hi ha un de mes gran i es el numero {numero}");
            }
        }
    }
}
