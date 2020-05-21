using System;
using WebModel.Shared;

namespace WebModel.UserDto
{
    public class UpdateUserDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid Id { get; set; }
        public PersonDto Person { get; set; }
        public string UserAccessToken { get; set; }
    }
}
