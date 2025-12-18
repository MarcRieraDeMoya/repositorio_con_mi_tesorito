namespace ex._30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mes;
            int dia;
            int ddmm;

            Console.Write("Escrui un un dia i un mes en format dd/mm : ");
            ddmm = Convert.ToInt32(Console.ReadLine());

            dia = ddmm / 100;
            mes = ddmm % 100;

        }

       
        }
    }
}
