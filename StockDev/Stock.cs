using System;

namespace StockDev
{
    public class Stock
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public decimal Price { get; set; }
        public decimal RecentChange { get; set; }

        public Stock(string shorter, string full, decimal price)
        {
            FullName = full;
            ShortName = shorter;
            Price = price;
            RecentChange = 0m;
        }

        public void Display()
        {
            string priceFormatted = Price.ToString("C1");
            string recentChangeFormatted;

            if (RecentChange > 0)
                recentChangeFormatted = "+" + RecentChange;
            else
                recentChangeFormatted = RecentChange.ToString();

            Console.WriteLine(">> {0} - {1} - {2} ({3})",
                ShortName, FullName, priceFormatted, recentChangeFormatted);
        }
    }
}
