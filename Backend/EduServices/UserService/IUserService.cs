using Core.DataTypes;
using Model.Functions.User;
using Model.Tables.Edu;
using Model.Tables.Shared;
using System;
using System.Collections.Generic;

namespace EduServices.UserService
{
    public interface IUserService : IBaseService
    {
        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="user"></param>
        User AddUser(User user);

        /// <summary>
        /// update existing user
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(UpdateUser user);
        /// <summary>
        /// method for delete user
        /// </summary>
        /// <param name="userId"></param>
        void DeleteUser(Guid userId);

        /// <summary>
        /// return more information about user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetUserDetail GetUserDetail(Guid id);
        GetUserDetail GetUserDetail(string email);

        /// <summary>
        /// return information for user login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        LoginUser GetUserToken(string userEmail, string password);
        /// <summary>
        /// method for change user password
        /// </summary>
        /// <param name="changePassword"></param>
        void ChangePassword(Guid userId, string newPassword);
        void SetUserToken(Guid userOid);
        CheckUserEmailExist CheckUserEmailExist(string email);
        void ChangePasswordValidate(Guid userId, string oldPassword, Result validate);
        void SetUserToken(User user);
        void ActivateUser(User user);
        void AddUserToRole(User user, UserRole userRole);
        void ValidatePassword(string password1, string password2, Result validate);
        void ValidatePersonAddresses(List<Address> addresses, Result validate);
        void ValidateEmail(string email, Guid id, Result validate);
        List<GetUserAddress> GetUserAddresses(Guid persionId);
        void ValidatePersonName(string firstName, string lastName, Result validate);
        void AddUserByEmail(string email, UserRole userRole);

    }
}

