using System;

namespace WebModel.UserDto
{
    public class GetUserByAccessTokenDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string UserToken { get; set; }
    }
}
