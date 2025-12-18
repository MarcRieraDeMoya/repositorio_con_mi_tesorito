namespace ex01c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int numero , mesGran;
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);
            mesGran = numero;

            while ( linia != null)
            {
                numero = Convert.ToInt32(linia);
               
                if (mesGran < numero)
                {
                    mesGran = numero;
                }

                linia = fitxer.ReadLine();
            }
            Console.Write($"El numero mes gran es {mesGran}");

        }
    }
}
