namespace ex12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("alumnesDAMDAW.txt");
            int contAlex = 0, contIker = 0;
            string linia;
            linia = fitxer.ReadLine();

            while (linia != null)
            {
                if (linia == "Alex")
                    contAlex++;
                else if (linia == "Iker")
                    contIker++;
                linia = fitxer.ReadLine();
            }
            fitxer.Close();

            if (contAlex == contIker)
                Console.Write("Hi ha la mateixa quantitat de Alex i Ikers");
            else if (contAlex < contIker)
                Console.Write("Hi ha mes Ikers");
            else
                Console.Write("Hi ha mes Alex");
        }
    }
}
