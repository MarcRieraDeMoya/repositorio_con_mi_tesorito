using System.Security.Cryptography.X509Certificates;

namespace ExerciciExtra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mes;
            int any;


            Console.Write("Escriu un mes de l'any : ");
            mes = Convert.ToInt32(Console.ReadLine());

            if (mes < 1 || mes > 12)
            {
                Console.WriteLine("Valor invalid");

            }
            else
            {
                Console.Write("Escriu any de 1900 en endavant : ");
                any = Convert.ToInt32(Console.ReadLine());

                if (any < 1900)
                {
                    Console.WriteLine("Valor invalid");
                }
                else
                {
                    Console.WriteLine($"{DiesDelMes(mes , any)}");
                }
            }
           

        }

        static string DiesDelMes( int mes, int any)
        {

            if (mes == 2 && any % 4 == 0)
            {
                return $"El mes 2 de l'any {any} te 29 dies";
            }
            else if (mes == 2 && any % 4 != 0)
            {
                return $"El més 2 de l'any {any} te 28 dies";
            }
            else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                return $"El mes {mes} te 30 dies";
            }
            else
            {
                return $"El mes {mes} te 31 dies";
            }

        }

    }
}
