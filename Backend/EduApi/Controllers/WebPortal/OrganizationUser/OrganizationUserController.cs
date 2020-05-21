using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.UserInOrganization;
using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using EduFacade.OrganizationFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.OrganizationDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.OrganizationUser
{
    public class OrganizationUserController : BaseWebPortalController
    {
        private readonly IOrganizationFacade _organizationFacade;
        private readonly IOrganizationRoleFacade _organizationRoleFacade;
        public OrganizationUserController(ILogger<OrganizationUserController> logger, IOrganizationFacade organizationFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _organizationFacade = organizationFacade;
            _organizationRoleFacade = organizationRoleFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddUserToOrganization(AddUserToOrganizationDto addUserToOrganizationDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addUserToOrganizationDto.UserAccessToken,
                    OperationType = new OperationType(new AdUserToOrganizationOperation()),
                    OrganizationId = addUserToOrganizationDto.OrganizationId,
                    ValidateAccessToken = true
                });
                _organizationFacade.AddUserToOrganization(addUserToOrganizationDto);
                return SendResponse();

            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllUserInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllUserInOrganization([FromQuery]string accessToken, [FromQuery]Guid organizationId)
        {
            Test(new TestRequestSettings()
            {
                AccessToken = accessToken,
                ValidateAccessToken = true,
                OrganizationId = organizationId,
                OperationType = new OperationType(new GetAllUserInOrganizationOperation())
            });
            return SendResponse(_organizationFacade.GetAllUserInOrganization(organizationId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetOrganizationRolesDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetOrganizationRoles()
        {
            return SendResponse(_organizationFacade.GetOrganizationRoles());
        }


        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult DeleteUserFromOrganization(string accessToken, Guid userOrganizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteUserFromOrganizationOperation()),
                    OrganizationId = GetOrganizationByUserInOrganization(userOrganizationId),
                    ValidateAccessToken = true
                });
                _organizationFacade.DeleteUserFromOrganization(userOrganizationId);
                return SendResponse();

            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetUserOrganizationRoleDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetUserOrganizationRoleDetail([FromQuery]string accessToken, [FromQuery]Guid userOrganizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetUserOrganizationRoleDetailOpertation()),
                    OrganizationId = GetOrganizationByUserInOrganization(userOrganizationId),
                    ValidateAccessToken = true
                });
                return SendResponse(_organizationFacade.GetUserOrganizationRoleDetail(userOrganizationId));
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
        public ActionResult UpdateUserInOrganizationRole(UpdateUserInOrganizationRoleDto updateUserInOrganizationRoleDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateUserInOrganizationRoleDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateUserToOrganizationOperation()),
                    OrganizationId = GetOrganizationByUserInOrganization(updateUserInOrganizationRoleDto.Id),
                    ValidateAccessToken = true
                });
                _organizationFacade.UpdateUserInOrganizationRole(updateUserInOrganizationRoleDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetUserOrganizationRoleDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetUserOrganizationRole([FromQuery]string accessToken, [FromQuery]Guid objectId, [FromQuery]string type)
        {
            try
            {
                if (type =="branch")
                {
                    objectId = GetOrganizationIdByBranch(objectId);
                }
                else if (type == "classroom")
                {
                    objectId = GetOrganizationIdByClassRoom(objectId);
                }
                else if (type == "userinorganization")
                {
                    objectId = GetOrganizationByUserInOrganization(objectId);
                }
                return SendResponse(_organizationRoleFacade.GetUserOrganizationRole(GetUserByAccessToken(accessToken).Id, objectId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

    }
}
