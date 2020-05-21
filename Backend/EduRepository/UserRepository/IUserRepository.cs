using Model.Functions.User;
using System;
using System.Collections.Generic;

namespace EduRepository.UserRepository
{
    public interface IUserRepository : IBaseRepository
    {
        LoginUser GetUserToken(string email, string password);
        CheckUserEmailExist CheckUserEmailExist(string email);
        GetUserDetail GetUserDetail(Guid id);
        GetUserDetail GetUserDetail(string email);
        GetUserByAccessToken GetUserByAccessToken(string userAccessToken);
        HashSet<GetUserAddress> GetUserAddress(Guid personId);
        void UpdateUser(UpdateUser user);
    }
}
