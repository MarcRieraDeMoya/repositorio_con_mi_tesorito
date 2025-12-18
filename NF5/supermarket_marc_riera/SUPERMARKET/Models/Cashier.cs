using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUPERMARKET.Models
{
    public class Cashier : Person
    {
        #region atributs
        private DateTime _joiningDate;
        #endregion

        #region constructors
        public Cashier(string id, string fullName, DateTime joiningDate) : base(id, fullName)
        {
            _joiningDate = joiningDate;
        }
        #endregion

        #region propietats
        public int YearsOfService
        {
            get
            {
                DateTime now = DateTime.Now;
                int anysFeina = now.Year - _joiningDate.Year;

                if (now < _joiningDate.AddYears(anysFeina))
                {
                    anysFeina--;
                }

                return anysFeina;
            }
        }
        public override double GetRating
        {
            get
            {
                int dies = YearsOfService * 365;
                double facturat = _totalInvoiced * 0.1;

                return dies + facturat;
            }
        }
        #endregion

        #region metodes
        public override void AddPoints(int pointToAdd)
        {
            _points = (YearsOfService + 1) * pointToAdd;
        }
        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            return $"DNI/NIE->{_id}\tNOM->{FullName}\tANTIGUITAT->{this.YearsOfService}\tRATING->{this.GetRating}\tVENDES->{_totalInvoiced}€\tPUNTS->{_points}\t" + base.ToString();
        }

        #endregion
    }
}
