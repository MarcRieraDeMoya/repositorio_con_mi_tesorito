namespace ex12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("coordenades2.txt");
            string linia;
            double x, y, coordenades, radi, distancia;

            //Valors entrada
            Console.Write($"Escriu el valor del radi: ");
            radi = Convert.ToInt32(Console.ReadLine());

            //Llegir fitxer
            coordenades = Convert.ToDouble(fitxer.ReadLine());
            for (int i = 0; i < coordenades; i++)
            {

                x = Convert.ToDouble(fitxer.ReadLine().Replace('.',','));
                y = Convert.ToDouble(fitxer.ReadLine().Replace('.', ','));
                distancia = Distancia(x, y);
                if (distancia < radi)
                    Console.WriteLine($"Les coordenades ({x}, {y}) estan dins del perímetre del radi {radi}");
                else if (distancia > radi)
                    Console.WriteLine($"Les coordenades ({x}, {y}) estan fora del perímetre del radi {radi}");
                else
                    Console.WriteLine($"Les coordenades ({x}, {y}) estan sobre el perímetre del radi {radi}");
                coordenades++;
            }
            
        }
        static double Distancia(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x - 0, 2) + Math.Pow(y - 0, 2));
        }
    }
}
