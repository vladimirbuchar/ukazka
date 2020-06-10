using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EduApi.Controllers.WebPortal
{
    [Route("api/webportal/[controller]/[action]")]
    public class BaseWebPortalController : BaseController
    {
        private readonly IOrganizationRoleFacade _organizationRoleFacade;

        public BaseWebPortalController(ILogger<BaseWebPortalController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _organizationRoleFacade = organizationRoleFacade;
        }

        /// <summary>
        /// return organization guid by branch id
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        protected Guid GetOrganizationIdByBranch(Guid branchId)
        {
            return _organizationRoleFacade.GetOrganizationIdByBranch(branchId);
        }

        /// <summary>
        /// return organization guid by classroom guid
        /// </summary>
        /// <param name="classRoomId"></param>
        /// <returns></returns>
        protected Guid GetOrganizationIdByClassRoom(Guid classRoomId)
        {
            return _organizationRoleFacade.GetOrganizationIdByClassRoom(classRoomId);
        }

        /// <summary>
        /// get organization guid by course guid 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        protected Guid GetOrganizationIdByCourse(Guid courseId)
        {
            return _organizationRoleFacade.GetOrganizationIdByCourse(courseId);
        }
        protected Guid GetOrganizationIdByBankOfQuestion(Guid courseId)
        {
            return _organizationRoleFacade.GetOrganizationIdByBankOfQuestion(courseId);
        }
        protected Guid GetOrganizationByCourseLesson(Guid courseLessonId)
        {
            return _organizationRoleFacade.GetOrganizationByCourseLesson(courseLessonId);
        }

        protected Guid GetOrganizationByCourseLessonItem(Guid courseLessonItemId)
        {
            return _organizationRoleFacade.GetOrganizationByCourseLessonItem(courseLessonItemId);
        }
        protected Guid GetOrganizationByAnswer(Guid answerId)
        {
            return _organizationRoleFacade.GetOrganizationByAnswer(answerId);
        }

        protected Guid GetOrganizationByQuestion(Guid questionId)
        {
            return _organizationRoleFacade.GetOrganizationIdByQuestion(questionId);
        }

        /// <summary>
        /// get organization guid by course term guid 
        /// </summary>
        /// <param name="courseTermtermId"></param>
        /// <returns></returns>
        protected Guid GetOrganizationIdByCourseTerm(Guid courseTermtermId)
        {
            return _organizationRoleFacade.GetOrganizationIdByCourseTerm(courseTermtermId);
        }
        protected Guid GetOrganizationByStudentId(Guid studentId)
        {
            return _organizationRoleFacade.GetOrganizationByStudentId(studentId);
        }

        /// <summary>
        /// get organization guid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected Guid GetOrganizationByUserInOrganization(Guid id)
        {
            return _organizationRoleFacade.GetOrganizationByUserInOrganization(id);
        }
    }
}
