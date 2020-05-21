using Core.DataTypes;
using EduFacade.CourseFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.CourseDto;
namespace EduApi.Controllers.Web.Course
{
    public class CourseController : BaseWebController
    {

        private readonly ICourseFacade _courseFacade;
        public CourseController(ICourseFacade courseFacade, ILogger<CourseController> logger) : base(logger)
        {
            _courseFacade = courseFacade;
        }

        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEduGit/_wiki/wikis/MyEduGit.wiki?wikiVersion=GBwikiMaster&pagePath=%2FV%C3%BDpis%20kurz%C5%AF%2FREST%20slu%C5%BEby%2FGetCourseOffer&pageId=67
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCourseOfferDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetCourseOffer([FromQuery]CourseFilterDto courseFilter)
        {
            try
            {
                return SendResponse(_courseFacade.GetCourseOffer(courseFilter));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
