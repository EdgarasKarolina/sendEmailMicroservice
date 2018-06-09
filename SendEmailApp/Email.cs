using System;
using System.Net.Mail;

namespace SendEmailApp
{
    class Email
    {
        public static void sendEmail(string emailBody, string receiver)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("attendancesystemkea@gmail.com");
                mail.To.Add(receiver);
                mail.Subject = "Test Mail";
                mail.Body = emailBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("attendancesystemkea", "DonaldTrump_69");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
