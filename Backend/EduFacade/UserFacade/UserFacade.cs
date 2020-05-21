using Core.DataTypes;
using EduFacade.UserFacade.Convertors;
using EduServices.RoleService;
using EduServices.SendMailService;
using EduServices.UserService;
using Model.Functions.User;
using Model.Tables.Edu;
using Model.Tables.Shared;
using System;
using System.Collections.Generic;
using WebModel.Shared;
using WebModel.UserDto;

namespace EduFacade.UserFacade
{
    public class UserFacade : BaseFacade, IUserFacade
    {
        private readonly IUserService _userService;
        private readonly IUserConvertor _userConvertor;
        private readonly IRoleService _roleService;
        private readonly ISendMailService _sendMailService;
        private readonly IAddressConvertor _addressConvertor;

        public UserFacade(IUserService userService, IRoleService roleService, ISendMailService sendMailService, IUserConvertor userConvertor, IAddressConvertor addressConvertor)
        {
            _userService = userService;
            _roleService = roleService;
            _sendMailService = sendMailService;
            _userConvertor = userConvertor;
            _addressConvertor = addressConvertor;
        }

        public Result AddUser(AddUserDto userCreateDto)
        {
            Result validate = ValidateUser(userCreateDto);
            if (validate.IsOk)
            {
                User user = _userConvertor.ConvertToBussinessEntity(userCreateDto);
                user.UserRole = _roleService.GetUserRole(UserRoleValues.REGISTERED_USER);
                _userService.AddUser(user);
                _sendMailService.SendMail(EduEmailValue.REGISTRATION_USER, userCreateDto.ClientCulture, new EmailAddress()
                {
                    Email = userCreateDto.UserEmail,
                    Name = userCreateDto.Person.FullName
                });
            }
            return validate;
        }
        private void ValidatePersonAddress(List<AddressDto> addressesDto, Result validate)
        {
            List<Address> addresses = new List<Address>();
            foreach (AddressDto item in addressesDto)
            {
                addresses.Add(_addressConvertor.ConvertToBussinessEntity(item));
            }
            _userService.ValidatePersonAddresses(addresses, validate);
        }
        private Result ValidateUser(UpdateUserDto userCreateDto)
        {
            Result validate = new Result();
            ValidatePersonAddress(userCreateDto.Person.Address, validate);
            return validate;
        }
        private Result ValidateUser(AddUserDto userCreateDto)
        {
            Result validate = new Result();
            _userService.ValidateEmail(userCreateDto.UserEmail, Guid.Empty, validate);
            _userService.ValidatePassword(userCreateDto.UserPassword, userCreateDto.UserPassword2, validate);
            ValidatePersonAddress(userCreateDto.Person.Address, validate);
            _userService.ValidatePersonName(userCreateDto.Person.FirstName, userCreateDto.Person.LastName, validate);
            return validate;
        }

        public Result ChangePassword(ChangePasswordDto changePassword)
        {
            Result validate = ChangePasswordValidate(changePassword);
            if (validate.IsOk)
            {
                _userService.ChangePassword(changePassword.UserId, changePassword.NewUserPassword);
            }
            return validate;
        }
        private Result ChangePasswordValidate(ChangePasswordDto changePassword)
        {
            Result validate = new Result();
            _userService.ChangePasswordValidate(changePassword.UserId, changePassword.OldUserPassword, validate);
            _userService.ValidatePassword(changePassword.NewUserPassword, changePassword.NewUserPassword2, validate);
            return validate;
        }

        public Result ChangeUserToken(Guid userId)
        {
            _userService.SetUserToken(userId);
            return new Result();
        }

        public Result DeleteUser(Guid userId)
        {
            _userService.DeleteUser(userId);
            return new Result();
        }

        public GetUserDetailDto GetUserDetail(Guid id)
        {
            GetUserDetail userDetail = _userService.GetUserDetail(id);
            List<GetUserAddress> getUserAddress = _userService.GetUserAddresses(userDetail.PersonId);
            return _userConvertor.ConvertToWebModel(userDetail, getUserAddress);
        }

        public LoginUserDto GetUserToken(GetUserTokenDto loginData)
        {
            LoginUser loginUser = _userService.GetUserToken(loginData.UserEmail, loginData.UserPassword);
            if (loginUser != null)
            {
                return _userConvertor.ConvertToWebModel(loginUser);
            }
            return null;
        }
        public Result UpdateUser(UpdateUserDto userUpdateDto)
        {
            Result result = ValidateUser(userUpdateDto);
            if (result.IsOk)
            {
                UpdateUser user = _userConvertor.ConvertToBussinessEntity(userUpdateDto);
                _userService.UpdateUser(user);
            }
            return result;
        }
    }
}
