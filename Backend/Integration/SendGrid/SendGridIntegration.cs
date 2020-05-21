using Core.DataTypes;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using EmailAddress = SendGrid.Helpers.Mail.EmailAddress;

namespace Integration.SendGrid
{
    public class SendGridIntegration : ISendGridIntegration
    {
        private readonly IConfiguration _configuration;
        public SendGridIntegration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async void SendEmail(Email mail)
        {
            string apiKey = _configuration.GetSection("SendGrid")?.GetSection("ApiKey")?.Value;
            if (apiKey != null)
            {
                SendGridClient client = new SendGridClient(apiKey);
                EmailAddress from = new EmailAddress(mail.From.Email, mail.From.Name);
                EmailAddress to = new EmailAddress(mail.To.Email, mail.To.Name);
                string plainTextContent = mail.EmailBody.PlainTextBody;
                string htmlContent = mail.EmailBody.HtmlBody;
                SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, mail.Subject, plainTextContent, htmlContent);
                await client.SendEmailAsync(msg);
            }
        }
    }
}
