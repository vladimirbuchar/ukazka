using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.Branch;
using EduFacade.AuthFacade;
using EduFacade.BranchFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.BranchDto;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Branch
{
    public class BranchController : BaseWebPortalController
    {
        private readonly IBranchFacade _branchFacade;
        public BranchController(ILogger<BranchController> logger, IBranchFacade branchFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _branchFacade = branchFacade;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddBranch(AddBranchDto addBranchDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    TestRequest = true,
                    AccessToken = addBranchDto.UserAccessToken,
                    OperationType = new OperationType(new AddBranchOperation()),
                    OrganizationId = addBranchDto.OrganizationId,
                    Request = addBranchDto,
                    ValidateLicense = true
                });
                return SendResponse(_branchFacade.AddBranch(addBranchDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllBranchInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllBranchInOrganization([FromQuery]string accessToken, [FromQuery]Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetAllBranchInOrganizationOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true,
                });
                return SendResponse(_branchFacade.GetAllBranchInOrganization(organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetBranchDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetBranchDetail([FromQuery]string accessToken, [FromQuery]Guid branchId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetBranchDetailOperation()),
                    OrganizationId = GetOrganizationIdByBranch(branchId),
                    ValidateAccessToken = true,
                });
                return SendResponse(_branchFacade.GetBranchDetail(branchId));
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
        public ActionResult UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            try
            {
                Test(
                    new TestRequestSettings()
                    {
                        AccessToken = updateBranchDto.UserAccessToken,
                        OrganizationId = GetOrganizationIdByBranch(updateBranchDto.Id),
                        Request = updateBranchDto,
                        OperationType = new OperationType(new UpdateBranchOperation()),
                        TestRequest = true,
                        ValidateAccessToken = true,
                    });
                return SendResponse(_branchFacade.UpdateBranch(updateBranchDto));
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
        public ActionResult DeleteBranch([FromQuery]string accessToken, [FromQuery]Guid branchId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByBranch(branchId),
                    OperationType = new OperationType(new DeleteBranchOperation()),
                    ValidateAccessToken = true,
                });
                _branchFacade.DeleteBranch(branchId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}


