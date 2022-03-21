using System;
using System.Collections.Generic;
using TradesPortfolio.Controllers;

namespace TradesPortfolio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine();

            bool keepEvaluating = true;

            while (keepEvaluating)
            {
                keepEvaluating = showProgram();
                Console.WriteLine('\n');
            }
        }

        private static bool showProgram()
        {
            var tradeController = new TradeController();

            Console.WriteLine("Inform the reference date. (Format: MM/DD/YYYY)");
            var referenceDate = Console.ReadLine();

            Console.WriteLine("Inform the number of trades in the portfolio.");
            int.TryParse(Console.ReadLine(), out int numTrades);

            Console.WriteLine("Inform the trades. One trade per line and press the key ENTER. (Format: VALUE CLIENT_SECTOR NEXT_PAYMENT_DATE)");
            var trades = new List<string>();
            for (int i = 0; i < numTrades; i++)
            {
                var line = Console.ReadLine();
                trades.Add(line);
            }

            var results = tradeController.EvaluateCategory(referenceDate, numTrades, trades);
            Console.WriteLine();
            Console.WriteLine("Results");
            Console.WriteLine();

            if (results == null || results.Count == 0)
            {
                Console.WriteLine("No results available");
            }
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Do you want to continue? Y to YES and N to NO.");
            return Console.ReadKey().KeyChar.ToString().ToUpper() == "Y";
        }
    }
}
