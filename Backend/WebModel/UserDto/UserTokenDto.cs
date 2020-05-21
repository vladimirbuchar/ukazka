using System;
using WebModel.Shared;

namespace WebModel.UserDto
{
    public class LoginUserDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
    }

}
