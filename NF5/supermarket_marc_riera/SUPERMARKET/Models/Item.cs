using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SUPERMARKET.Models
{
    public class Item : IComparable<Item>
    {
        #region atributs
        private char currency;
        private int code;
        private string description;
        private bool onSale;
        private double price;
        private Category category;
        private Packaging packing;
        private double stock;
        private int minStock;
        #endregion

        #region enums
        public enum Category
        { BEVERAGE = 1, FRUITS, VEGETABLES, BREAD, MILK_AND_DERIVATIVES, GARDEN, MEAT, SWEETS, SAUCES, FROZEN, CLEANING, FISH, OTHER };
        public enum Packaging { Unit='U', Kg='K', Package='P' };
        #endregion

        #region constructors
        public Item(Category category, int code, char currency, string description, int minStock, bool onSale, Packaging packing, double price, double stock)
        {
            this.currency = '\u20AC';
            this.category = category;
            this.code = code;
            this.description = description;
            this.minStock = minStock;
            this.onSale = onSale;
            this.packing = packing;
            this.price = price;
            this.stock = stock;
        }
        #endregion  

        #region propietats

        public int Code { get => code; }
        public string Description { get => description; }
        public Category GetCategory { get => category; }
        public int MinStock { get => minStock; }
        public bool OnSale { get => onSale; }
        public Packaging PackingType { get => packing; }
        public double Stock { get => stock; }

        public double Price
        {
            get
            {
                if (onSale)
                {
                    return price * 0.9;
                }
                else
                {
                    return price;
                }
            }
        }
        #endregion

        #region metodes
        public static void UpdateStock(Item item, double qty)
        {
            if (qty == 0)
            {
                throw new Exception("VALOR INVALID");
            }
            else if(qty > 0)
            {
                item.stock = qty + item.stock;
            }
            else
            {
                item.stock = item.stock - (-qty);
            }

        }
        public int CompareTo(Item? other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.price.CompareTo(other.price);
        }

        public override bool Equals(object? obj)
        {
            return obj is Item other && code == other.code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(code);
        }
        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (onSale)
            {
                return $"CODE->{code}\t DESCRIPTION->{description}\t\tCATEGORY->{category}\tSTOCK->{stock}\tMIN_STOCK->{minStock}\tPRICE->{price}€\tON SALE->{OnSale}€\n";
            }
            else
            {
                return $"CODE->{code}\t DESCRIPTION->{description}\t\tCATEGORY->{category}\tSTOCK->{stock}\tMIN_STOCK->{minStock}\tPRICE->{price}€\tON SALE->N\n";
            }


        }
        #endregion
    }
}
