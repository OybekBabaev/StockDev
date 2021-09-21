
namespace StockDev
{
    public class Balance
    {
        public decimal Value { get; set; }
        public decimal RecentChange { get; set; }

        public Balance()
        {
            Value = 200m;
            RecentChange = 0m;
        }
    }
}
