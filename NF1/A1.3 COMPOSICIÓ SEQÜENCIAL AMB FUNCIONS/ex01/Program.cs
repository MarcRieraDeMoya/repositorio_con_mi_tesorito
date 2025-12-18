namespace ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hores;
            int minuts;
            int segons;
            int segonsTotal;

            Console.Write("escriu el numero de hores : ");
            hores = Convert.ToInt32(Console.ReadLine());
            Console.Write("escriu el numero de minuts : ");
            minuts = Convert.ToInt32(Console.ReadLine());
            Console.Write("escriu el numero de segons : ");
            segons  = Convert.ToInt32(Console.ReadLine());

            segonsTotal = Temps(hores, minuts, segons);

            Console.Write($"HAS INTRODUIT {hores:00} HORES {minuts:00} MINUTS I {segons:00} SEGONS I AQUEST TEMPS EN SEGONS ES {segonsTotal}");


        }

        static int Temps(int hores, int minuts, int total)
        {
            hores = hores * 3600;
            minuts = minuts * 60;
            total = hores + minuts + total;
            return total;

        }
    }
}
