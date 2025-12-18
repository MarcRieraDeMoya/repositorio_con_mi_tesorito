namespace ex02
{
    internal class Program
    {
        static void Main()
        {
            string rutaFitxer = "HACIENDO_INVENTARIO.txt";
            StreamReader fitxer = new StreamReader(rutaFitxer);

            string linia = fitxer.ReadLine();

            while (linia != null)
            {
                if (linia.Trim() == "")
                {
                    linia = fitxer.ReadLine();
                    continue;
                }

                int numProductes = int.Parse(linia);

                if (numProductes == 0)
                    break;

                HashSet<string> productesUnics = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < numProductes; i++)
                {
                    linia = fitxer.ReadLine();
                    if (!string.IsNullOrWhiteSpace(linia))
                        productesUnics.Add(linia.Trim());
                }

                Console.WriteLine(productesUnics.Count);

                linia = fitxer.ReadLine();
            }

            fitxer.Close();
        }
    }


}