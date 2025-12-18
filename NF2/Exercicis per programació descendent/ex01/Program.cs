namespace ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pulsa una tecla per accedir al menu");
            Console.ReadKey();
            Menu();

        }

        static void MenuMostrar()
        {
            Console.Clear();

            Console.WriteLine("Cercar equip");
            Console.WriteLine("Gols d'un equip en una temporada");
            Console.WriteLine("Mostrar resultat d'un partit concret");
            Console.WriteLine("Punts fet per un equip en una temporada");
            Console.WriteLine("Exit");


        }

        static void Menu()
        {
            ConsoleKeyInfo tecla;

            do
            {
                Console.Clear();
                MenuMostrar();
                tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        DoSearchTeam();
                        Console.WriteLine("Pulsa qualsevol tecla per tornar al menu");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        DoGetGoalsTeam();
                        Console.WriteLine("Pulsa qualsevol tecla per tornar al menu");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        DoGeMatch();
                        Console.WriteLine("Pulsa qualsevol tecla per tornar al menu");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        DoGetPointsTeam();
                        Console.WriteLine("Pulsa qualsevol tecla per per tornar al menu");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D0:
                        Console.Clear();
                        Console.Write("Fins despres");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Tecla no valida");
                        Console.ReadKey();
                        break;
                        

                }

            } while (tecla.Key != ConsoleKey.D0);


        }

        static string DoSearchTeam()
        {
            StreamReader fitxer = new StreamReader("TEAMS.TXT");
            string linia1, linia2, abreviatura;
            bool trobat = false;
            Console.Write("Escriu la abreviatura de l'equip: ");
            abreviatura = Console.ReadLine();
            linia1 = fitxer.ReadLine();
            linia2 = linia1;

            while(!trobat && linia1 != null)
            {
                if (linia1 == abreviatura)
                {
                    trobat = true;
                }
                else
                {
                    linia1 = fitxer.ReadLine();
                    linia2 = linia1;
                }

            }
            fitxer.Close();

            if (trobat)
            {
                Console.Clear();
                return $"{linia2}";
            }
            else
            {
                Console.Clear();
                return "Equip no trobat";
            }
            

        }

        static string DoGetGoalsTeam()
        {
            StreamReader fitxer = new StreamReader("TEAMS.TXT");
            StreamReader fitxer2 = new StreamReader("MATCHES.TXT");
            string linia1, linia2, abreviatura;
            bool trobat = false;
            Console.Write("Escriu la abreviatura de l'equip: ");
            abreviatura = Console.ReadLine();
            linia1 = fitxer.ReadLine();
            linia2 = linia1;

            while (!trobat && linia1 != null)
            {
                if (linia1 == abreviatura)
                {
                    trobat = true;
                }
                else
                {
                    linia1 = fitxer.ReadLine();
                    linia2 = linia1;
                }

            }
            fitxer.Close();

            if (trobat)
            {
                Console.Clear();
                return linia2;
            }
            else
            {
                Console.Clear();
                return "Equip no trobat";
            }
        }

        static void DoGeMatch()
        {

        }

        static void DoGetPointsTeam()
        {

        }
    }
}
