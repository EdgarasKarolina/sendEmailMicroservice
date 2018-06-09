using System;
using System.Linq;

namespace SendEmailApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string emailBody = QueueListener.ReadNextMessageQueue2();
            Console.WriteLine(emailBody);
            string emailAddress = emailBody.Split(new[] { '\r', '\n' }).FirstOrDefault();
            Console.WriteLine(emailAddress);

            Email.sendEmail(emailBody, emailAddress);
        }
    }
}
