
using System.Net;
using System.Net.Mail;
using dotenv.net;
namespace ECommerce2.Utility
{
    public class CustomEmailSender : ICustomEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var envVars = DotEnv.Read();

            string sender = envVars["BrevoSender"];
            string login = envVars["BrevoLogin"];
            string pw = envVars["BrevoApiKey"];

            var client = new SmtpClient(envVars["BrevoSmtpServer"], Convert.ToInt32(envVars["BrevoSmtpPort"]))
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
