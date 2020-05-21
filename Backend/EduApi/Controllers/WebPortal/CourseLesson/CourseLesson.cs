using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.CourseLesson;
using EduFacade.AuthFacade;
using EduFacade.CourseChapterFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.CourseLesson;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.CourseLesson
{
    public class CourseLesson : BaseWebPortalController
    {
        private readonly ICourseLessonFacade _courseLessonFacade;
        public CourseLesson(ILogger<CourseLesson> logger, ICourseLessonFacade courseLessonFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseLessonFacade = courseLessonFacade;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourseLesson(AddCourseLessonDto addCourseLessonDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addCourseLessonDto.UserAccessToken,
                    OrganizationId = GetOrganizationIdByCourse(addCourseLessonDto.CourseId),
                    OperationType = new OperationType(new AddCourseLessonOperation()),
                    Request = addCourseLessonDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _courseLessonFacade.AddCourseLesson(addCourseLessonDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet("{accessToken}/{courseId}")]
        [ProducesResponseType(typeof(IEnumerable<GetAllLessonInCourseDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllLessonInCourse(string accessToken, Guid courseId)
        {
            Test(new TestRequestSettings()
            {
                AccessToken = accessToken,
                OrganizationId = GetOrganizationIdByCourse(courseId),
                OperationType = new OperationType(new GetAllLessonInCourseOperation()),
                ValidateAccessToken = true
            });
            return SendResponse(_courseLessonFacade.GetAllLessonInCourse(courseId));
        }

        [HttpGet("{accessToken}/{courseLessonId}")]
        [ProducesResponseType(typeof(GetCourseLessonDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseLessonDetail(string accessToken, Guid courseLessonId)
        {
            Test(new TestRequestSettings()
            {
                AccessToken = accessToken,
                OrganizationId = GetOrganizationByCourseLesson(courseLessonId),
                OperationType = new OperationType(new GetCourseLessonDetailOperation()),
                ValidateAccessToken = true
            });

            return SendResponse(_courseLessonFacade.GetCourseLessonDetail(courseLessonId));
        }
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateCourseLesson(UpdateCourseLessonDto updateCourseLessonDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseLessonDto.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseLesson(updateCourseLessonDto.Id),
                    OperationType = new OperationType(new UpdateCourseLessonOperation()),
                    Request = updateCourseLessonDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _courseLessonFacade.UpdateCourseLesson(updateCourseLessonDto);
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
        public ActionResult DeleteCourseLesson(string accessToken, Guid courseLessonId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationByCourseLesson(courseLessonId),
                    OperationType = new OperationType(new DeleteCourseLessonOperation()),
                    ValidateAccessToken = true
                });
                _courseLessonFacade.DeleteCourseLesson(courseLessonId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
