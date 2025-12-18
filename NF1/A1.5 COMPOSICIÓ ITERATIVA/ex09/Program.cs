namespace ex09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, cont = 0;

            Console.Write("Introdueix un numero positiu :");
            num = Convert.ToInt32(Console.ReadLine());

            while(num != 0)
            {
                cont++;
                num = num / 10;
                
            }
            Console.WriteLine($"el numero te {num}");
        }
    }
}
