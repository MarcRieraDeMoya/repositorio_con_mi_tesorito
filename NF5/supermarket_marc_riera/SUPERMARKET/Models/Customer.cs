using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUPERMARKET.Models
{
    public class Customer : Person
    {
        #region atributs
        private int? _fidelityCard;
        #endregion

        #region constructors
        public Customer(string id, string fullName, int? fidelityCard) : base(id, fullName)
        {
            _fidelityCard = fidelityCard;
        }

        public Customer(string id, string fullName) : this(id, fullName, null)
        {
            
        }
        #endregion

        #region propietats
        public override double GetRating
        {
            get
            {
                return _totalInvoiced * 0.2;
            }
        }
        #endregion

        #region metodes
        public override void AddPoints(int pointToAdd)
        {
            if (_fidelityCard != null)
            {
                _points += pointToAdd;
            }
        }
        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            return $"DNI/NIE->{_id}\tNOM->{FullName}\tRATING->{this.GetRating}\tVENDES->{_totalInvoiced}€\tPUNTS->{_points}\t" + base.ToString();
        }

        
        #endregion
    }
}
