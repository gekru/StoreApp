using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Store.BusinessLogic.Helpers
{
    public class EmailHelper
    {
        private readonly IConfiguration _configuration;

        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMailAsync(string recipientMail)
        {
            // Getting section from appsetings.json
            IConfigurationSection emailSettings = _configuration.GetSection("EmailSettings");
            // Getting  value that corresponds current key
            string senderMail = emailSettings["SenderMail"];
            string senderName = emailSettings["SenderName"];
            string senderPassword = emailSettings["SenderPassword"];

            MailAddress fromMailAddress = new MailAddress(senderMail, senderName); ;
            MailAddress toMailAddress = new MailAddress(recipientMail);

            MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress)
            {
                Subject = "MailSubject",
                Body = "MailBody",
                IsBodyHtml = true
            };

            // Getting section from appsetings.json
            IConfigurationSection smtpClientSettings = _configuration.GetSection("SmtpClientSettings");

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = smtpClientSettings["Host"],
                Port = int.Parse(smtpClientSettings["Port"]),
                UseDefaultCredentials = bool.Parse(smtpClientSettings["UseDefaultCredentials"]),
                Credentials = new NetworkCredential(senderMail, senderPassword),
                EnableSsl = bool.Parse(smtpClientSettings["EnableSsl"])
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
