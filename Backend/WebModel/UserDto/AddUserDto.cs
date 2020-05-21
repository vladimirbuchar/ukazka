using Core.Extension;
using WebModel.Shared;

namespace WebModel.UserDto
{
    public class AddUserDto : BaseDto, IBaseDtoWithClientCulture
    {
        private string hashPassword;
        private string hashPassword2;
        public string UserPassword
        {
            get => hashPassword;
            set => hashPassword = value.GetHashString();
        }
        public string UserPassword2
        {
            get => hashPassword2;
            set => hashPassword2 = value.GetHashString();
        }
        public string UserEmail { get; set; }
        public PersonDto Person { get; set; } = new PersonDto();
        public string ClientCulture { get; set; }
    }
}
