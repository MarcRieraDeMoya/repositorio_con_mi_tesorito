using Microsoft.VisualBasic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaulaLlista<Equips> equips = new TaulaLlista<Equips>();

            StreamReader sr = new StreamReader("EQUIPS.txt");

            string linia = sr.ReadLine();

            while (linia != null)
            {
                equips.Add(new Equips(linia));

                linia = sr.ReadLine();
            }

            
            


        }
    }
}
