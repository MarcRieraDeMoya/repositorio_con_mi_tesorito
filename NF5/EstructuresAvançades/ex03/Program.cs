namespace ex03
{
    internal class Program
    {
        static void Main()
        {
            string rutaFitxer = "JARS.TXT";
            if (!File.Exists(rutaFitxer))
            {
                Console.WriteLine("El fitxer no existeix.");
                return;
            }

            StreamReader fitxer = new StreamReader(rutaFitxer);
            string linia;
            bool continuar = true;

            while (continuar && (linia = fitxer.ReadLine()) != null)
            {
                if (!int.TryParse(linia, out int numPotes) || numPotes < 0)
                {
                    Console.WriteLine("Format incorrecte al fitxer.");
                    continuar = false;
                    break;
                }

                if (numPotes == 0)
                {
                    continuar = false;
                    break;
                }

                HashSet<string> ingredientsNoAgraden = new HashSet<string>();

                for (int i = 0; i < numPotes; i++)
                {
                    linia = fitxer.ReadLine();
                    if (string.IsNullOrWhiteSpace(linia)) continue;

                    // Processar la línia i separar SI: o NO:
                    string[] parts = linia.Split(new[] { ": " }, StringSplitOptions.None);
                    if (parts.Length < 2) continue;

                    string estat = parts[0].Trim();
                    string[] ingredients = parts[1].Split(' ');

                    if (estat == "NO")
                    {
                        for (int j = 0; j < ingredients.Length - 1; j++) // Ignorar FIN
                        {
                            ingredientsNoAgraden.Add(ingredients[j]);
                        }
                    }
                }

                List<string> ordenats = new List<string>(ingredientsNoAgraden);
                ordenats.Sort();

                if (ordenats.Count > 0)
                {
                    Console.WriteLine(string.Join(" ", ordenats));
                }
                else
                {
                    Console.WriteLine();
                }
            }

            fitxer.Close();
        }
    }


}
