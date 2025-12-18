using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUPERMARKET.Models
{
    public abstract class Person: IComparable<Person>
    {
        #region atrivuts
        protected string _id;
        private string _fullName;
        protected int _points;
        protected double _totalInvoiced;
        protected bool active;
        #endregion      

        #region constructors
        public Person(string id, string fullName, int points)
        {
            _id = id;
            _fullName = fullName;
            _points = points;
            _totalInvoiced = 0;
            active = false;
        }
        public Person(string id, string fullName) : this(id, fullName, 0)
        {
            _points = 0;
            _totalInvoiced = 0;
            active = false;
        }
        #endregion

        #region propietats 
        public string FullName { get => _fullName; }
        public bool Active { get => active; set => active = value; }
        public abstract double GetRating { get; }
        #endregion

        #region metodes
        public void AddInvoiceAmount(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("VALOR INVALID");
            } 

            _totalInvoiced += amount;
        }

        public override string ToString()
        {
            string missatge;
            if (active)
            {
                missatge = "DISPONIBLE->S";
            }
            else
            {
                missatge = "DISPONIBLE->N";
            }

            return missatge;
        }
        
        public int CompareTo(Person? other)
        {
            if (other == null)
            {
                return 1;
            }

            return other.GetRating.CompareTo(this.GetRating);
        }
        public abstract void AddPoints(int pointToAdd);
        #endregion
    }
}
