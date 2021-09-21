using System;

namespace StockDev
{
    class Program
    {
        public static StockMarket stockMarket;
        public static int roundCount;
        public static Portfolio portfolio;
        public static MainView mainView;
        public static AcquisitionView acquisitionView;
        public static ReleasementView releasementView;
        public static ContinueOrExitView continueOrExitView;

        static void Main()
        {
            Console.Title = "StockDev (version 1.1.0.3)";

            var stocks = new[]
            {
                new Stock("oib", "Oibes & Co.", 133.2m),
                new Stock("bud", "Budwei\u00dfer", 19.7m),
                new Stock("rdi", "Rhodesia Decoder Integrations", 109.9m),
                new Stock("upg", "Up&Go", 22m),
                new Stock("mmw", "Mariana-Monokai-Webster", 34.8m),
                new Stock("krb", "Krasnyi Byk Ltd.", 45.2m),
                new Stock("shi", "SuperHaul Instruments", 66.7m),
                new Stock("ubm", "UBook Manufacturing & Co.", 59.9m),
                new Stock("pgq", "PregresQ LLC", 40.4m),
                new Stock("thm", "Tohmatsu Publishing", 22.1m),
                new Stock("spqr", "Structurized Preprocessed Query Researchers", 97m),
                new Stock("man", "Manchester Disunited & Partners", 88.3m)
            };

            roundCount = 1;
            stockMarket = new(stocks);            
            portfolio = new();
            acquisitionView = new();
            releasementView = new();
            continueOrExitView = new();
            mainView = new();


            RulesView rules = new();
            rules.Show();
            while (7 != 8)
                mainView.Show();
        }
    }
}
