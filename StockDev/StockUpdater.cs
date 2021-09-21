using System;

namespace StockDev
{
    public class StockUpdater
    {
        public void Update(Stock s)
        {
            Random gg = new();
            decimal difference = gg.Next(200) / 10m - 10m;

            decimal priorPrice = s.Price;

            s.Price += difference;
            if (s.Price <= 1)
                s.Price = 1.1m;

            s.RecentChange = s.Price - priorPrice;
        }
    }
}
