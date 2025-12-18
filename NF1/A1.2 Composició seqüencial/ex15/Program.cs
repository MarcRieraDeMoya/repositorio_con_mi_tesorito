internal class Program
    {
        static void Main(string[] args)
        {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        // Declaració de variables

        double valorCompra;
        int billets100;
        int billets50;
        int billets20;
        int billets10;
        int billets5;
        int monedes02;
        int monedes01;
        int monedes50;
        int monedes20;
        int monedes10;
        int monedes5;
        int monedes2;
        int monedes1;
        double conversormonedes50;
        double conversormonedes20;
        double conversormonedes10;
        double conversormonedes5;
        double conversormonedes2;
        double conversormonedes1;

        // Valors de entrada

        Console.Write("INTRODUIR VALOR TOTAL DE LA COMPRA --> ");
        valorCompra = Convert.ToDouble(Console.ReadLine());

        // Algorismes /calculs

        billets100 = (int) valorCompra / 100;
        billets50 = (int) valorCompra % 100 / 50;
        billets20 = (int) valorCompra % 100 % 50 / 20;
        billets10 = (int) valorCompra % 100 % 50 % 20 / 10;
        billets5 = (int) valorCompra % 100 % 50 % 20 % 10 / 5;
        monedes02 = (int) valorCompra % 100 % 50 % 20 % 10 % 5 / 2;
        monedes01 = (int) valorCompra % 100 % 50 % 20 % 10 % 5 % 2 / 1;
        conversormonedes50 = valorCompra % 100 % 50 % 20 % 10 % 5 % 2 % 1 / 0.50;
        conversormonedes20 = valorCompra % 100 % 50 % 20 % 10 % 5 % 2 % 1 % 0.50 / 0.20;
        conversormonedes10 = valorCompra % 100 % 50 % 20 % 10 % 5 % 2 % 1 % 0.50 % 0.20 / 0.10;
        conversormonedes5 = valorCompra % 100 % 50 % 20 % 10 % 5 % 2 % 1 % 0.50 % 0.20 % 0.10 / 0.05;
        conversormonedes2 = valorCompra % 100 % 50 % 20 % 10 % 5 % 2 % 1 % 0.50 % 0.20 % 0.10 % 0.05 / 0.02;
        conversormonedes1 = valorCompra % 100 % 50 % 20 % 10 % 5 % 2 % 1 % 0.50 % 0.20 % 0.10 % 0.05 % 0.02 / 0.01;
        monedes50 = (int)conversormonedes50;
        monedes20 = (int)conversormonedes20;
        monedes10 = (int)conversormonedes10;
        monedes5 = (int)conversormonedes5;
        monedes2 = (int)conversormonedes2;
        monedes1 = (int)conversormonedes1;

        // Valors de sortida

        Console.WriteLine($"EL VALOR DEL CANVI SERA DE {billets100} BILLETS DE 100€, {billets50} BILLETS DE 50€, {billets20} BILLETS DE 20€, {billets10} BILLETS DE 10€, {billets5} BILLETS DE 5€ ");
        Console.WriteLine($"{monedes02} MONEDES DE 2€, {monedes01} MONEDES DE 1€, {monedes50} MONEDES DE 50 CÈNTIMS, {monedes20} MONEDES DE 20 CÈNTIMS");
        Console.WriteLine($"{monedes10} MONEDES DE 10 CÈNTIMS, {monedes5} MONEDES DE 5 CÈNTIMS, {monedes2} MONEDES DE 2 CÈNTIMS, {monedes1} MONEDES DE 1 CÈNTIM");
        }
    }

