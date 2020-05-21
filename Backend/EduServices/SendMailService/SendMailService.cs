using Core.DataTypes;
using EduRepository.EmailRepository;
using Integration.SendGrid;
using Model.Tables.Edu;

namespace EduServices.SendMailService
{
    public class SendMailService : BaseService, ISendMailService
    {
        private readonly ISendGridIntegration _sendGridIntegration;
        private readonly IEmailRepository _emailRepository;
        public SendMailService(ISendGridIntegration sendGridIntegration, IEmailRepository emailRepository)
        {
            _sendGridIntegration = sendGridIntegration;
            _emailRepository = emailRepository;
        }

        public void SendMail(string emailIdentificator, string culture, EmailAddress emailAddressTo)
        {
            EduEmail eduEmail = _emailRepository.GetEntity<EduEmail>(string.Format("{0}_{1}", emailIdentificator, culture));
            if (eduEmail != null)
            {
                _sendGridIntegration.SendEmail(new Email()
                {
                    EmailBody = new EmailBody()
                    {
                        HtmlBody = eduEmail.EmailBodyHtml,
                        IsHtml = eduEmail.IsHtml,
                        PlainTextBody = eduEmail.EmailBodyPlainText
                    },
                    To = emailAddressTo,
                    From = new EmailAddress()
                    {
                        Email = eduEmail.From,
                        Name = eduEmail.From
                    },
                    Subject = eduEmail.Subject
                });
            }
        }
    }
}
