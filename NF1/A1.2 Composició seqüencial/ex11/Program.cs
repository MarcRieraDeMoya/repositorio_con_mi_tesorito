internal class Program
    {
        static void Main(string[] args)
        {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        // Declaració de variables

        double horesTreballades;
        double souBrut, souNet;
        double percentatgeImpostos;
        double souBrutTotal;
        double impostos;

        // Valors de entrada

        Console.Write("INTRODUIR NUMERO DE HORES TREBALLADES --> ");
        horesTreballades = Convert.ToInt32(Console.ReadLine());
        Console.Write("INTRODIR SALARI BRUT PER HORA --> ");
        souBrut = Convert.ToInt32(Console.ReadLine());
        Console.Write("INTRODUIR PERCENTATGE DE IMPOSTOS SOBRE EL SOU --> ");
        percentatgeImpostos = Convert.ToInt32(Console.ReadLine());

        // Algorismes /calculs

        souBrutTotal = horesTreballades * souBrut;
        impostos = (souBrutTotal * percentatgeImpostos) / 100;
        souNet = souBrutTotal - impostos;

        // Valors de sortida

        Console.Write($"EL SOU NET SERIEN UNS {souNet} € ");
        }
    }
