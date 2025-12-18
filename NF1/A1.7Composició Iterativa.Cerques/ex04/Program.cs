namespace ex04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int numeroLinia, numero, cont = 1;
            bool noTrobat= false;
           
            Console.Write("Introdueix en numero que vols buscar: ");
            numero = Convert.ToInt32(Console.ReadLine());

            linia = fitxer.ReadLine();
            numeroLinia = Convert.ToInt32(linia);

            while (!noTrobat && numeroLinia != numero )
            {
                noTrobat = linia == null;
                cont++;
                linia = fitxer.ReadLine();
                numeroLinia = Convert.ToInt32(linia);
            }

            if(noTrobat)
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.Write($"LINIA {cont} ");
            }
        }
    }
}
