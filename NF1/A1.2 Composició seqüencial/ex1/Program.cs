internal class Program
    {/// <summary>
     /// Es un programa on bàsicament es suma un 1 al valor que l’usuari introdueixi a la 
     /// consola i posteriorment a sota ens mostra el nostre valor i el resultat de sumar-li 1.
     /// El tema es que el programa ens ho mostra de dues maneres (si per exemple introduïm “1” ens apareix
     /// HAS ENTRAT : 1 I UN MÉS VAL 2 i també HAS ENTRAT : 0001 I UN MÉS VAL 0002)
     /// </summary>
     /// <param name="args"></param>
    static void Main(string[] args)
        {
        // Declaració de variables
        int n;

        // Valors de entrada

        n = Convert.ToInt32(Console.ReadLine());

        // Algorisme /calculs

        n = n + 1;

        // Valors de sortida

        Console.WriteLine($"HAS ENTRAT: {n - 1} I UN MÉS VAL { n}");
        Console.WriteLine($"HAS ENTRAT: {n - 1:0000} I UN MÉS VAL { n: 0000}");
        }
    }

