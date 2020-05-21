using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.Course;
using EduFacade.AuthFacade;
using EduFacade.CourseFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.CourseDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Course
{
    public class CourseController : BaseWebPortalController
    {
        private readonly ICourseFacade _courseFacade;
        public CourseController(ICourseFacade courseFacade, ILogger<CourseController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseFacade = courseFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourse(AddCourseDto addCourseDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addCourseDto.UserAccessToken,
                    OrganizationId = addCourseDto.OrganizationId,
                    OperationType = new OperationType(new AddCourseOperation()),
                    Request = addCourseDto,
                    TestRequest = true,
                    ValidateAccessToken = true,
                    ValidateLicense = true
                });
                return SendResponse(_courseFacade.AddCourse(addCourseDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllCourseInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllCourseInOrganization([FromQuery]string accessToken, [FromQuery]Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetAllOrganizationCourseOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseFacade.GetAllCourseInOrganization(organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetCourseDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseDetail([FromQuery]string accessToken, [FromQuery]Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetCourseDetailOperation()),
                    OrganizationId = GetOrganizationIdByCourse(courseId),
                    ValidateAccessToken = true,

                });
                return SendResponse(_courseFacade.GetCourseDetail(courseId));
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
        public ActionResult UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateCourseOperation()),
                    OrganizationId = GetOrganizationIdByCourse(updateCourseDto.Id),
                    Request = updateCourseDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseFacade.UpdateCourse(updateCourseDto));
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
        public ActionResult DeleteCourse(string accessToken, Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteCourseOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationIdByCourse(courseId)
                });
                _courseFacade.DeleteCourse(courseId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
