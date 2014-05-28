using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponomarikova.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                PrintLine("Wrong arguments");
                return;
            }

            int count = LinesCounter.GetLinesCount(dir, args[0]);

            PrintLine(count.ToString());
        }

        private static void PrintLine(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message);
#endif
            Console.WriteLine(message);
        }

        private static string dir = ".";
    }
}
