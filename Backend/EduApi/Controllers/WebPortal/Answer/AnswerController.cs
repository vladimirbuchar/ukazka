using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.Answer;
using EduFacade.AnswerFacade;
using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.AnswerDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Answer
{

    public class AnswerController : BaseWebPortalController
    {
        private readonly IAnswerFacade _answerFacade;
        public AnswerController(IAnswerFacade answerFacade, ILogger<AnswerController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _answerFacade = answerFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddAnswer(AddAnswerDto addAnswerDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addAnswerDto.UserAccessToken,
                    OrganizationId = GetOrganizationByQuestion(addAnswerDto.QuestionId),
                    OperationType = new OperationType(new AddAnswerOperation()),
                    Request = addAnswerDto,
                    TestRequest = true,
                    ValidateAccessToken = true,
                    ValidateLicense = true
                });
                return SendResponse(_answerFacade.AddAnswer(addAnswerDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet("{accessToken}/{questionId}")]
        [ProducesResponseType(typeof(IEnumerable<GetAnswersInQuestionDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAnswersInQuestion(string accessToken, Guid questionId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetAnswersInQuestionOperation()),
                    OrganizationId = GetOrganizationByQuestion(questionId),
                    ValidateAccessToken = true
                });
                return SendResponse(_answerFacade.GetAnswersInQuestion(questionId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet("{accessToken}/{answerId}")]
        [ProducesResponseType(typeof(GetAnswerDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAnswerDetail(string accessToken, Guid answerId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetAnswerDetailOperation()),
                    OrganizationId = GetOrganizationByAnswer(answerId),
                    ValidateAccessToken = true,

                });
                return SendResponse(_answerFacade.GetAnswerDetail(answerId));
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
        public ActionResult UpdateAnswer(UpdateAnswerDto updateAnswerDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateAnswerDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateAnswerOperation()),
                    OrganizationId = GetOrganizationByAnswer(updateAnswerDto.Id),
                    Request = updateAnswerDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_answerFacade.UpdateAnswer(updateAnswerDto));
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
        public ActionResult DeleteAnswer(string accessToken, Guid answerId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteAnswerOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByAnswer(answerId)
                });
                _answerFacade.DeleteAnswer(answerId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
