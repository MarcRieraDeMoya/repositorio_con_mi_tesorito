namespace ex02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader fitxer = new StreamReader("NUMEROS.TXT");
            string linia;
            int numero,primerNumero, cont = 1;
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);
            primerNumero = numero;
            linia = fitxer.ReadLine();
            numero = Convert.ToInt32(linia);

            while (cont != 2 && linia != null)
            {
                
                if (numero == primerNumero)
                {
                    cont++;
                }
                numero = Convert.ToInt32(linia);
                linia = fitxer.ReadLine();
            }
            if(cont != 2)
            {
                Console.Write($"No es repeteix el primer numero");            }
            else
            {
                Console.Write($"Si es repeteix el primer numero que es el numero {primerNumero}");
            }
        }
    }
}
