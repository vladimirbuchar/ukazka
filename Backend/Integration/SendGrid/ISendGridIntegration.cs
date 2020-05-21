using Core.DataTypes;

namespace Integration.SendGrid
{
    public interface ISendGridIntegration
    {
        void SendEmail(Email mail);
    }
}
