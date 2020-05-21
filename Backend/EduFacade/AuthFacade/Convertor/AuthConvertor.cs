using Model.Functions.User;
using WebModel.UserDto;

namespace EduFacade.AuthFacade.Convertor
{
    public class AuthConvertor : IAuthConvertor
    {
        public GetUserByAccessTokenDto ConvertToWebModel(GetUserByAccessToken getUserByAccessToken)
        {
            return new GetUserByAccessTokenDto()
            {
                Id = getUserByAccessToken.Id,
                UserEmail = getUserByAccessToken.UserEmail,
            };
        }
    }
}
