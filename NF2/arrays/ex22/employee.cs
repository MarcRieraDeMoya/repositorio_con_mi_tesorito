using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex22
{
    internal class Employee
    {


        private const string CODI_ACCES = "1234";

        private int id;
        private string firstName;
        private string lastName;
        private double salary;
        private double commission;
        private DateTime hireDate;





        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value == null)
                    throw new Exception("S'HA D'ESCRIURE");
                this.firstName = value.ToUpper();
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value == null || value == "")
                    throw new Exception("S'HA D'ESCRIURE");
                this.lastName = value.ToUpper();
            }
        }

        public double SalariTotal
        {
            get { return this.salary; }
        }

        public double AnysTreballats
        {
            get { return (DateTime.Now - this.hireDate).TotalDays / 365.25; }
        }

        public bool TeNomGuay
        {
            get { return this.FirstName.Contains("A") && this.FirstName.Contains("E") && this.FirstName.Contains("I") && this.FirstName.Contains("O") && this.FirstName.Contains("U") || this.LastName.Contains("A") && this.LastName.Contains("E") && this.LastName.Contains("I") && this.LastName.Contains("O") && this.LastName.Contains("U"); }
        }

        public char Category
        {
            get { return SalaryToCategory(); }
        }





        /// <summary>
        /// Obtenir el cognom de l'empleat
        /// </summary>
        /// <returns>El cognom de l'empleat</returns>
        public string GetLastName()
        {
            return this.lastName;
        }

        /// <summary>
        /// Assignar un valor a la comissió
        /// </summary>
        /// <param name="value">Nou valor de comissió</param>
        public void SetCommission(double value)
        {
            this.commission = value;
        }





        public Employee(int id, string firstName, string lastName, double salary, double commission, DateTime hireDate)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
            this.commission = commission;

            if (hireDate.DayOfWeek == DayOfWeek.Saturday)
                hireDate.AddDays(2);
            else if (hireDate.DayOfWeek == DayOfWeek.Sunday)
                hireDate.AddDays(1);

            this.hireDate = hireDate;
        }

        public Employee(int id, string firstName, string lastName, double salary) : this(id, firstName, lastName, salary, 0, DateTime.Now)
        { }





        private char SalaryToCategory()
        {
            char categoria = ' ';
            if (salary < 5000) categoria = 'E';
            else if (this.salary < 10000) categoria = 'D';
            else if (this.salary < 15000) categoria = 'C';
            else if (this.salary < 20000) categoria = 'B';
            else categoria = 'A';

            return categoria;
        }

        /// <summary>
        /// Verifica que el codi d'accés es el correcte
        /// </summary>
        /// <param name="codiAcces"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public double GetSalary(string codiAcces)
        {
            if (codiAcces != CODI_ACCES)
                throw new Exception("EL CODI D'ACCÉS ÉS INCORRECTE.");

            return this.salary;
        }


        /// <summary>
        /// Converteix un empleat en format text.
        /// </summary>
        /// <returns>L'empleat en format text</returns>
        public override string ToString()
        {
            return $"{this.id};{this.firstName};{this.lastName};{this.commission};{this.hireDate}";
        }

        public double SalaryRaise(double increment)
        {
            this.salary = this.salary + increment;
            return this.salary;
        }




        public static Employee BestEmployee(Employee e1, Employee e2)
        {
            Employee winner;

            if (e1.id == e2.id) throw new Exception("ERROR: Els empleats no poden ser el mateix.");

            if (e1.Category == 'A') winner = e1;
            else if (e2.Category == 'A') winner = e2;
            if (e1.Category == 'B' && e2.Category != 'A') winner = e1;
            else winner = e2;
            if (e1.Category == 'C' && e2.Category != 'A' && e2.Category != 'B') winner = e1;
            else winner = e2;
            if (e1.Category == 'D' && e2.Category != 'A' && e2.Category != 'B' && e2.Category != 'C') winner = e1;
            else winner = e2;
            if (e1.Category == 'E' && e2.Category != 'A' && e2.Category != 'B' && e2.Category != 'C' && e2.Category != 'D') winner = e1;
            else winner = e2;

            if (e1.Category == e2.Category)
            {
                if (e1.AnysTreballats > e2.AnysTreballats) winner = e1;
                else winner = e2;
            }

            return winner;
        }

        public static double SalaryRaise(Employee e, double increment)
        {
            return e.salary + increment;
        }


    }
}
