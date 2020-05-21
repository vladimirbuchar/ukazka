using Core.DataTypes;
using System;
using WebModel.UserDto;

namespace EduFacade.UserFacade
{
    public interface IUserFacade : IBaseFacade
    {
        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="user"></param>
        Result AddUser(AddUserDto user);
        /// <summary>
        /// update existing user
        /// </summary>
        /// <param name="user"></param>
        Result UpdateUser(UpdateUserDto user);
        /// <summary>
        /// method for delete user
        /// </summary>
        /// <param name="userId"></param>
        Result DeleteUser(Guid userId);
        /// <summary>
        /// return more information about user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetUserDetailDto GetUserDetail(Guid id);
        /// <summary>
        /// return information for user login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        LoginUserDto GetUserToken(GetUserTokenDto loginData);
        /// <summary>
        /// method for change user password
        /// </summary>
        /// <param name="changePassword"></param>
        Result ChangePassword(ChangePasswordDto changePassword);
        /// <summary>
        /// validate change password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="changePassword"></param>
        /// <returns></returns>
        Result ChangeUserToken(Guid userId);
    }
}
