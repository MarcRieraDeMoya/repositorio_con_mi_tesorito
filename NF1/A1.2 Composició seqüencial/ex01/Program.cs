internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

        int anys;

        // Valors de entrada

        Console.Write("QUANTS ANYS TENS? ");
        anys = Convert.ToInt32(Console.ReadLine());

        // Algorisme /calculs

        anys = anys + 1;

        // Valors de sortida

        Console.WriteLine($"TENS: { anys - 1} ANYS I L'ANY VINENT TINDRAS { anys } ANYS");

    }
}

