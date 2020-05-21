using Core.DataTypes;
using EduFacade.UserFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebModel.Shared;
using WebModel.UserDto;

namespace EduApi.Controllers.Web.User
{
    public class UserController : BaseWebController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade, ILogger<UserController> logger) : base(logger)
        {
            _userFacade = userFacade;
        }
        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEduGit/_wiki/wikis/MyEduGit.wiki?wikiVersion=GBwikiMaster&pagePath=%2FU%C5%BEivatelsk%C3%A9%20%C3%BA%C4%8Dty%2FREST%20slu%C5%BEby%2FCreateNewUser&pageId=72
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult AddUser(AddUserDto addUserDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    TestRequest = true,
                    Request = addUserDto
                });
                return SendResponse(_userFacade.AddUser(addUserDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetUserTokenDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetUserToken([FromQuery]GetUserTokenDto getUserTokenDto)
        {
            try
            {
                return SendResponse(_userFacade.GetUserToken(getUserTokenDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
