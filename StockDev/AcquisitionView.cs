using System;
using System.Linq;

namespace StockDev
{
    public class AcquisitionView
    {
        public void Show()
        {
            Start :
            Console.Write("Acquire any stocks? [Type \"yes\" to advance] ");
            string answer = Console.ReadLine();

            if (answer.ToLower().Trim() == "yes")
            {
                try
                {
                    Console.Write("Enter the indices of stocks you\'d like to acquire: ");
                    string stocks = Console.ReadLine();
                    string[] stockArray = stocks.ToLower().Trim()
                        .Split(new char[] { ' ', ',', ';', ':', '-', '+', '.' });
                    Program.portfolio.Acquire(stockArray);
                    Program.portfolio.AcquiredAnything = true;
                }
                catch (StockNotFoundException)
                {
                    AlertMessage.Show("Stocks given by some indices weren\'t found! Try again.");
                    goto Start;
                }
                catch (StockOwnedAlreadyException)
                {
                    AlertMessage.Show("Stocks given by some indices are in your portfolio already! Try again.");
                    goto Start;
                }
                catch (CannotAffordException)
                {
                    AlertMessage.Show("You cannot afford all these stocks! Try again.");
                    goto Start;
                }
            }
            else
                Program.portfolio.AcquiredAnything = false;
        }
    }
}
