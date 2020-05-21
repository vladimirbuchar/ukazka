using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.ClassRoom;
using EduFacade.AuthFacade;
using EduFacade.ClassRoomFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.ClassRoomDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.ClassRoom
{
    public class ClassRoomController : BaseWebPortalController
    {
        private readonly IClassRoomFacade _classRoomFacade;

        public ClassRoomController(ILogger<ClassRoomController> logger, IClassRoomFacade classRoomFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _classRoomFacade = classRoomFacade;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        [ProducesResponseType(typeof(void), 404)]
        public ActionResult AddClassRoom(AddClassRoomDto addClassRoomDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addClassRoomDto.UserAccessToken,
                    OrganizationId = GetOrganizationIdByBranch(addClassRoomDto.BranchId),
                    OperationType = new OperationType(new AddClassRoomOperation()),
                    Request = addClassRoomDto,
                    ValidateAccessToken = true,
                    TestRequest = true
                });

                return SendResponse(_classRoomFacade.AddClassRoom(addClassRoomDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllClassRoomInBranchDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllClassRoomInBranch([FromQuery]string accessToken, [FromQuery]Guid branchId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByBranch(branchId),
                    OperationType = new OperationType(new GetAllClassRoomInBranchOperation()),
                    ValidateAccessToken = true,
                });
                return SendResponse(_classRoomFacade.GetAllClassRoomInBranch(branchId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetClassRoomDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetClassRoomDetail([FromQuery]string accessToken, [FromQuery]Guid classRoomId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByClassRoom(classRoomId),
                    OperationType = new OperationType(new GetClassRoomDetailOperation()),
                    ValidateAccessToken = true
                });
                return SendResponse(_classRoomFacade.GetClassRoomDetail(classRoomId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateClassRoom(UpdateClassRoomDto updateClassRoomDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateClassRoomDto.UserAccessToken,
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationIdByClassRoom(updateClassRoomDto.Id),
                    OperationType = new OperationType(new UpdateClassRoomOperation()),
                    Request = updateClassRoomDto,
                    TestRequest = true
                });
                _classRoomFacade.UpdateClassRoom(updateClassRoomDto);
                return SendResponse();
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
        public ActionResult DeleteClassRoom([FromQuery]string accessToken, [FromQuery]Guid classRoomId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByClassRoom(classRoomId),
                    OperationType = new OperationType(new DeleteClassRoomOperation()),
                    ValidateAccessToken = true,
                });
                _classRoomFacade.DeleteClassRoom(classRoomId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
