using EduRepository.UserRepository;
using Model.Functions.User;

namespace EduServices.AccessTokenService
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateAccessToken(string accessToken)
        {
            return _userRepository.GetUserByAccessToken(accessToken) != null;
        }
        public GetUserByAccessToken GetUserByAccessToken(string accessToken)
        {
            return _userRepository.GetUserByAccessToken(accessToken);
        }
    }
}
