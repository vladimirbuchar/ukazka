using WebModel.Shared;

namespace WebModel.UserDto
{
    public class GetUserIdByEmailDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string UserEmail { get; set; }
        public string UserAccessToken { get; set; }
    }
}
