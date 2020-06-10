using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.StudentInCourse;
using EduFacade.AuthFacade;
using EduFacade.CourseStudentFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Shared;
using WebModel.StudentDto;

namespace EduApi.Controllers.WebPortal.CourseStudent
{
    public class CourseTermStudentController : BaseWebPortalController
    {
        private readonly ICourseStudentFacade _courseStudentFacade;
        public CourseTermStudentController(ILogger<CourseTermStudentController> logger, ICourseStudentFacade courseStudentFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseStudentFacade = courseStudentFacade;
        }


        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20AddOrganization&pageId=2
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddStudentToCourseTerm(AddStudentToCourseTermDto addStudentToCourseDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addStudentToCourseDto.UserAccessToken,
                    OrganizationId = GetOrganizationIdByCourseTerm(addStudentToCourseDto.CourseTermId),
                    OperationType = new OperationType(new AddStudentToCourseOperation()),
                    ValidateAccessToken = true,
                });
                return SendResponse(_courseStudentFacade.AddStudentToCourseTerm(addStudentToCourseDto, GetOrganizationIdByCourseTerm(addStudentToCourseDto.CourseTermId)));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllStudentInCourseTermDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllStudentInCourseTerm([FromQuery]string accessToken, [FromQuery]Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByCourseTerm(courseTermId),
                    OperationType = new OperationType(new GetAllStudentInCourseTermOperation())
                });
                return SendResponse(_courseStudentFacade.GetAllStudentInCourseTerm(courseTermId));
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
        public ActionResult DeleteStudentFromCourseTerm(string accessToken, Guid studentId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new DeleteStudentFromCourseTermOperation()),
                    OrganizationId = GetOrganizationByStudentId(studentId)
                });
                _courseStudentFacade.DeleteStudentFromCourseTerm(studentId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

    }
}
