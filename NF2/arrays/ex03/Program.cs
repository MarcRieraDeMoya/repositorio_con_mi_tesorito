namespace ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] valors = new int[5];
            MostrarTaula(valors);
        }
        
        static void MostrarTaula(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
                Console.WriteLine($"index {i}: {ints[i]}");
        }
    }
}
