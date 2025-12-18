using SUPERMARKET.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SUPERMARKET.Core
{
    public class SuperMarket
    {
        #region atributs
        const int MAXLINES = 5;

        private string name;
        private string address;
        private string fileCustomers;
        private string fileCashiers;
        private string fileItems;
        
        private int activeLines;

        private CheckOutLine[] linies;

        Dictionary<string, Person> staff;

        Dictionary<string, Person> customers;

        SortedDictionary<int, Item> warehouse;

        #endregion

        #region propietats
        public string Name { get => name;  }

        public Dictionary<string, Person> Customers => customers;

        public Dictionary<string, Person> Staff => staff;

        public SortedDictionary<int, Item> WareHouse => warehouse;

        public int ActiveLines => activeLines;
        #endregion

        #region constructors
        public SuperMarket(string name, string address, string fileCustomers, string fileCashiers, string fileItems, int activeLines)
        {
            this.name = name;
            this.address = address;
            this.fileCustomers = fileCustomers;
            this.fileCashiers = fileCashiers;
            this.fileItems = fileItems;

            this.customers = LoadCustomers(fileCustomers);
            this.staff = LoadCashiers(fileCashiers);
            this.warehouse = LoadWarehouse(fileItems);

            if (activeLines > 0 && activeLines <=  MAXLINES)
            {
                this.activeLines = activeLines;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Valor no valid");
            }

            linies = new CheckOutLine[MAXLINES];

            for (int i = 0; i < this.activeLines; i++)
            {
                Person cashier = GetAvaliableCashier();
                if (cashier != null)
                {
                    linies[i] = new CheckOutLine(cashier, i + 1);
                }
            }

        }
        #endregion

        #region metodes
        private Dictionary<string, Person> LoadCustomers(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string linia;
            Dictionary<string, Person> clients = new Dictionary<string, Person>();
            linia = sr.ReadLine();

            while (linia != null)
            {
                string[] parts = linia.Split(';');
                if (parts.Length == 3)
                {
                    string id = parts[0];
                    string fullName = parts[1];
                    int? fidelityCard = null;
                    if (!string.IsNullOrWhiteSpace(parts[2]))
                        fidelityCard = Convert.ToInt32(parts[2]);
                    else
                        fidelityCard = null;

                        Customer client = new Customer(id, fullName, fidelityCard);
                    clients.Add(id, client);
                    
                }
                linia = sr.ReadLine();
            }
            sr.Close();

            return clients;
        }
        private Dictionary<string, Person> LoadCashiers(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string linia;
            Dictionary<string, Person> staff = new Dictionary<string, Person>();
            linia = sr.ReadLine();
            

            while (linia != null)
            {
                string[] parts = linia.Split(';');
                if (parts.Length >= 4)
                {
                    string nif = parts[0];
                    string fullName = parts[1];
                    DateTime joinDate = Convert.ToDateTime(parts[3]);
                    Cashier cashier = new Cashier(nif, fullName,joinDate);
                    staff.Add(nif, cashier);
                }
                linia = sr.ReadLine();
            }
            sr.Close();

            return staff;
        }
        private SortedDictionary<int, Item> LoadWarehouse(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string linia;
            SortedDictionary<int, Item> groceries = new SortedDictionary<int, Item>();
            linia= sr.ReadLine();
            int code = 1;

            while (linia != null)
            {
                string[] parts = linia.Split(';');
                if (parts.Length >= 4)
                {
                    string description = parts[0];
                    int categoriaId = Convert.ToInt32(parts[1]);
                    Item.Category category = (Item.Category)categoriaId;
                    char format = Convert.ToChar(parts[2]);
                    Item.Packaging valor = (Item.Packaging)format;

                    double price = Convert.ToDouble(parts[3]);

                    char currency = '€';
                    bool onSale = false;
                    int minStock = 10;
                    double stock = 0;

                    Item producte = new Item(category, code, currency, description, minStock, onSale, valor, price, stock);
                    groceries.Add(code,producte);
                }
                code++;
                linia = sr.ReadLine();
            }
            sr.Close();

            return groceries;
        }

        private class ComparerStock : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                int result = x.Stock.CompareTo(y.Stock);
                if (result == 0)
                {
                    result = x.Description.CompareTo(y.Description);
                }
                return result;
            }
        }


        public SortedSet<Item> GetItemsByStock()
        {
            return new SortedSet<Item>(warehouse.Values, new ComparerStock());
        }
        

        public void OpenCheckOutLine(int line2Open)
        {
            bool trobat = false;
            int i = 0;
            Person caixer = GetAvaliableCashier();
            if (line2Open <= MAXLINES && line2Open > 0)
            {
                while(!trobat)
                {
                    if (linies[line2Open-1] == linies[i] && linies[i] == null)
                    {
                        CheckOutLine liniaNova = new CheckOutLine(caixer, line2Open);
                        linies.Append(liniaNova);
                        trobat = true;
                    }
                    i++;
                }
            }

            
        }

        public CheckOutLine? GetCheckOutLine(int lineNumber)
        {
            CheckOutLine liniaRetornar;
            if (linies[lineNumber] == null || lineNumber-1 > MAXLINES || lineNumber-1 < 0)
            {
                liniaRetornar = null;
            }
            else
            {
              liniaRetornar = linies[lineNumber - 1];
            }
            return liniaRetornar;
        }

         public bool JoinTheQueue(ShoppingCart theCart, int line)
        {
            bool correcte;

            if(line < 1 || line > activeLines )
            {
                correcte = false;
            }

            CheckOutLine linia = linies[line - 1];

            if (linia == null)
            {
                correcte = false;
            }
            else
            {
                linia.CheckIn(theCart);
                correcte = true;
            }
            return correcte;

        }

        public bool CheckOut(int line)
        {
            bool fet;

            if (line < 1 || line > activeLines)
            {
                fet = false;
            }

            CheckOutLine linia = linies[line - 1];

            if (linia == null)
            {
                fet = false;
            }
            else
            {
                linia.CheckOut();
                fet = true;
            }
            return fet;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(name);
            sb.Append(address);

            foreach(CheckOutLine linies in linies)
            {
                if (linies != null)
                {
                    sb.Append($"\n{linies.ToString()}");
                }
                else
                {
                    sb.Append("\nCAIXA NO DISPONIBLE");
                }

            }

            return sb.ToString();
        }

        public Person GetAvaliableCashier()
        {
            Person p = staff.Values.FirstOrDefault(p => !p.Active );
            if(p is not null)
            {
                p.Active = true;
            }

            return p;
        }

        public Person GetAvaliableCustomer()
        {
            Person p = customers.Values.FirstOrDefault(p => !p.Active );
            if (p is not null)
            {
                p.Active = true;
            }

            return p;
        }




        public List<Item> GetProductesFaltants()
        {
            
            List<Item> productesFaltants = new List<Item>();
            Item producte;
            int i = 1;
            producte = warehouse[i];

            while(producte != null && i < warehouse.Count)
            {
               
                if (producte.Stock < producte.MinStock)
                {
                    productesFaltants.Add(producte);
                }
                i++;

                producte = warehouse[i];
            }

            return productesFaltants;

        }

        #endregion


    }
}
