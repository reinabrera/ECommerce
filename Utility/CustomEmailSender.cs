
using System.Net;
using System.Net.Mail;
using dotenv.net;
namespace ECommerce2.Utility
{
    public class CustomEmailSender : ICustomEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            DotEnv.Load();

            string smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER");
            string smtpPort = Environment.GetEnvironmentVariable("SMTP_PORT");
            string login = Environment.GetEnvironmentVariable("SMTP_LOGIN");
            string pw = Environment.GetEnvironmentVariable("SMTP_KEY");
            string sender = Environment.GetEnvironmentVariable("SMTP_SENDER");

            var client = new SmtpClient(smtpServer, Convert.ToInt32(smtpPort))
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(login, pw),
            };

            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(sender),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(email));

            return client.SendMailAsync(mailMessage);
        }
    }
}
