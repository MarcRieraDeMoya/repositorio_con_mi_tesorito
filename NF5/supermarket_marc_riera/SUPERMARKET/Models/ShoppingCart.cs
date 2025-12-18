using System.Text;

namespace SUPERMARKET.Models
{
    public class ShoppingCart
    {
        #region atributs
        private Dictionary<Item, double> shoppingList;
        private Customer customer;
        private DateTime? dateOfPurchase;
        #endregion

        #region constructors 
        public ShoppingCart(Customer customer, DateTime dateOfPurchase)
        {
            this.customer = customer;
            this.dateOfPurchase = dateOfPurchase;
        }
        #endregion

        #region propietats 
        public Dictionary<Item, double> ShoppingList => shoppingList;

        public Customer Customer => customer;

        public DateTime? DateOfPurchase => dateOfPurchase;


        #endregion

        public void AddOne(Item item, double qty)
        {
            if (item.PackingType != Item.Packaging.Kg && (int)qty != qty)
            {
                throw new ArgumentException("no es poden passar decimals a el package i les units");
            }
            else
            {
                if (!shoppingList.ContainsKey(item))
                {
                    shoppingList.Add(item, qty);
                }
                else
                {
                    shoppingList[item] += qty;
                }
                
            }

        }

        public void AddAllRandomly(SortedDictionary<int, Item> wareHouse)
        {
            double qtyRand;
            Random rand = new Random();
            Dictionary<Item, double> shoppingListRand = new Dictionary<Item, double>();
            int iRand = rand.Next(1, 11);
     
            List<int> claus = new List<int>(wareHouse.Keys);

            for(int i = 0;  i < iRand ; i++)
            {
                int clauRand = claus[rand.Next(claus.Count)];
                Item itemRand = wareHouse[clauRand];
                qtyRand = rand.Next(1, 6);

                shoppingListRand.Add(itemRand, qtyRand);

            }

        }




        public int RawPointsObtainedAtChekout(double totalInvoiced)
        {
            int points;
            points =(int) totalInvoiced / 100;

            return points;
        }

        public static double ProcessItems(ShoppingCart cart)
        {
            double importTotal = 0;
            double quantitat  = 0;
            double totalArrodonit;
            foreach(KeyValuePair<Item, double> items in cart.shoppingList)
            {
                quantitat = items.Value;

                if(items.Key.Stock < quantitat)
                {
                    quantitat = items.Key.Stock;

                    importTotal += quantitat * items.Key.Price;
                    
                    Item.UpdateStock(items.Key, -quantitat);

                }
                else
                {
                    importTotal = quantitat * items.Key.Price;
                    Item.UpdateStock(items.Key, -quantitat);
                }
            }

            totalArrodonit = Math.Round(importTotal, 2);

            return totalArrodonit;
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("**********");
            sb.Append($"INFO CARRITO DE COMPRA CLIENT -> {customer}");

            foreach(KeyValuePair<Item, double> items in shoppingList)
            {
                sb.Append($"{items.Key.Description}\t- CAT --> {items.Key.GetCategory}\t- QTY --> {items.Value}\t- UNIT PRICE --> {items.Key.Price}\t \u20AC");
            }

            sb.Append("****FI CARRITO COMPRA****");

            return sb.ToString();
        }

























    }
}
