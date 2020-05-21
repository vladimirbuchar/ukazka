using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.CourseLector;
using EduFacade.AuthFacade;
using EduFacade.CourseLectorFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.CourseLectorDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.CourseTermLector
{
    public class CourseTermLectorController : BaseWebPortalController
    {
        private readonly ICourseLectorFacade _courseLectorFacade;
        public CourseTermLectorController(ICourseLectorFacade courseLectorFacade, ILogger<CourseTermLectorController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenceFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenceFacade)
        {
            _courseLectorFacade = courseLectorFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourseLector(AddCourseLectorDto addCourseLectorDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addCourseLectorDto.UserAccessToken,
                    OrganizationId = GetOrganizationIdByCourseTerm(addCourseLectorDto.CourseTerm),
                    OperationType = new OperationType(new AddCourseLectorOperation()),
                    Request = addCourseLectorDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });

                _courseLectorFacade.AddCourseLector(addCourseLectorDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet("{accessToken}/{courseTermId}")]
        [ProducesResponseType(typeof(List<GetAllLectorCourseTermDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllLectorCourseTerm(string accessToken, Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByCourseTerm(courseTermId),
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new GetAllLectorCourseTermOperation())
                });
                return SendResponse(_courseLectorFacade.GetAllLectorCourseTerm(courseTermId));
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
        public ActionResult DeleteCourseTermLector(string accessToken, Guid lectorId, Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new DeleteCourseTermLectorOperation()),
                    OrganizationId = GetOrganizationIdByCourseTerm(courseTermId)
                });
                _courseLectorFacade.DeleteCourseTermLector(lectorId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }




    }
}
