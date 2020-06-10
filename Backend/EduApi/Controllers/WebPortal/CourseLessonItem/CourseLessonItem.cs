using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.CourseLessonItem;
using EduFacade.AuthFacade;
using EduFacade.CourseLessonItemFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.CourseLessonItemDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.CourseLessonItem
{
    public class CourseLessonItem : BaseWebPortalController
    {
        private readonly ICourseLessonItemFacade _courseLessonItemFacade;
        public CourseLessonItem(ILogger<CourseLessonItem> logger, ICourseLessonItemFacade courseLessonItemFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseLessonItemFacade = courseLessonItemFacade;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourseLessonItem(AddCourseLessonItemDto courseLessonItemCreateDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = courseLessonItemCreateDto.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseLesson(courseLessonItemCreateDto.CourseLessonId),
                    OperationType = new OperationType(new AddCourseLessonItemOperation()),
                    Request = courseLessonItemCreateDto,
                    TestRequest = true,
                    ValidateAccessToken = true,
                });
                return SendResponse(_courseLessonItemFacade.AddCourseLessonItem(courseLessonItemCreateDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCourseLessonItemsDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseLessonItems([FromQuery]string accessToken, [FromQuery]Guid courseLessonId)
        {
            Test(new TestRequestSettings()
            {
                AccessToken = accessToken,
                OrganizationId = GetOrganizationByCourseLesson(courseLessonId),
                OperationType = new OperationType(new GetCourseLessonItemsOperation()),
                ValidateAccessToken = true
            });
            return SendResponse(_courseLessonItemFacade.GetCourseLessonItems(courseLessonId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetCourseLessonItemDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseLessonItemDetail([FromQuery]string accessToken, [FromQuery]Guid courseLessonItemId)
        {
            Test(new TestRequestSettings()
            {
                AccessToken = accessToken,
                OrganizationId = GetOrganizationByCourseLessonItem(courseLessonItemId),
                OperationType = new OperationType(new GetCourseLessonItemDetailOperation()),
                ValidateAccessToken = true
            });

            return SendResponse(_courseLessonItemFacade.GetCourseLessonItemDetail(courseLessonItemId));
        }
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateCourseLessonItem(UpdateCourseLessonItemDto updateCourseLessonItemDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseLessonItemDto.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseLessonItem(updateCourseLessonItemDto.CourseLessonItemId),
                    OperationType = new OperationType(new UpdateCourseLessonItemOperation()),
                    Request = updateCourseLessonItemDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _courseLessonItemFacade.UpdateCourseLessonItem(updateCourseLessonItemDto);
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
        public ActionResult DeleteCourseLessonItem(string accessToken, Guid courseLessonItemId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationByCourseLessonItem(courseLessonItemId),
                    OperationType = new OperationType(new DeleteCourseLessonItemOperation()),
                    ValidateAccessToken = true
                });
                _courseLessonItemFacade.DeleteCourseLessonItem(courseLessonItemId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
