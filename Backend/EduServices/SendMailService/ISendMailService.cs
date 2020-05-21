using Core.DataTypes;

namespace EduServices.SendMailService
{
    public interface ISendMailService
    {
        void SendMail(string emailIdentificator, string culture, EmailAddress emailAddressTo);
    }
}
