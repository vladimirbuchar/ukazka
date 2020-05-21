using WebModel.Shared;

namespace WebModel.NotificationDto
{
    public class SetIsNewNotificationToFalseDto : IBaseDtoWithUserAccessToken
    {
        public string UserAccessToken { get; set; }
    }
}
