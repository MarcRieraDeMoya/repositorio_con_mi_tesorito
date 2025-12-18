namespace ex07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero , mesGran , mesPetit;

            Console.Write("Introdueix Valors: ");
            numero = Convert.ToInt32(Console.ReadLine());
            mesGran = numero;
            mesPetit = numero;
            
            

            while (numero != 0)
            {

                if (numero > mesGran)
                    mesGran = numero;
                else if (numero < mesPetit)
                    mesPetit = numero;
                
                Console.Write("Introdueix Valors: ");
                numero = Convert.ToInt32(Console.ReadLine());


            }

            Console.Write($"El valor mes petit es {mesPetit} i el mes gran es {mesGran}");
        }
    }
}
