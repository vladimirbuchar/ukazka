using System;
using WebModel.Shared;

namespace WebModel.UserDto
{
    public class ChangePasswordDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid UserId { get; set; }
        public string OldUserPassword { get; set; }
        public string NewUserPassword { get; set; }
        public string NewUserPassword2 { get; set; }
        public string UserAccessToken { get; set; }
    }
}
