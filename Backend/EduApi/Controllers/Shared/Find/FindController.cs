using Core.DataTypes;
using EduApi.Controllers.Web;
using EduFacade.OrganizationFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.OrganizationDto;

namespace EduApi.Controllers.Shared.Find
{
    public class FindController : BaseSharedWebController
    {
        private readonly IOrganizationFacade _organizationFacade;
        public FindController(ILogger<FindController> logger, IOrganizationFacade organizationFacade) : base(logger)
        {
            _organizationFacade = organizationFacade;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FindOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult FindOrganization(string findText)
        {
            try
            {
                return SendResponse(_organizationFacade.FindOrganization(findText));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
