using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ponomarikova.Nsudotnet.Rss2Email
{
    static class SMTPUtils
    {
        public static void Send(string server, string to, string from, string password, string subject, string body)
        {
            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
            message.Body = body;
            SmtpClient client = new SmtpClient();
            client.Host = server;
            client.Credentials = new System.Net.NetworkCredential(from, password);
            client.EnableSsl = true;

            client.Send(message);
        }
    }
}
