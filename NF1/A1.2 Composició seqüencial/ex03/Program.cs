internal class Program
    {
        static void Main(string[] args)
        {
        // Declaració de variables

            int hores;
            int minuts;
            int segons;
            int tempsTotal;

        // Valors de entrada

            Console.Write("INTRODUEUX UN NUMERO DE HORES --> ");
            hores = Convert.ToInt32(Console.ReadLine()) * 60 * 60;
            Console.Write("INTRODUEUX UN NUMERO DE MINUTS --> ");
            minuts = Convert.ToInt32(Console.ReadLine()) * 60;
            Console.Write("INTRODUEUX UN NUMERO DE SEGONS --> ");
            segons = Convert.ToInt32(Console.ReadLine());

        // Algorisme /calculs 

            tempsTotal = hores + minuts + segons;

        // Valors de sortida 

            Console.WriteLine($"EL TEMPS TOTAL ES {tempsTotal} SEGONS ");


        }
    }

