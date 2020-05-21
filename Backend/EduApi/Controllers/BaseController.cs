using Core.DataTypes;
using Core.Exceptions;
using EduCore.DataTypes;
using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebModel.Shared;
using WebModel.UserDto;

namespace EduApi.Controllers
{
    [EnableCors("AllowAll")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IAuthFacade _accessTokenFacade;
        private readonly IOrganizationRoleFacade _organizationRoleFacade;
        private readonly ILicenseFacade _licenseFacade;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        public BaseController(ILogger<BaseController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade)
        {
            _logger = logger;
            _accessTokenFacade = accessTokenFacade;
            _organizationRoleFacade = organizationRoleFacade;
            _licenseFacade = licenseFacade;
        }

        /// <summary>
        /// write data to log 
        /// </summary>
        /// <param name="apiIdentificator"></param>
        /// <param name="validate"></param>
        private void LogValidate (Result validate)
        {
            if (validate.IsError)
            {
                _logger.LogError("Validation error", validate.Errors);
            }
            if (validate.IsWarning)
            {
                _logger.LogWarning("Validation warning", validate.Warning);
            }
        }

        /// <summary>
        /// send system error
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected ActionResult SendSystemError(Exception ex)
        {
            Result validation = new Result();
            if (ex is BadAccessTokenException)
            {
                validation.AddResultStatus(new ValidationMessage(MessageType.ERROR, "BAD_ACCESS_TOKEN"));
            }
            else if (ex is PermitionDeniedException)
            {
                validation.AddResultStatus(new ValidationMessage(MessageType.ERROR, "PERMITION_DENIED"));
            }
            else if (ex is RequestIsNullException)
            {
                validation.AddResultStatus(new ValidationMessage(MessageType.ERROR, "REQUEST_IS_NULL"));
            }
            else if (ex is LicenseException)
            {
                validation.AddResultStatus(new ValidationMessage(MessageType.ERROR, "BAD_LICENSE"));
            }
            else if (ex is UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            if (validation.IsError)
            {
                return SendResponse(validation);
            }
            _logger.LogCritical("system expetion", ex);
            return StatusCode(500, new SystemError("system exception"));
        }

        /// <summary>
        /// send response
        /// </summary>
        /// <returns></returns>
        protected ActionResult SendResponse()
        {
            return SendResponse(new Result());
        }

        /// <summary>
        /// send response with result
        /// </summary>
        /// <param name="validation"></param>
        /// <returns></returns>
        protected ActionResult SendResponse(Result response)
        {
            LogValidate(response);
            if (response.IsError && (response.Contains(new ValidationMessage(MessageType.ERROR, "BAD_ACCESS_TOKEN")) || response.Contains(new ValidationMessage(MessageType.ERROR, "PERMITION_DENIED"))))
            {
                return StatusCode(403);
            }
            else if (response.IsError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// send response 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        protected ActionResult SendResponse<T>(T response)
        {
            if (response == null)
            {
                return NotFound();
            }
            return Ok(new Result<T>()
            {
                Data = response
            });
        }

        /// <summary>
        /// check when is not request null
        /// </summary>
        /// <param name="request"></param>
        protected void TestRequest(BaseDto request)
        {
            if (request == null)
            {
                throw new RequestIsNullException();
            }
        }

        /// <summary>
        /// does test 
        /// </summary>
        /// <param name="testRequestSettings"></param>
        protected void Test(TestRequestSettings testRequestSettings)
        {
            if (testRequestSettings.TestRequest)
            {
                TestRequest(testRequestSettings.Request);
            }
            if (testRequestSettings.ValidateAccessToken)
            {
                ValidateAccessToken(testRequestSettings.AccessToken);
            }
            if (testRequestSettings.OrganizationId != Guid.Empty && testRequestSettings.OperationType != null)
            {
                CheckPermition(testRequestSettings.AccessToken, testRequestSettings.OrganizationId, testRequestSettings.OperationType);
            }
            if (testRequestSettings.ValidateLicense)
            {
                ValidateLicense(testRequestSettings.OrganizationId, testRequestSettings.OperationType.SelectOperation);
            }
            if (testRequestSettings.ValidateByUserId && GetUserByAccessToken(testRequestSettings.AccessToken)?.Id != testRequestSettings.UserId)
            {
                throw new PermitionDeniedException();
            }
            if (testRequestSettings.ValidateByUserEmail && GetUserByAccessToken(testRequestSettings.AccessToken)?.UserEmail != testRequestSettings.UserEmail)
            {
                throw new PermitionDeniedException();
            }
        }

        /// <summary>
        /// validte organization license
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="operationType"></param>
        protected void ValidateLicense(Guid organizationId, BaseOperation operationType)
        {
            if (!_licenseFacade.ValidateLicence(organizationId, operationType))
            {
                throw new LicenseException();
            }
        }

        /// <summary>
        /// validate user acess token
        /// </summary>
        /// <param name="accessToken"></param>
        private void ValidateAccessToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new UnauthorizedAccessException();
            }
            if (_accessTokenFacade != null && !_accessTokenFacade.ValidateAccessToken(accessToken))
            {
                throw new BadAccessTokenException();
            }
        }

        /// <summary>
        /// check user permition in organization
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organizationId"></param>
        /// <param name="operationType"></param>
        private void CheckPermition(string accessToken, Guid organizationId, OperationType operationType)
        {
            if (_organizationRoleFacade != null && !_organizationRoleFacade.CheckPermition(GetUserByAccessToken(accessToken).Id, organizationId, operationType))
            {
                throw new PermitionDeniedException();
            }
        }
        /// <summary>
        /// find user by acess token
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        protected GetUserByAccessTokenDto GetUserByAccessToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new UnauthorizedAccessException();
            }
            if (_accessTokenFacade != null)
            {
                return _accessTokenFacade.GetUserByAccessToken(accessToken);
            }
            return null;
        }
    }
}