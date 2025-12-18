internal class Program
    {
        static void Main(string[] args)
        {
            // Declaració de variables

            int segonsTotal;
            int segons;
            int minuts;
            int hores;

            // Valors de entrada

            Console.Write("ESCRIU UN NUMERO DE SEGONS --> ");
            segonsTotal = Convert.ToInt32(Console.ReadLine());

            // Algorismes /calculs

            hores = segonsTotal / 3600;
            minuts = (segonsTotal - (hores * 3600)) / 60;
            segons = segonsTotal - (hores * 3600) - (minuts * 60);

        // Valors de sortida

        Console.Write($"EL NUMERO DE SEGONS INTRODUITS SERIEN {hores:00}:{minuts:00}:{segons:00} EN FORMAT HH:MM:SS ");

        }
    }

