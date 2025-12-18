using SUPERMARKET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUPERMARKET.Core
{
    public class CheckOutLine
    {
        #region atributs
        private int number;
        private Queue<ShoppingCart> queue;
        private Person cashier;
        private bool active;
        #endregion

        #region constructors
        public CheckOutLine(Person responsible, int number)
        {
            this.number = number;
            cashier = responsible;
            queue = new Queue<ShoppingCart>();
        }
        #endregion

        #region metodes
        public bool CheckIn(ShoppingCart oneShoppingCart)
        {
            bool estat;

            if(active == false)
            {
                estat = false;
            }
            else
            {
                queue.Enqueue(oneShoppingCart);
                estat = true;
            }

            return estat;

        }

        public bool CheckOut()
        {
            bool realitzat = false;
            ShoppingCart cart = queue.Dequeue();
            double totalinvoiced = ShoppingCart.ProcessItems(cart);
            int puntsObtinguts = cart.RawPointsObtainedAtChekout(totalinvoiced);

            cart.Customer.AddInvoiceAmount(totalinvoiced);
            cart.Customer.AddPoints(puntsObtinguts);
            cashier.AddInvoiceAmount(totalinvoiced);
            cashier.AddPoints(puntsObtinguts);
            cart.Customer.Active = false;
            realitzat = true;
            return realitzat;


        }

        public override string ToString()
        {
            string final;
            StringBuilder sb = new StringBuilder();

            if(queue == null)
            {
               final = $"NUMERO DE CAIXA --> {number} \nCAIXER/A AL CARREC --> {cashier.FullName} \nCUA BUIDA";
            }
            else
            {
                sb.Append($"NUMERO DE CAIXA --> {number} \nCAIXER/A AL CARREC --> {cashier.FullName}");
                foreach (ShoppingCart cart in queue)
                {
                    sb.Append(cart.ToString());
                }
                final = sb.ToString();
            }

            return final ;
        }


        public string GetCheckOutLineStatus()
        {
            StringBuilder sb = new StringBuilder();

            if(active == true && queue == null)
            {
                sb.Append($"LINIA{number} [opened]");
            }
            else
            {
                sb.Append($"LINIA{number} [opened] ");

                for(int i = 0; i < queue.Count; i++)
                {
                    sb.Append("* ");
                }
            }

            return sb.ToString();

        }




        #endregion





    }
}
