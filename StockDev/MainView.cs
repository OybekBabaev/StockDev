using System;
using System.Linq;

namespace StockDev
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Round {0}\n**********", Program.roundCount);
            foreach (Stock s in Program.stockMarket.GetAllStocks().OrderByDescending(s => s.Price))
                s.Display();
            Console.WriteLine();
            Program.portfolio.Display();

            if (Program.portfolio.GetCurrentBalance() >= Program.stockMarket.GetAllStocks().Min(s => s.Price))
                Program.acquisitionView.Show();
            if (!Program.portfolio.IsEmpty())
                Program.releasementView.Show();
            Program.continueOrExitView.Show();

            Program.roundCount++;
            Program.stockMarket.UpdateSet();
        }
    }
}
