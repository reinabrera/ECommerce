
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

            string sender = Environment.GetEnvironmentVariable("BrevoSender");
            string login = Environment.GetEnvironmentVariable("BrevoLogin");
            string pw = Environment.GetEnvironmentVariable("BrevoApiKey");
            string smtpServer = Environment.GetEnvironmentVariable("BrevoSmtpServer");
            string smtpPort = Environment.GetEnvironmentVariable("BrevoSmtpPort");

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
