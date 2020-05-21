using EduFacade.AuthFacade.Convertor;
using EduServices.AccessTokenService;
using WebModel.UserDto;

namespace EduFacade.AuthFacade
{
    public class AuthFacade : BaseFacade, IAuthFacade
    {
        private readonly IAuthService _accessTokenService;
        private readonly IAuthConvertor _authConvertor;
        public AuthFacade(IAuthService accessTokenService, IAuthConvertor authConvertor)
        {
            _accessTokenService = accessTokenService;
            _authConvertor = authConvertor;
        }
        public GetUserByAccessTokenDto GetUserByAccessToken(string accessToken)
        {
            return _authConvertor.ConvertToWebModel(_accessTokenService.GetUserByAccessToken(accessToken));
        }
        public bool ValidateAccessToken(string accessToken)
        {
            return _accessTokenService.ValidateAccessToken(accessToken);
        }
    }
}
