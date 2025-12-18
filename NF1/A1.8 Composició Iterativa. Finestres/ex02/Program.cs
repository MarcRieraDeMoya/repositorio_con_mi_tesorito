namespace ex02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NO_CREIXENT.TXT");
            int valor1, valor2, valor3;
            string linia;
            bool noEsCreixent = false;
            linia = fitxer.ReadLine();
            valor1 = Convert.ToInt32(linia);
            linia = fitxer.ReadLine();
            valor2 = Convert.ToInt32(linia);
            linia = fitxer.ReadLine();
            

            while (linia != null && !noEsCreixent )
            {
                valor3 = Convert.ToInt32(linia);
                
                if ( valor1 > valor2 && valor2 > valor3 )
                {
                    noEsCreixent = false;
                }
                else
                {
                    noEsCreixent = true;
                }
                linia = fitxer.ReadLine();

                valor1 = valor2;
                valor2 = valor3;
                valor3 = Convert.ToInt32(linia);

            }

            if (!noEsCreixent)
            {
                Console.WriteLine("Es estrictament creixent");
            }
            else
            {
                Console.WriteLine("Es estrictament creixent");
            }

        }
    }
}
