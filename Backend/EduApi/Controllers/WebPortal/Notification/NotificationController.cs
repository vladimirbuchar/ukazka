using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation;
using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.NotificationFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.NotificationDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Answer
{

    public class NotificationController : BaseWebPortalController
    {
        private readonly INotificationFacade _notificationFacade;
        public NotificationController(INotificationFacade notificationFacade, ILogger<NotificationController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _notificationFacade = notificationFacade;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetMyNotificationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyNewNotification([FromQuery]string accessToken)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetMyNotificationOperation()),
                    ValidateAccessToken = true
                });
                return SendResponse(_notificationFacade.GetMyNotification(GetUserByAccessToken(accessToken).Id, true));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetMyNotificationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyNotification([FromQuery]string accessToken)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetMyNotificationOperation()),
                    ValidateAccessToken = true
                });
                return SendResponse(_notificationFacade.GetMyNotification(GetUserByAccessToken(accessToken).Id, false));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult SetIsNewNotificationToFalse(SetIsNewNotificationToFalseDto setIsNewNotificationToFalseDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = setIsNewNotificationToFalseDto.UserAccessToken,
                    OperationType = new OperationType(new GetMyNotificationOperation()),
                    ValidateAccessToken = true
                });
                _notificationFacade.SetIsNewNotificationToFalse(GetUserByAccessToken(setIsNewNotificationToFalseDto.UserAccessToken).Id);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }




    }
}
