using ex01.model;

namespace ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaulaLlista<Pokemon> taula1 = new TaulaLlista<Pokemon>();
            Pokemon pokemon1 = new Pokemon("pikachu",10,10,10);
            Pokemon pokemon2 = new Pokemon("charmander", 100, 1, 10);
            Pokemon pokemon3 = new Pokemon("bulbasaur", 50, 100, 1);
            Pokemon pokemon4 = new Pokemon("squirtle", 20, 10, 100);
            Pokemon pokemon5 = new Pokemon("moltres", 1000, 100, 10);
            Pokemon pokemon6 = new Pokemon("articuno", 100, 100, 1000);

            taula1.Add(pokemon1);
            taula1.Add(pokemon2);

            Console.WriteLine(taula1[0].ToString());

        }
    }
}
