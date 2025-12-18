using SUPERMARKET.Core;
using SUPERMARKET.Models;
using System.ComponentModel;
using System.Text;
using System.Timers;

namespace SUPERMARKET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Cashier
            //Proves de la classe Cashier
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Proves de cashier");
            Console.WriteLine("-------------------------");

            DateTime actualitat = DateTime.Now;
            DateTime antiguitat = DateTime.Now.AddYears(-10);
            Cashier c1 = new Cashier("20561847P", "Pepita Cruz", actualitat);
            Console.WriteLine(c1);
            c1.AddPoints(1);
            Console.WriteLine(c1);
            Console.WriteLine("-------------");
            Cashier c2 = new Cashier("78206319T", "Manolo Ribera", antiguitat);
            Console.WriteLine(c2);
            c2.Active = true;
            c2.AddPoints(2); c2.AddInvoiceAmount(4);
            Console.WriteLine(c2);
            #endregion

            #region Item
            ////Proves de la clase Item
            Console.WriteLine("proves de item");
            Console.WriteLine("-------------------------");

            Item pechugaPavo = new Item(Item.Category.MEAT, 1001, '€', "pits de gall dindi", 10, true, Item.Packaging.Kg, 5.35, 70);
            Item filetesSalmon = new Item(Item.Category.FISH, 1002, '€', "filets de salmo", 5, false, Item.Packaging.Kg, 10.57, 20);


            Console.WriteLine($"preu del salmo: {filetesSalmon.Price}€");
            Console.WriteLine($"preu del pits de gall dindi amb descompte: {pechugaPavo.Price}€");
            Console.WriteLine("--------------");
            Console.WriteLine("augment i decrement del stock");

            Item carbasso = new Item(Item.Category.VEGETABLES, 1003, '€', "casbassons", 20, false, Item.Packaging.Kg, 3.50, 100);

            Console.WriteLine($"stock inicial dels carbassons: {carbasso.Stock}");
            Item.UpdateStock(carbasso, 10);
            Console.WriteLine($"stock després d'afegir 10: {carbasso.Stock}");
            Item.UpdateStock(carbasso, -7);
            Console.WriteLine($"stock després de restar 7: {carbasso.Stock}");

            Console.WriteLine("--------------");
            Console.WriteLine("comparacions");
            Item item1 = new Item(Item.Category.FROZEN, 1004, '€', "magnum", 5, false, Item.Packaging.Package, 1.20, 10);
            Item item2 = new Item(Item.Category.CLEANING, 1005, '€', "Don Limpio", 10, false, Item.Packaging.Unit, 0.95, 20);

            int result = item1.CompareTo(item2);
            if (result < 0) Console.WriteLine("el primer producte es més barat");
            else if (result > 0) Console.WriteLine("el segon producte es més barat");
            else Console.WriteLine("mateix preu");

            Console.WriteLine("--------------");
            Console.WriteLine("equals");
            Item item3 = new Item(Item.Category.BREAD, 1006, '€', "catalana", 5, false, Item.Packaging.Unit, 2.50, 15);
            Item item4 = new Item(Item.Category.SWEETS, 1007, '€', "nuvols", 5, false, Item.Packaging.Kg, 2.50, 20);  // mateix codi
            Item item5 = new Item(Item.Category.SAUCES, 1008, '€', "maionesa", 5, false, Item.Packaging.Unit, 1.80, 30);  // codi diferent

            Console.WriteLine($"el item3 es igual al item4? {item3.Equals(item4)}");
            Console.WriteLine($"el item3 es igual al item5? {item3.Equals(item5)}");
            #endregion

            #region Customer
            //Proves de la classe Customer
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Proves de customer");
            Console.WriteLine("-------------------------");

            Customer cus1 = new Customer("36916727B", "Pedro Picapiedra", 500);
            Customer cus2 = new Customer("72650937Y", "Daisy Mouse", null);

            Console.WriteLine("Proves de AddPoints");
            Console.WriteLine(cus1.ToString());
            cus1.AddPoints(10);
            Console.WriteLine($"Punts despres d'afegir 10 punts:");
            Console.WriteLine(cus1.ToString());

            Console.WriteLine(cus2.ToString());
            cus2.AddPoints(66);
            Console.WriteLine($"No es poden afegir per que no te targeta de fidelitzacio:");
            Console.WriteLine(cus2.ToString());



            #endregion

            #region SuperMarket

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SuperMarket super1 = new SuperMarket("MercaRobo", "Calle España 3", "CUSTOMERS.TXT", "CASHIERS.TXT", "GROCERIES.TXT", 3);
            Dictionary<Customer, ShoppingCart> carrosPassejant = new Dictionary<Customer, ShoppingCart>();

            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                MostrarMenu();
                tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                        DoNewShoppingCart(carrosPassejant, super1);
                        break;
                    case ConsoleKey.D2:
                        DoAfegirUnArticleAlCarro(carrosPassejant, super1);

                        break;
                    case ConsoleKey.D3:
                        DoCheckIn(carrosPassejant, super1);

                        break;
                    case ConsoleKey.D4:
                        if (DoCheckOut(super1)) Console.WriteLine("BYE BYE. HOPE 2 SEE YOU AGAIN!");
                        else Console.WriteLine("NO S'HA POGUT TANCAR CAP COMPRA");

                        break;
                    case ConsoleKey.D5:
                        DoOpenCua(super1);

                        break;
                    case ConsoleKey.D6:
                        DoInfoCues(super1);

                        break;

                    case ConsoleKey.D7:
                        DoClientsComprant(carrosPassejant);


                        break;
                    case ConsoleKey.D8:
                        DoListCustomers(super1);

                        break;

                    case ConsoleKey.D9:
                        SortedSet<Item> articlesOrdenatsPerEstoc = super1.GetItemsByStock();
                        DoListArticlesByStock("LLISTAT D'ARTICLES - DATA " + DateTime.Now, articlesOrdenatsPerEstoc);

                        break;
                    case ConsoleKey.A:
                        DoCloseQueue(super1);

                        break;
                    case ConsoleKey.B:
                        DoMostrarPanellLinies(super1);

                        break;
                    case ConsoleKey.C:
                        DoListProductesFaltants(super1);

                        break;

                    case ConsoleKey.D0:
                        MsgNextScreen("PRESS ANY KEY 2 EXIT");
                        break;
                    default:
                        MsgNextScreen("Error. Prem una tecla per tornar al menú...");
                        break;
                }

            } while (tecla.Key != ConsoleKey.D0);


        }

        //OPCIO B


        public static void DoMostrarPanellLinies(SuperMarket super)
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                CheckOutLine linia = super.GetCheckOutLine(i);

                if (linia == null)
                {
                    Console.WriteLine($"LINIA{i} [closed]");
                }
                Console.WriteLine(linia.GetCheckOutLineStatus());

                MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");

            }
        }


        public static void DoListProductesFaltants(SuperMarket super)
        {

            Console.Clear();

            StringBuilder sb = new StringBuilder();

            List<Item> productesFalt = super.GetProductesFaltants();

            if(productesFalt.Count == 0)
            {
                Console.WriteLine("NO HI HA CAP PRODUCTE FALTANT ");
                Console.WriteLine("PREM UNA TECLA PER CONTINUAR");
            }
            else
            {
                sb.Append($"PRODUCTES FALTANTS --> {productesFalt.Count} \n");

                foreach(Item producte in productesFalt)
                {
                    sb.Append($"{producte.Code};{producte.Stock};{producte.MinStock};{producte.Description} \n");
                }

                Console.WriteLine(sb.ToString());
            }


            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");

        }






        //OPCIO 1 - Entra un nou client i se li assigna un carro de la compra. S'omple el carro de la compra
        /// <summary>
        /// Crea un nou carro de la compra assignat a un Customer inactiu
        /// L'omple d'articles aleatòriament 
        /// i l'afegeix als carros que estan passejant pel super
        /// </summary>
        /// <param name="carros">Llista de carros que encara no han entrat a cap 
        /// cua de pagament</param>
        /// <param name="super">necessari per poder seleccionar un client inactiu</param>
        public static void DoNewShoppingCart(Dictionary<Customer, ShoppingCart> carros, SuperMarket super)
        {
            Console.Clear();
            Person client = super.GetAvaliableCustomer();
            Customer customer = (Customer)client;
            ShoppingCart nouCarrito = new ShoppingCart(customer, DateTime.Now);

            nouCarrito.AddAllRandomly(super.WareHouse);

            carros.Add(customer, nouCarrito);

            Console.WriteLine(super.ToString());

            Console.WriteLine(nouCarrito.ToString());


            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
        }

        //OPCIO 2 - AFEGIR UN ARTICLE ALEATORI A UN CARRO DE LA COMPRA ALEATORI DELS QUE ESTAN VOLTANT PEL SUPER
        /// <summary>
        /// Dels carros que van passejant pel super, 
        /// es selecciona un carro a l'atzar i un article a l'atzar
        /// i s'afegeix al carro de la compra
        /// amb una quantitat d'unitats determinada
        /// Cal mostrar el carro seleccionat abans i després d'afegir l'article.
        /// </summary>
        /// <param name="carros">Llista de carros que encara no han entrat a cap 
        /// cua de pagament</param>
        /// <param name="super">necessari per poder seleccionar un article del magatzem</param>
        public static void DoAfegirUnArticleAlCarro(Dictionary<Customer, ShoppingCart> carros, SuperMarket super)
        {
            Console.Clear();

            if (carros.Count == 0)
            {
                Console.WriteLine("No hi ha carros per afegir articles.");
                return;
            }

            Random rnd = new Random();

            List<Customer> keys = new List<Customer>(carros.Keys);
            Customer randomCustomer = keys[rnd.Next(keys.Count)];
            ShoppingCart selectedCart = carros[randomCustomer];

            List<Item> warehouseItems = new List<Item>(super.WareHouse.Values);
            if (warehouseItems.Count == 0)
            {
                Console.WriteLine("No hi ha articles al magatzem.");
                return;
            }

            Item randomItem = warehouseItems[rnd.Next(warehouseItems.Count)];

            int quantity = rnd.Next(1, 6);

            Console.WriteLine("Carro abans d'afegir article:");
            Console.WriteLine(selectedCart.ToString());

            selectedCart.AddOne(randomItem, quantity);

            Console.WriteLine("Carro després d'afegir article:");
            Console.WriteLine(selectedCart.ToString());

            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");

        }
        // OPCIO 3 : Un dels carros que van pululant pel super  s'encua a una cua activa
        // La selecció del carro i de la cua és aleatòria
        /// <summary>
        /// Agafem un dels carros passejant (random) i l'encuem a una de les cues actives
        /// de pagament.
        /// També hem d'eliminar el carro seleccionat de la llista de carros que passejen 
        /// Si no hi ha cap carro passejant o no hi ha cap linia activa, cal donar missatge 
        /// 
        /// </summary>
        /// <param name="carros">Llista de carros que encara no han entrat a cap 
        /// cua de pagament</param>
        /// <param name="super">necessari per poder encuar un carro a una linia de caixa</param>
        public static void DoCheckIn(Dictionary<Customer, ShoppingCart> carros, SuperMarket super)
        {
            Console.Clear();

            Person client = super.GetAvaliableCustomer();
            Customer customer = (Customer)client;
            ShoppingCart nouCarrito = new ShoppingCart(customer, DateTime.Now);

            nouCarrito.AddAllRandomly(super.WareHouse);

            Console.WriteLine(nouCarrito.ToString());


            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
        }

        // OPCIO 4 - CHECK OUT D'UNA CUA TRIADA PER L'USUARI
        /// <summary>
        /// Es demana per teclat una cua de les actives (1..ActiveLines)
        /// i es fa el checkout del ShoppingCart que toqui
        /// Si no hi ha cap carro a la cua triada, es dona un missatge
        /// </summary>
        /// <param name="super">necessari per fer el checkout</param>
        /// <returns>true si s'ha pogut fer el checkout. False en cas contrari</returns>

        public static bool DoCheckOut(SuperMarket super)
        {
            Console.Clear();
            Console.WriteLine("Introdueix el número de la cua per fer checkout:");
            int lineNumber = Convert.ToInt32(Console.ReadLine());

            if (lineNumber < 1 || lineNumber > super.ActiveLines)
            {
                Console.WriteLine("Número de cua no vàlid.");
                MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
                return false;
            }

            CheckOutLine linia = super.GetCheckOutLine(lineNumber);

            if (linia == null)
            {
                Console.WriteLine("La cua triada no està activa.");
                MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
                return false;
            }

            bool fet = linia.CheckOut();

            if (!fet)
            {
                Console.WriteLine("No hi ha cap carro a la cua triada.");
            }
            else
            {
                Console.WriteLine("Checkout realitzat correctament.");
            }

            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
            return fet;
        }
        /// <summary>
        /// En cas que hi hagin cues disponibles per obrir, s'obre la 
        /// següent linia disponible
        /// </summary>
        /// <param name="super"></param>
        /// <returns>true si s'ha pogut obrir la cua</returns>
        // OPCIO 5 : Obrir la següent cua disponible (si n'hi ha)
        public static bool DoOpenCua(SuperMarket super)
        {
            Console.Clear();

            int nextLineToOpen = super.ActiveLines + 1;
            bool fet = false;

            if (nextLineToOpen > 5)
            {
                Console.WriteLine("No hi ha més línies disponibles per obrir.");
                fet = false;
            }
            else
            {

                super.OpenCheckOutLine(nextLineToOpen);



                Console.WriteLine($"S'ha obert la línia {nextLineToOpen}.");
                fet = true;
            }

            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
            return fet;
        }

        //OPCIO 6 : Llistar les cues actives
        /// <summary>
        /// Es llisten totes les cues actives des de la 1 fins a ActiveLines.
        /// Apretar una tecla després de cada cua activa
        /// </summary>
        /// <param name="super"></param>
        public static void DoInfoCues(SuperMarket super)
        {
            Console.Clear();

            if (super.ActiveLines == 0)
            {
                Console.WriteLine("No hi ha línies actives.");
                return;
            }

            for (int i = 1; i <= super.ActiveLines; i++)
            {
                CheckOutLine line = super.GetCheckOutLine(i);
                if (line != null)
                {
                    Console.WriteLine(line.ToString());
                }
                else
                {
                    Console.WriteLine("Línia " + i + " no està activa.");
                }

                Console.WriteLine("Prem una tecla per continuar...");
                Console.ReadKey();
            }

            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");

        }


        // OPCIO 7 - Mostrem tots els carros de la compra que estan voltant
        // pel super però encara no han anat a cap cua per pagar
        /// <summary>
        /// Es mostren tots els carros que no estan en cap cua.
        /// Cal apretar una tecla després de cada carro
        /// </summary>
        /// <param name="carros"></param>
        public static void DoClientsComprant(Dictionary<Customer, ShoppingCart> carros)
        {
            Console.Clear();

            Console.WriteLine("CARROS VOLTANT PEL SUPER (PENDENTS D'ANAR A PAGAR): ");
            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");

            if (carros.Count == 0)
            {
                Console.WriteLine("No hi ha cap carro voltant pel supermercat.");
                MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");
                return;
            }

            foreach (KeyValuePair<Customer, ShoppingCart> entry in carros)
            {
                Customer client = entry.Key;
                ShoppingCart carro = entry.Value;

                Console.WriteLine(carro.ToString());
                MsgNextScreen("PREM UNA TECLA PER VEURE EL SEGÜENT CARRO");
            }

        }

        //OPCIO 8 : LListat de clients per rating
        /// <summary>
        /// Cal llistar tots els clients de més a menys rating
        /// Per poder veure bé el llistat, primer heu de fer uns quants
        /// checkouts i un cop fets, fer el llistat. Aleshores els
        /// clients que han comprat tindran ratings diferents de 0
        /// Jo he fet una sentencia linq per solucionar aquest apartat
        /// </summary>
        /// <param name="super"></param>
        public static void DoListCustomers(SuperMarket super)
        {

            Console.Clear();
            Console.WriteLine("LLISTAT DE CLIENTS PER RATING (DE MÉS A MENYS):\n");

            List<Customer> clientsOrdenats = super.Customers.Values
                .Cast<Customer>()
                .OrderByDescending(c => c.GetRating)
                .ThenBy(c => c.GetHashCode())
                .ToList();

            foreach (Customer client in clientsOrdenats)
            {
                Console.WriteLine(client.ToString());
            }

            MsgNextScreen("PREM UNA TECLA PER TORNAR AL MENÚ PRINCIPAL");

        }

        // OPCIO 9
        /// <summary>
        /// Llistar de menys a més estoc, tots els articles del magatzem
        /// </summary>
        /// <param name="header">Text de capçalera del llistat</param>
        /// <param name="items">articles que ja vindran preparats en la ordenació desitjada</param>
        public static void DoListArticlesByStock(String header, SortedSet<Item> items)
        {
            Console.Clear();
            Console.WriteLine(header);

            foreach (Item item in items)
            {
                Console.WriteLine(item.ToString());
            }

            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
        }

        // OPCIO A : Tancar cua. Només si no hi ha cap client
        /// <summary>
        /// Començant per la última cua disponible, tanca la primera que trobi sense
        /// cap carro encuat. (primer mirem la número "ActiveLines" després ActiveLines-1 ...
        /// Fins trobar una que estigui buida. La que trobem la eliminarem
        /// Cal afegir la propietat Empty a la classe ChecOutLine i  a la classe SuperMarket:
        /// el mètode public static bool RemoveQueue(Supermarket super, int lineToRemove)
        /// que elimina la cua amb número = lineToRemove i retorna true en cas que l'hagi 
        /// pogut eliminar (perquè no hi ha cap carro pendent de pagament)
        /// </summary>
        /// <param name="super"></param>
        public static void DoCloseQueue(SuperMarket super)
        {
            Console.Clear();

            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
        }


        public static void MsgNextScreen(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }


        #endregion
        public static void MostrarMenu()
        {
            Console.WriteLine("1- UN CLIENT ENTRA AL SUPER I OMPLE EL SEU CARRO DE LA COMPRA");
            Console.WriteLine("2- AFEGIR UN ARTICLE A UN CARRO DE LA COMPRA");
            Console.WriteLine("3- UN CARRO PASSA A CUA DE CAIXA (CHECKIN)");
            Console.WriteLine("4- CHECKOUT DE CUA TRIADA PER L'USUARI");
            Console.WriteLine("5- OBRIR SEGÜENT CUA DISPONIBLE");
            Console.WriteLine("6- INFO CUES");
            Console.WriteLine("7- CLIENTS VOLTANT PEL SUPERMERCAT");
            Console.WriteLine("8- LLISTAR CLIENTS PER RATING (DESCENDENT)");
            Console.WriteLine("9- LLISTAR ARTICLES PER STOCK (DE  - A  +)");
            Console.WriteLine("A- CLOSE QUEUE");
            Console.WriteLine("B- MOSTRAR PANELL DE LINIES");
            Console.WriteLine("C- PRODUCTES FALTANTS");
            Console.WriteLine("0- EXIT");
        }
    }
}
