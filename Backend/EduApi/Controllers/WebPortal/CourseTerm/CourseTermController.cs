using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation;
using EduCore.EduOperation.CourseTerm;
using EduFacade.AuthFacade;
using EduFacade.CourseTermFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.CourseTermDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.CourseTerm
{
    public class CourseTermController : BaseWebPortalController
    {
        private readonly ICourseTermFacade _courseTermFacade;
        public CourseTermController(ICourseTermFacade courseTermFacade, ILogger<CourseTermController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseTermFacade = courseTermFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourseTerm(AddCourseTermDto addCourseTermDto)
        {
            try
            {
                Test(
                    new TestRequestSettings()
                    {
                        AccessToken = addCourseTermDto.UserAccessToken,
                        OrganizationId = GetOrganizationIdByCourse(addCourseTermDto.CourseId),
                        OperationType = new OperationType(new GetMyNotificationOperation()),
                        Request = addCourseTermDto,
                        TestRequest = true,
                        ValidateAccessToken = true
                    });
                return SendResponse(_courseTermFacade.AddCourseTerm(addCourseTermDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllTermInCourseDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllTermInCourse([FromQuery]string accessToken, [FromQuery]Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new GetAllTermInCourseOperation()),
                    OrganizationId = GetOrganizationIdByCourse(courseId)
                });
                return SendResponse(_courseTermFacade.GetAllTermInCourse(courseId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetCourseTermDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseTermDetail([FromQuery]string accessToken, [FromQuery]Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByCourseTerm(courseTermId),
                    OperationType = new OperationType(new GetCourseTermDetailOperation())
                });
                return SendResponse(_courseTermFacade.GetCourseTermDetail(courseTermId));
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
        public ActionResult UpdateCourseTerm(UpdateCourseTermDto updateCourseTermDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseTermDto.UserAccessToken,
                    OrganizationId = GetOrganizationIdByCourseTerm(updateCourseTermDto.Id),
                    OperationType = new OperationType(new UpdateCourseTermOperation()),
                    Request = updateCourseTermDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseTermFacade.UpdateCourseTerm(updateCourseTermDto));
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
        public ActionResult DeleteCourseTerm(string accessToken, Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteCourseTermOperation()),
                    OrganizationId = GetOrganizationIdByCourseTerm(courseTermId)
                });
                _courseTermFacade.DeleteCourseTerm(courseTermId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
