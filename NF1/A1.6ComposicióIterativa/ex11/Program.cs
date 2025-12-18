namespace ex11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("BONUS3.TXT");
            int contBonus = 0, bonus = 0, cont, bonusTotal = 0,billets;
            double percentatgeBonus;
            string linia;
            billets = Convert.ToInt32(fitxer.ReadLine());
            

            for ( cont = 0; cont < billets; cont++)
            {
                linia = fitxer.ReadLine();

                if (linia == "BONUS")
                {
                    linia = fitxer.ReadLine();
                    bonus = Convert.ToInt32(linia);
                    bonusTotal = bonusTotal + bonus;
                    contBonus++;
                }
                
             

            }
            fitxer.Close();
            percentatgeBonus = ((double) contBonus / cont) * 100;
            
            Console.WriteLine($"S'han distribiut {contBonus} bonus dels {billets} billets totals");
            Console.WriteLine($"El percentatge de billets amb bonus es {percentatgeBonus}% i el guany total es de {bonusTotal}");
                
        }
    }
}
