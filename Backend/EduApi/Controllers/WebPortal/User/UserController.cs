using Core.DataTypes;
using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using EduFacade.UserFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebModel.Shared;
using WebModel.UserDto;

namespace EduApi.Controllers.WebPortal.User
{
    public class UserController : BaseWebPortalController
    {
        private readonly IUserFacade _userFacade;
        public UserController(ILogger<UserController> logger, IUserFacade userFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _userFacade = userFacade;
        }

        /// <summary>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetUserDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetUserDetail([FromQuery]string accessToken, [FromQuery]Guid userId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateByUserId = true,
                    UserId = userId,
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                });
                return SendResponse(_userFacade.GetUserDetail(userId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateByUserId = true,
                    UserId = changePasswordDto.UserId,
                    TestRequest = true,
                    Request = changePasswordDto,
                    AccessToken = changePasswordDto.UserAccessToken,
                    ValidateAccessToken = true,
                });
                return SendResponse(_userFacade.ChangePassword(changePasswordDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ChangeUserToken(string accessToken, Guid userId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateByUserId = true,
                    UserId = userId,
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                });
                return SendResponse(_userFacade.ChangeUserToken(userId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateUser(UpdateUserDto updateUserDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateByUserId = true,
                    UserId = updateUserDto.Id,
                    TestRequest = true,
                    Request = updateUserDto,
                    AccessToken = updateUserDto.UserAccessToken,
                    ValidateAccessToken = true,
                });
                return SendResponse(_userFacade.UpdateUser(updateUserDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult DeleteUser(string accessToken, Guid userId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateByUserId = true,
                    UserId = userId,
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                });
                return SendResponse(_userFacade.DeleteUser(userId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
