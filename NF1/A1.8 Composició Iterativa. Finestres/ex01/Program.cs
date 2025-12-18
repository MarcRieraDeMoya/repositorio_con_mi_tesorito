namespace ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numAct, numAnt, numAnt2;
            bool sumaAnt = false;
            string linia;
            StreamReader fitxer = new StreamReader("NUMEROS1.TXT");

            numAnt2 = Convert.ToInt32(fitxer.ReadLine());
            numAnt = Convert.ToInt32(fitxer.ReadLine());
            linia = fitxer.ReadLine();

            while ( linia != null && !sumaAnt)
            {
                numAct = Convert.ToInt32(linia);
                
                if (numAct == numAnt + numAnt2)
                {
                    sumaAnt = true;
                }

                numAnt2 = numAnt;
                numAnt = numAct;
                linia = fitxer.ReadLine();
            }
            fitxer.Close();


            if (sumaAnt)
            {
                Console.WriteLine("Si existeix");
            }
            else
            {
                Console.WriteLine("No existeix");
            }




        }
    }
}
