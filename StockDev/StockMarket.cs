
using System.Linq;

namespace StockDev
{
    public class StockMarket
    {
        private Stock[] stocksSet;
        private StockUpdater stockUpdater;

        public StockMarket(Stock[] stocks)
        {
            stocksSet = stocks;
            stockUpdater = new StockUpdater();
        }

        public Stock[] GetAllStocks() => stocksSet;

        public void UpdateSet()
        {
            foreach (Stock s in stocksSet)
                stockUpdater.Update(s);
        }

        public bool IsValid(string shortname) => 
            stocksSet.Select(s => s.ShortName).Any(h => h == shortname);
    }
}
