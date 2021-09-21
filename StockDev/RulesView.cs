using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StockDev
{
    public class RulesView
    {
        public void Show()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("*", 33)));

            string welcome = "Welcome to StockDev - the non-commercial stock market simulator!\n";
            Console.WriteLine(welcome);

            string theGoal = ">>> Consider you became a trader. You have $200 on your account balance" +
                " at the start of the game. You plan to increase that" + " as much as possible by" +
                " trading the stocks of companies listed on the stock market.\n";
            DisplayWrappedText(WordWrap(theGoal, 114));

            string everyRound = ">>> Every round is initiated by displaying a listing of all stocks " +
                "available on the market. Each one has got its full name, shorter index and price, " +
                "depicted with how it has changed compared to previous round. Right below that " +
                "you will see the list of stocks currently included in your portfolio and your " +
                "current account balance.\n";
            DisplayWrappedText(WordWrap(everyRound, 114));

            string acquire = ">>> The first question you will encounter is whether you want to acquire " +
                "any stocks during a particular round. By the way, this will not be shown if you " +
                "have less money on your account than what is required to buy the least expensive " +
                "stock. It looks like this:\n\n" +
                "Acquire any stocks? [Type \"yes\" to advance] \n\n" +
                "If the phrase you typed is exactly \"yes\", then the acquisition either proceeds " +
                "or will be interrupted by quite a self-describing warning; otherwise, the next " +
                "question in-order is to be displayed.\n";
            DisplayWrappedText(WordWrap(acquire, 114));

            string release = ">>> Another question is whether you would like to release any stocks " +
                "during a particular round. That\'s how it looks:\n\n" +
                "Release any stocks? [Type \"yes\" to advance] \n\n" +
                "If the phrase you typed is exactly \"yes\", then the releasement either proceeds " +
                "or will be interrupted by an undoubtedly understandable warning; otherwise, the next " +
                "question in-order is to be displayed.\n";
            DisplayWrappedText(WordWrap(release, 114));

            string continueExit = ">>> Lastly, every round has this question enclosed:\n\n" +
                "Advance to next round? [Type \"no\" to KILL game] \n\n" +
                "If the phrase you typed is exactly \"no\", then the game is over and the app " +
                "will self-exit; otherwise, the game is to be continued with the next round " +
                "forthcoming as usually.\n";
            DisplayWrappedText(WordWrap(continueExit, 114));

            Console.WriteLine("[Press ENTER to continue...]");
            if (Regex.IsMatch(Console.ReadLine(), @"\.*"))
            {
                Console.WriteLine(Environment.NewLine);
                System.Threading.Thread.Sleep(800);
            }            
        }

        IEnumerable<string> WordWrap(string text, int width)
        {
            const string forcedBreakZonePattern = @"\n";
            const string normalBreakZonePattern = @"\s+|(?<=[-,.;])|$";

            var forcedZones = Regex.Matches(text, forcedBreakZonePattern).Cast<Match>().ToList();
            var normalZones = Regex.Matches(text, normalBreakZonePattern).Cast<Match>().ToList();

            int start = 0;

            while (start < text.Length)
            {
                var zone =
                    forcedZones.Find(z => z.Index >= start && z.Index <= start + width) ??
                    normalZones.FindLast(z => z.Index >= start && z.Index <= start + width);

                if (zone == null)
                {
                    yield return text.Substring(start, width);
                    start += width;
                }
                else
                {
                    yield return text.Substring(start, zone.Index - start);
                    start = zone.Index + zone.Length;
                }
            }
        }

        void DisplayWrappedText(IEnumerable<string> text)
        {
            foreach (var s in text)
                Console.WriteLine(s);

            Console.WriteLine();
        }
    }
}
