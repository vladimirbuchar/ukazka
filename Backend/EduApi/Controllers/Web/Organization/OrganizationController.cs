using Core.DataTypes;
using EduFacade.OrganizationFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.OrganizationDto;

namespace EduApi.Controllers.Web.Organization
{
    public class OrganizationController : BaseWebController
    {
        private readonly IOrganizationFacade _organizationFacade;
        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationFacade organizationFacade) : base(logger)
        {
            _organizationFacade = organizationFacade;
        }

        [HttpGet("{organizationId}")]
        [ProducesResponseType(typeof(GetOrganizationDetailWebDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetOrganizationDetail(Guid organizationId)
        {
            try
            {
                return SendResponse(_organizationFacade.GetOrganizationDetailWeb(organizationId));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetOrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetOrganizationList()
        {
            try
            {
                return SendResponse(_organizationFacade.GetOrganizationList());
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
