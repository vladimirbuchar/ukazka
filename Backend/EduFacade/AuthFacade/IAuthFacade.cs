using WebModel.UserDto;

namespace EduFacade.AuthFacade
{
    public interface IAuthFacade
    {
        /// <summary>
        /// check exist access token
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        bool ValidateAccessToken(string accessToken);
        /// <summary>
        /// find user by access token
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        GetUserByAccessTokenDto GetUserByAccessToken(string accessToken);
    }
}
