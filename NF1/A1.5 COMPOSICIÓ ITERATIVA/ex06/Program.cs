namespace ex06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS2.TXT");
            string linia;
            double numero, cont = 0, mitjana, numTotal = 0;
            linia = fitxer.ReadLine();

            while (linia != null)
            {
                cont++;
                numero = Convert.ToDouble(linia);
                numTotal = numTotal + numero;

                linia = fitxer.ReadLine();
            }
            fitxer.Close();

            mitjana =  numTotal/cont;
            Console.WriteLine($"La mitjana dels valors es {mitjana}");

        }
    }
}
