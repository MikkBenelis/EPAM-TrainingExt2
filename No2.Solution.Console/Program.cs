﻿namespace No2.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock();

            var bank = new Bank("Bank", stock);
            var broker = new Broker("Broker", stock);

            stock.Register(bank);
            stock.Register(broker);
            stock.Market();

            System.Console.ReadLine();
        }
    }
}
