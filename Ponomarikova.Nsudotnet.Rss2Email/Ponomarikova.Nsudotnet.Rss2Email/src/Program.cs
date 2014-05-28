using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponomarikova.Nsudotnet.Rss2Email
{
    class Program
    {
        //program.exe url.com/news.rss mailserver.com to@mail.com from@mail.com password
        static void Main(string[] args)
        {
            if (args.Length < 5)
            {
                PrintLine("Wrong arguments");
                return;
            }

            string body = XMLUtils.GetTextFromXML(args[0]);
            SMTPUtils.Send(args[1], args[2], args[3], args[4], args[0], body);
        }

        private static void PrintLine(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message);
#endif
            Console.WriteLine(message);
        }
    }
}
