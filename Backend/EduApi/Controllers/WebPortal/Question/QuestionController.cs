using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.Question;
using EduFacade.AuthFacade;
using EduFacade.CourseFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.QuestionDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Question
{

    public class QuestionController : BaseWebPortalController
    {
        private readonly IQuestionFacade _questionFacade;
        public QuestionController(IQuestionFacade questionFacade, ILogger<QuestionController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _questionFacade = questionFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddQuestion(AddQuestionDto addQuestionDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addQuestionDto.UserAccessToken,
                    OrganizationId = GetOrganizationIdByBankOfQuestion(addQuestionDto.BankOfQUestionId),
                    OperationType = new OperationType(new AddQuestionOperation()),
                    Request = addQuestionDto,
                    TestRequest = true,
                    ValidateAccessToken = true,
                    ValidateLicense = true
                });
                return SendResponse(_questionFacade.AddQuestion(addQuestionDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetQuestionsInBankDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetQuestionsInBank([FromQuery]string accessToken, [FromQuery]Guid bankOfQuestionId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetQuestionsInBankOperation()),
                    OrganizationId = GetOrganizationIdByBankOfQuestion(bankOfQuestionId),
                    ValidateAccessToken = true
                });
                return SendResponse(_questionFacade.GetQuestionsInBank(bankOfQuestionId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetQuestionDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetQuestionDetail([FromQuery]string accessToken, [FromQuery]Guid questionId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetQuestionDetailOperation()),
                    OrganizationId = GetOrganizationByQuestion(questionId),
                    ValidateAccessToken = true,

                });
                return SendResponse(_questionFacade.GetQuestionDetail(questionId));
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
        public ActionResult UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateQuestionDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateQuestionOperation()),
                    OrganizationId = GetOrganizationByQuestion(updateQuestionDto.Id),
                    Request = updateQuestionDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_questionFacade.UpdateQuestion(updateQuestionDto));
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
        public ActionResult DeleteQuestion(string accessToken, Guid questionId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteQuestionOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByQuestion(questionId)
                });
                _questionFacade.DeleteQuestion(questionId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
