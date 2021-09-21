using System;
using System.Threading;

namespace StockDev
{
    public class ContinueOrExitView
    {
        public void Show()
        {
            Console.Write("Advance to next round? [Type \"no\" to KILL game] ");
            string answer = Console.ReadLine();

            Console.WriteLine();

            if (answer.ToLower().Trim() == "no")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Exiting the program in 3...");
                Thread.Sleep(850);
                Console.Write(" 2...");
                Thread.Sleep(850);
                Console.Write(" 1...");
                Thread.Sleep(850);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(".");
                Thread.Sleep(230);
                Console.WriteLine("..");
                Thread.Sleep(230);
                Console.WriteLine("...");
                Thread.Sleep(230);
                Console.WriteLine();
            }
        }
    }
}
