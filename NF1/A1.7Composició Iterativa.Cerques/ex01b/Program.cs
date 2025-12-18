using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

namespace ex01b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FILE_NAME = "NUMEROS.TXT";
            StreamReader fitxer = new StreamReader(FILE_NAME);
            string linia;
            int numero;
            bool hihanegatiu = false;
            linia = fitxer.ReadLine();
            
            
            while (!hihanegatiu && linia != null )
            {
                numero = Convert.ToInt32(linia);
                hihanegatiu = numero < 0;
                linia = fitxer.ReadLine();
            }
            fitxer.Close();
                
            if (hihanegatiu)
            {
                Console.Write("Tots no son positius");
            }
            else
            {
                Console.Write("Tots son positius");

            }



        }


    }
}
