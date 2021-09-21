using System;

namespace StockDev
{
    public class ReleasementView
    {
        public void Show()
        {
            Start:
            Console.Write("Release any stocks? [Type \"yes\" to advance] ");
            string answer = Console.ReadLine();

            if (answer.ToLower().Trim() == "yes")
            {
                try
                {
                    Console.Write("Enter the indices of stocks you\'d like to release: ");
                    string stocks = Console.ReadLine();
                    string[] stockArray = stocks.Trim()
                        .Split(new char[] { ' ', ',', ';', ':', '-', '+', '.' });
                    Program.portfolio.Release(stockArray);
                }
                catch (StockNotFoundException)
                {
                    AlertMessage.Show("Stocks given by some indices weren\'t found! Try again.");
                    goto Start;
                }
                catch (StockNotYetOwnedException)
                {
                    AlertMessage.Show("Stocks given by some indices are not yet in your portfolio! Try again.");
                    goto Start;
                }
            }
        }
    }
}
