
using System.Globalization;

namespace INVENTARI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Inventari inventari = new Inventari();
            inventari.CarregarInventari();
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                MostrarMenu();

                Console.Write("\nENTRA UNA OPCIÓ: ");
                tecla = Console.ReadKey();

                Console.WriteLine();

                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                        DoCarregarProductes(inventari);
                        MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
                        break;

                    case ConsoleKey.D2:
                        DoLlistarProductes(inventari);
                        MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
                        break;

                    case ConsoleKey.D3:
                        DoAfegirProducte(inventari);
                        MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
                        break;

                    case ConsoleKey.D4:
                        DoEliminarProducte(inventari);
                        MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
                        break;

                    case ConsoleKey.D5:
                        DoActualitzarEstoc(inventari);
                        MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
                        break;

                    case ConsoleKey.D6:
                        DoValorTotalEstoc(inventari);
                        MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
                        break;

                    case ConsoleKey.D0:
                        DoGuardarInventari(inventari);
                        Console.WriteLine("\nHAS FINALITZAT EL PROGRAMA.");
                        MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
                        break;
                    default:
                        Console.WriteLine("\nOPCIÓ NO VÁLIDA.");
                        MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
                        break;
                }
            } while (tecla.Key != ConsoleKey.D0);

        }

        /// <summary>
        /// Procediment que carrega tots els productes del fitxer on es troba l'inventari.
        /// </summary>
        /// <param name="inventari"></param>
        private static void DoCarregarProductes(Inventari inventari)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Procediment que llista tots els productes de l'inventari.
        /// </summary>
        /// <param name="inventari"></param>
        private static void DoLlistarProductes(Inventari inventari)
        {
            Console.Clear();
            Console.WriteLine($"PRODUCTES AL MAGATZEM: {inventari.count}.");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Id;Nom;Preu;Quantitat;Tipus");
            for (int i = 0; i <= inventari.count; i++)
            {
                Console.WriteLine(inventari.Productes[i]);
            }
        }

        /// <summary>
        /// Procediment que afegeix un nou producte a l'inventari.
        /// El procediment demana a l'usuari tots els valors d'un producte i l'afageix a l'inventari.
        /// </summary>
        /// <param name="inventari"></param>
        private static void DoAfegirProducte(Inventari inventari)
        {
            int id;
            string nom;
            double preu;
            int quantitat;
            string categoria;

            try
            {
                Console.Write("ENTRA LA ID DEL PRODUCTE: ");
                id = int.Parse(Console.ReadLine());
                Console.Write("ENTRA EL NOM DEL PRODUCTE: ");
                nom = Console.ReadLine();
                Console.Write("ENTRA EL PREU DEL PRODUCTE: ");
                preu = double.Parse(Console.ReadLine());
                Console.Write("ENTRA LA QUANTITAT DEL PRODUCTE: ");
                quantitat = int.Parse(Console.ReadLine());
                Console.Write("ENTRA LA CATEGORIA DEL PRODUCTE: ");
                categoria = Console.ReadLine();

                inventari.AfegirProducte(new Producte(id, nom, preu, quantitat, categoria));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// El procediment demana el codi de producte i l'elimina de l'inventari.
        /// </summary>
        /// <param name="inventari"></param>
        private static void DoEliminarProducte(Inventari inventari)
        {
            try
            {
                Console.Write("Introdueix la ID del producte a eliminar: ");
                int id = int.Parse(Console.ReadLine());
                inventari.EliminarProducte(id);
                Console.WriteLine("Producte eliminat correctament");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Procediment que demana a l'usuari el codi d'un producte i una quantitat a afegir d'estoc.
        /// El procediment afegeix la quantitat d'estoc al producte.
        /// </summary>
        /// <param name="inventari"></param>
        private static void DoActualitzarEstoc(Inventari inventari)
        {
            int id;
            int quantitat;

            try
            {
                Console.Write("Introdueix la ID del producte a modificar: ");
                id = int.Parse(Console.ReadLine());
                Console.Write("Introdueix el estoc actual: ");
                quantitat = int.Parse(Console.ReadLine());

                inventari.AfegirQuantitat(id, quantitat);
                Console.WriteLine("Estoc actualitzat correctament");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Procediment que retorna el valor total de l'estoc que té el magatzem.
        /// </summary>
        /// <param name="inventari"></param>
        private static void DoValorTotalEstoc(Inventari inventari)
        {
            Console.WriteLine($"El valor total de l'estoc és: {inventari.ValorTotal}€");
        }

        /// <summary>
        /// Procediment que guarda l'inventari a fitxer.
        /// El procediment ha de demanar a l'usuari si vol guardar l'inventari (s/n).
        /// </summary>
        /// <param name="inventari"></param>
        private static void DoGuardarInventari(Inventari inventari)
        {
            inventari.GuardarInventari();
        }

        /// <summary>
        /// Procediment que mostra un missatge per pantalla i espera que
        /// l'usuari premi una tecla.
        /// </summary>
        /// <param name="msg"></param>
        public static void MsgNextScreen(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Mostra el menú principal del programa
        /// </summary>
        public static void MostrarMenu()
        {
            Console.WriteLine("GESTIÓ DE L'INVENTARI");
            Console.WriteLine("---------------------");
            Console.WriteLine("1- CARREGAR PRODUCTES");
            Console.WriteLine("2- LLISTAR PRODUCTES");
            Console.WriteLine("3- AFEGIR NOU PRODUCTE");
            Console.WriteLine("4- ELIMINAR PRODUCTE");
            Console.WriteLine("5- ACTUALITZAR ESTOC");
            Console.WriteLine("6- VALOR TOTAL ESTOC");
            Console.WriteLine("0- EXIT");
        }



    }
}
