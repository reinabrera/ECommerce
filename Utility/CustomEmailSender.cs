
using System.Net;
using System.Net.Mail;

namespace ECommerce2.Utility
{
    public class CustomEmailSender : ICustomEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            string mail = "abrerarein@gmail.com";
            string pw = "eupxzmhdtihbaelk";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw),
            };

            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(mail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(email));

            return client.SendMailAsync(mailMessage);
        }
    }
}
