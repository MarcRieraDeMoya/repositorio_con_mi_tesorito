namespace ex11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, suma, resta, multipicacio, divisio;
            Random rand = new Random();

            num1 = rand.Next(1, 101);
            num2 = rand.Next(1, 101);

            Console.Write("Quin es el resultat de la suma: ");
            suma = Convert.ToInt32(Console.ReadLine());
            if (suma == (num1+num2))
            {
                Console.Write("Quin es el resultat de la resta: ");
            }
        }
    }
}
