using Model.Functions.User;

namespace EduServices.AccessTokenService
{
    public interface IAuthService : IBaseService
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
        GetUserByAccessToken GetUserByAccessToken(string accessToken);
    }
}
