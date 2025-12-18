namespace ex01
{
    internal class Empleat
    {
        //atributs
        private const string CODI_ACCES = "1234";
        private int id;
        private string firstName;
        private string lastName;
        private double salary;
        private double commission;
        private DateTime hireDate;

        //metodes
        //constructor
        public Empleat()
        {
            id = 0;
            salary = 0;
            commission = 0;
        }

        public Empleat(string firstName, string lastName, double salary) : this()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
        }

        public EmpleatComplet(int id, string firstName, string last, double sal, double com, DateTime date) : this(firstName, last, sal)
        {
            this.id = id;
            commission = com;
            hireDate = date;
        }
    }


}
