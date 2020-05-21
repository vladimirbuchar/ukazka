using Model.Functions.User;
using WebModel.UserDto;

namespace EduFacade.AuthFacade.Convertor
{
    public interface IAuthConvertor
    {
        GetUserByAccessTokenDto ConvertToWebModel(GetUserByAccessToken getUserByAccessToken);
    }
}
