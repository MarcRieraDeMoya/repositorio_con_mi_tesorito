namespace ex15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MARCA_FI = -1;

            StreamReader fitxer = new StreamReader("Girona lliga23_24.txt");
            int guanyat = 0, perdut = 0, empatat = 0, golsGirona = 0, golsContrari = 0, comptador = 0, gols, liniaImpar, liniaPar;



            gols = Convert.ToInt32(fitxer.ReadLine());
            liniaImpar = Convert.ToInt32(fitxer.ReadLine());
            liniaPar = Convert.ToInt32(fitxer.ReadLine());


            while (gols != MARCA_FI)
            {
                comptador++;

                if (comptador % 2 == 1)
                {
                    golsGirona += gols;
                }
                else
                {
                    golsContrari += gols;
                }
                if (liniaImpar > liniaPar)
                {
                    guanyat++;
                }
                else if (liniaImpar < liniaPar)
                {
                    perdut++;
                }
                else
                {
                    empatat++;
                }

                gols = Convert.ToInt32(fitxer.ReadLine());
                liniaImpar = Convert.ToInt32(fitxer.ReadLine());
                liniaPar = Convert.ToInt32(fitxer.ReadLine());
            }
            fitxer.Close();
            Console.WriteLine($"gols girona: {golsGirona}");
            Console.WriteLine($"gols contrari: {golsContrari}");
            Console.WriteLine($"partits guanyats: {guanyat}");
            Console.WriteLine($"partits perduts: {perdut}");
            Console.WriteLine($"partits empatats: {empatat}");
            Console.WriteLine($"girons te: {guanyat*3+empatat} punts");



        }
    }
}
