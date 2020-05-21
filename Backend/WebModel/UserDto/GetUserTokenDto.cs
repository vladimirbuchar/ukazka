using WebModel.Shared;

namespace WebModel.UserDto
{
    public class GetUserTokenDto : BaseDto
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
