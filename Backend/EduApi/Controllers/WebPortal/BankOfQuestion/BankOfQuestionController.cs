using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.BankOfQuestion;
using EduFacade.AuthFacade;
using EduFacade.BankOfQuestionFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.BankOfQuestionDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.BankOfQuestion
{

    public class BankOfQuestionController : BaseWebPortalController
    {
        private readonly IBankOfQuestionFacade _bankOfQuestionFacade;
        public BankOfQuestionController(IBankOfQuestionFacade bankOfQuestionFacade, ILogger<BankOfQuestionController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _bankOfQuestionFacade = bankOfQuestionFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddBankOfQuestion(AddBankOfQuestionDto addBankOfQuestionDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addBankOfQuestionDto.UserAccessToken,
                    OrganizationId = addBankOfQuestionDto.OrganizationId,
                    OperationType = new OperationType(new AddBankOfQuestionOperation()),
                    Request = addBankOfQuestionDto,
                    TestRequest = true,
                    ValidateAccessToken = true,
                    ValidateLicense = true
                });
                return SendResponse(_bankOfQuestionFacade.AddBankOfQuestion(addBankOfQuestionDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetBankOfQuestionInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetBankOfQuestionInOrganization([FromQuery]string accessToken, [FromQuery]Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetBankOfQuestionInOrganizationOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                return SendResponse(_bankOfQuestionFacade.GetBankOfQuestionInOrganization(organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetBankOfQuestionDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetBankOfQuestionDetail([FromQuery]string accessToken, [FromQuery]Guid bankOfQuestionId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetBankOfQuestionDetailOperation()),
                    OrganizationId = GetOrganizationIdByBankOfQuestion(bankOfQuestionId),
                    ValidateAccessToken = true,

                });
                return SendResponse(_bankOfQuestionFacade.GetBankOfQuestionDetail(bankOfQuestionId));
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
        public ActionResult UpdateBankOfQuestion(UpdateBankOfQuestionDto updateBankOfQuestionDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateBankOfQuestionDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateBankOfQuestionOperation()),
                    OrganizationId = GetOrganizationIdByBankOfQuestion(updateBankOfQuestionDto.BankOfQuestionId),
                    Request = updateBankOfQuestionDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_bankOfQuestionFacade.UpdateBankOfQuestion(updateBankOfQuestionDto));
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
        public ActionResult DeleteBankOfQuestion(string accessToken, Guid bankOfQuestionId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteBankOfQuestionOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationIdByBankOfQuestion(bankOfQuestionId)
                });
                _bankOfQuestionFacade.DeleteBankOfQuestion(bankOfQuestionId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
