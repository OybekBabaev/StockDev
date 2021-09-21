using System.Collections.Generic;
using System.Linq;
using System;

namespace StockDev
{
    public class Portfolio
    {
        private List<Stock> stocksList;
        private Balance balance;
        public bool AcquiredAnything = false;

        public Portfolio()
        {
            stocksList = new List<Stock>();
            balance = new Balance();
        }

        public void Acquire(params string[] toAcquire)
        {
            toAcquire = toAcquire.Select(s => s.ToLower()).ToArray();

            bool areStocksValid = toAcquire.All(ind => Program.stockMarket.IsValid(ind));

            if (!areStocksValid)
                throw new StockNotFoundException();

            var stockQuery = Program.stockMarket.GetAllStocks()
                .Where(s => toAcquire.Contains(s.ShortName));
            bool areStocksOwnedAlready = stocksList.Intersect(stockQuery).Any();                        

            if (areStocksOwnedAlready)
                throw new StockOwnedAlreadyException();

            
            var totalCost = stockQuery.Sum(s => s.Price);
            if (balance.Value < totalCost)
                throw new CannotAffordException();

            stocksList = stocksList.Concat(stockQuery).ToList();
            var priorBalanceValue = balance.Value;
            balance.Value -= totalCost;
            balance.RecentChange = balance.Value - priorBalanceValue;
        }

        public void Release(params string[] toRelease)
        {
            bool areStocksValid = toRelease.Length ==
                toRelease.Intersect(Program.stockMarket.GetAllStocks().Select(s => s.ShortName)).Count();

            bool areStocksOwnedAlready =
                toRelease.Intersect(stocksList.Select(s => s.ShortName)).Any();

            if (!areStocksValid)
                throw new StockNotFoundException();

            if (!areStocksOwnedAlready)
                throw new StockNotYetOwnedException();

            var stockQuery = Program.stockMarket.GetAllStocks()
                .Where(s => toRelease.Contains(s.ShortName));
            var totalCost = stockQuery.Sum(s => s.Price);

            stocksList = stocksList.Except(stockQuery).ToList();
            var priorBalanceValue = balance.Value;
            balance.Value += totalCost;
            var currentDifference = balance.Value - priorBalanceValue;
            if (!AcquiredAnything)
                balance.RecentChange = currentDifference;
            else
                balance.RecentChange += currentDifference;
        }

        public void Display()
        {
            string stocksIndices = "";
            if (stocksList.Any())
            {
                foreach (Stock s in stocksList)
                    stocksIndices += string.Format("{0}, ", s.ShortName.ToUpper());
                stocksIndices = stocksIndices[..^2];
            }
            else
                stocksIndices = "-";

            string balanceFormatted = balance.Value.ToString("C1");
            string balanceRecentChangeFormatted = "-";

            if (balance.RecentChange > 0)
                balanceRecentChangeFormatted = "+" + balance.RecentChange;
            else
                balanceRecentChangeFormatted = balance.RecentChange.ToString();

            Console.WriteLine("Stocks in portfolio: {0}\nBalance: {1} ({2})",
                stocksIndices, balanceFormatted, balanceRecentChangeFormatted);
        }

        public bool IsEmpty() => !stocksList.Any();

        public decimal GetCurrentBalance() => balance.Value;
    }
}
